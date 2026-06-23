using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Full-screen form for conducting and recording a 1:1 meeting.
/// Shows meeting notes tabs (Project Notes, Career Updates, Training Updates, General Notes),
/// a checklist tab for answering assigned questions, action items, mentions, and glows/grows.
/// </summary>
public partial class MeetingForm : Form
{
    internal static readonly Color OverdueBg = Color.FromArgb(255, 235, 235);
    internal static readonly Color OverdueFg = Color.FromArgb(180, 0, 0);

    private readonly int      _personId;
    private readonly DateTime _meetingDate;
    private int?              _meetingId;

    private string _personDisplayName = "";
    private string _personFullName    = "";

    private readonly List<GlowGrow> _glows = new();
    private readonly List<GlowGrow> _grows = new();

    private readonly Dictionary<MeetingNoteCategory, RichTextBox> _noteBoxes = new();

    private readonly List<ChecklistRow> _checklistRows = new();
    private sealed record ChecklistRow(int QuestionId, ChecklistValueType ValueType, Control AnswerControl);

    /// <summary>Initialises the meeting form.</summary>
    /// <param name="personId">The direct report this meeting is with.</param>
    /// <param name="meetingDate">The date the meeting takes place.</param>
    /// <param name="existingMeetingId">Pass an existing meeting ID to open a saved meeting; omit to start a new one.</param>
    public MeetingForm() : this(0, DateTime.Today) { }

    public MeetingForm(int personId, DateTime meetingDate, int? existingMeetingId = null)
    {
        _personId    = personId;
        _meetingDate = meetingDate;
        _meetingId   = existingMeetingId;
        InitializeComponent();
        _tabColors = new Color[]
        {
            Color.FromArgb(41,  128, 185),
            Color.FromArgb(142, 68,  173),
            Color.FromArgb(22,  160, 133),
            Color.FromArgb(211, 84,  0),
            Color.FromArgb(52,  73,  94)
        };
        _noteBoxes[MeetingNoteCategory.ProjectNotes]    = _rtbProjectNotes;
        _noteBoxes[MeetingNoteCategory.CareerUpdates]   = _rtbCareerUpdates;
        _noteBoxes[MeetingNoteCategory.TrainingUpdates] = _rtbTrainingUpdates;
        _noteBoxes[MeetingNoteCategory.GlowsGrows]      = _rtbGeneralNotes;
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            _ = LoadAsync();
    }

    private void OnTabsMainDrawItem(object? sender, DrawItemEventArgs e)
    {
        var tc         = (TabControl)sender!;
        var isSelected = e.Index == tc.SelectedIndex;
        var c          = _tabColors[e.Index];
        var bgColor    = isSelected ? c
            : Color.FromArgb((int)(c.R * 0.6f), (int)(c.G * 0.6f), (int)(c.B * 0.6f));

        using var bg   = new SolidBrush(bgColor);
        e.Graphics.FillRectangle(bg, e.Bounds);

        using var fg   = new SolidBrush(Color.White);
        var style      = isSelected ? FontStyle.Bold : FontStyle.Regular;
        using var font = new Font(_tabsMain.Font.FontFamily, _tabsMain.Font.Size, style);
        var sf         = new StringFormat
        {
            Alignment     = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
            Trimming      = StringTrimming.EllipsisCharacter
        };
        e.Graphics.DrawString(tc.TabPages[e.Index].Text, font, fg, (RectangleF)e.Bounds, sf);
    }

    /// <summary>Master load: fetches the person, then calls each section's loader in sequence.</summary>
    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();
        var person = await ctx.People.FindAsync(_personId);
        if (person == null) return;

        _personDisplayName = person.DisplayName;
        _personFullName    = $"{person.FirstName} {person.LastName}";
        _lblName.Text      = person.DisplayName;

        await LoadGlowsGrowsAsync(ctx);
        await LoadNotesAsync();
        await LoadChecklistAsync();
        await LoadActionItemsAsync();
        await LoadMentionsAsync();
    }

    /// <summary>
    /// Rebuilds the checklist tab by loading all questions assigned to this person
    /// and populating answer controls from any existing evaluations for the current meeting.
    /// </summary>
    private async Task LoadChecklistAsync()
    {
        _checklistRows.Clear();
        _checklistContainer.SuspendLayout();
        _checklistContainer.Controls.Clear();

        await using var ctx = DbFactory.Create();

        var assignments = await ctx.PersonQuestionAssignments
            .Include(a => a.Question)
            .Where(a => a.PersonId == _personId)
            .OrderBy(a => a.Question.SortOrder)
            .ThenBy(a => a.Question.Description)
            .ToListAsync();

        if (assignments.Count == 0)
        {
            _checklistContainer.Controls.Add(new Label
            {
                Text      = "No checklist questions are assigned to this person.\nGo to Checklist Questions to add and assign questions.",
                ForeColor = Color.FromArgb(150, 150, 150),
                Font      = new Font("Segoe UI", 13f, FontStyle.Italic),
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });
            _checklistContainer.ResumeLayout(true);
            return;
        }

        // Load any answers recorded for this specific meeting
        var existingValues = new Dictionary<int, string?>();
        if (_meetingId.HasValue)
        {
            var evals = await ctx.ChecklistItemEvaluations
                .Where(e => e.PersonId == _personId && e.MeetingId == _meetingId.Value)
                .ToListAsync();
            foreach (var ev in evals)
                existingValues[ev.QuestionId] = ev.Value;
        }

        // Build rows — must add in reverse because DockStyle.Top inserts at the visual top
        var rows = new List<Panel>();
        foreach (var a in assignments)
        {
            var q      = a.Question;
            var rowH   = q.ValueType == ChecklistValueType.Text ? 72 : 54;
            var rowPnl = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = rowH,
                BackColor = Color.White,
                Padding   = new Padding(6, 4, 8, 4)
            };
            rowPnl.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(220, 225, 230));
                var p = (Panel)s!;
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            };

            var tbl = new TableLayoutPanel { Dock = DockStyle.Fill };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var lblQ = new Label
            {
                Text      = q.Description,
                Dock      = DockStyle.Fill,
                Font      = new Font("Segoe UI", 13f),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var freqText = a.Frequency switch
            {
                CheckFrequency.Weekly     => "Weekly",
                CheckFrequency.BiWeekly   => "Bi-Weekly",
                CheckFrequency.Monthly    => "Monthly",
                CheckFrequency.Quarterly  => "Quarterly",
                CheckFrequency.SemiAnnual => "Semi-Annual",
                CheckFrequency.Annual     => "Annual",
                _                         => ""
            };
            var lblFreq = new Label
            {
                Text      = freqText,
                Dock      = DockStyle.Fill,
                Font      = new Font("Segoe UI", 11f, FontStyle.Italic),
                ForeColor = Color.FromArgb(120, 120, 120),
                TextAlign = ContentAlignment.MiddleCenter
            };

            existingValues.TryGetValue(q.QuestionId, out var existing);
            var answerCtrl = BuildAnswerControl(q.ValueType, existing);
            answerCtrl.Dock = DockStyle.Fill;

            tbl.Controls.Add(lblQ,       0, 0);
            tbl.Controls.Add(lblFreq,    1, 0);
            tbl.Controls.Add(answerCtrl, 2, 0);
            rowPnl.Controls.Add(tbl);

            _checklistRows.Add(new ChecklistRow(q.QuestionId, q.ValueType, answerCtrl));
            rows.Add(rowPnl);
        }

        for (int i = rows.Count - 1; i >= 0; i--)
            _checklistContainer.Controls.Add(rows[i]);

        _checklistContainer.ResumeLayout(true);
    }

    /// <summary>Creates the appropriate input control for the given checklist value type, pre-populated with an existing answer if available.</summary>
    /// <param name="valueType">Determines which control type to create.</param>
    /// <param name="existing">Previously saved answer string, or null for a blank control.</param>
    private static Control BuildAnswerControl(ChecklistValueType valueType, string? existing)
    {
        switch (valueType)
        {
            case ChecklistValueType.YesNo:
                var cbo = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Font          = new Font("Segoe UI", 13f)
                };
                cbo.Items.AddRange(new object[] { "", "Yes", "No" });
                cbo.SelectedIndex = existing == "Yes" ? 1 : existing == "No" ? 2 : 0;
                return cbo;

            case ChecklistValueType.Integer:
                var nudInt = new NumericUpDown
                {
                    DecimalPlaces = 0,
                    Minimum       = -999999,
                    Maximum       = 999999,
                    Font          = new Font("Segoe UI", 13f)
                };
                if (int.TryParse(existing, out var iv)) nudInt.Value = iv;
                return nudInt;

            case ChecklistValueType.Percentage:
                var nudPct = new NumericUpDown
                {
                    DecimalPlaces = 0,
                    Minimum       = 0,
                    Maximum       = 100,
                    Font          = new Font("Segoe UI", 13f)
                };
                if (int.TryParse(existing, out var pv)) nudPct.Value = pv;
                return nudPct;

            case ChecklistValueType.Date:
                var dtp = new DateTimePicker
                {
                    Format       = DateTimePickerFormat.Short,
                    Font         = new Font("Segoe UI", 13f),
                    ShowCheckBox = true,
                    Checked      = existing != null
                };
                if (DateTime.TryParse(existing, out var dv)) dtp.Value = dv;
                return dtp;

            default: // Text
                return new TextBox
                {
                    Font = new Font("Segoe UI", 13f),
                    Text = existing ?? ""
                };
        }
    }

    /// <summary>Loads saved meeting notes from the database into the corresponding tab RichTextBoxes.</summary>
    private async Task LoadNotesAsync()
    {
        if (_meetingId == null) return;
        await using var ctx = DbFactory.Create();
        var notes = await ctx.MeetingNotes
            .Where(n => n.MeetingId == _meetingId.Value)
            .ToListAsync();
        foreach (var (cat, rtb) in _noteBoxes)
            rtb.Text = notes.FirstOrDefault(n => n.Category == cat)?.NoteText ?? "";
    }

    /// <summary>Loads uncommunicated glows and grows for the person into the right-panel check lists.</summary>
    private async Task LoadGlowsGrowsAsync(AppDbContext ctx)
    {
        var uncommunicated = await ctx.GlowsGrows
            .Include(g => g.Person)
            .Where(g => g.PersonId == _personId && g.CommunicatedDate == null)
            .OrderBy(g => g.CreatedDate)
            .ToListAsync();

        _glows.Clear(); _grows.Clear();
        _clbGlows.Items.Clear(); _clbGrows.Items.Clear();

        foreach (var item in uncommunicated)
        {
            var display = item.Note.Length > 70 ? item.Note[..70] + "…" : item.Note;
            if (item.Type == GlowGrowType.Glow)
            {
                _glows.Add(item);
                _clbGlows.Items.Add(display, false);
            }
            else
            {
                _grows.Add(item);
                _clbGrows.Items.Add(display, false);
            }
        }

        _lblGlowsHeader.Text = $"Glows ({_glows.Count})";
        _lblGrowsHeader.Text  = $"Grows ({_grows.Count})";
    }

    /// <summary>Refreshes the action items grid, applying the open/all filter.</summary>
    private async Task LoadActionItemsAsync()
    {
        await using var ctx = DbFactory.Create();
        var query = ctx.ActionItems
            .Where(a => a.PersonId == _personId);

        if (_cboAiFilter.SelectedIndex == 0)
            query = query.Where(a => !a.IsComplete);

        var items = await query
            .OrderBy(a => a.AssignedTo)
            .ThenBy(a => a.DueDate)
            .ToListAsync();

        var today = DateTime.Today;
        _gridActionItems.Rows.Clear();

        foreach (var item in items)
        {
            var assignedLabel = item.AssignedTo == ActionItemAssignee.Me
                ? "Manager" : _personDisplayName;
            var desc = item.Description.Length > 100
                ? item.Description[..100] + "…" : item.Description;
            var dueStr = item.DueDate.ToShortDateString();

            _gridActionItems.Rows.Add(
                item.CreatedDate.ToShortDateString(),
                assignedLabel,
                desc,
                dueStr);

            var row = _gridActionItems.Rows[^1];
            row.Tag = item.ActionItemId;

            if (!item.IsComplete && item.DueDate < today)
            {
                row.DefaultCellStyle.BackColor = OverdueBg;
                row.DefaultCellStyle.ForeColor = OverdueFg;
            }
            else if (item.IsComplete)
            {
                row.DefaultCellStyle.ForeColor = Color.FromArgb(150, 150, 150);
            }
        }

        var open = items.Count(a => !a.IsComplete);
        _lblAiCount.Text = open == 0 ? "" : $"{open} open";
    }

    /// <summary>Loads open action items from other meetings that @-mention this person by full name.</summary>
    private async Task LoadMentionsAsync()
    {
        if (string.IsNullOrEmpty(_personFullName)) return;

        await using var ctx = DbFactory.Create();
        var tag = "@" + _personFullName;

        var items = await ctx.ActionItems
            .Include(a => a.Person)
            .Where(a => !a.IsComplete &&
                        a.PersonId != _personId &&
                        a.Description.Contains(tag))
            .OrderBy(a => a.DueDate)
            .ToListAsync();

        var today = DateTime.Today;
        _gridMentions.Rows.Clear();

        foreach (var item in items)
        {
            var desc = item.Description.Length > 110
                ? item.Description[..110] + "…" : item.Description;

            _gridMentions.Rows.Add(
                item.Person.DisplayName,
                desc,
                item.DueDate.ToShortDateString());

            var row = _gridMentions.Rows[^1];
            row.Tag = item.ActionItemId;

            if (item.DueDate < today)
            {
                row.DefaultCellStyle.BackColor = OverdueBg;
                row.DefaultCellStyle.ForeColor = OverdueFg;
            }
        }
    }

    /// <summary>Ensures the meeting is saved, then opens the Add Action Item dialog.</summary>
    private async Task AddActionItemAsync()
    {
        var meetingId = await EnsureMeetingSavedAsync();

        using var form = new AddActionItemForm(meetingId, _personId, _personDisplayName, _meetingDate);
        if (form.ShowDialog(this) == DialogResult.OK)
            await LoadActionItemsAsync();
    }

    /// <summary>Opens the completion dialog for the selected action item in the meeting context.</summary>
    private async Task CompleteActionItemAsync()
    {
        if (_gridActionItems.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Select an action item first.", "No Selection");
            return;
        }
        using var form = new CompleteActionItemForm(id, _meetingId);
        if (form.ShowDialog(this) == DialogResult.OK)
            await LoadActionItemsAsync();
    }

    /// <summary>Prompts for confirmation and permanently deletes the selected action item.</summary>
    private async Task DeleteActionItemAsync()
    {
        if (_gridActionItems.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Select an action item first.", "No Selection");
            return;
        }
        if (MessageBox.Show(
                "Delete this action item?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            != DialogResult.Yes) return;

        await using var ctx = DbFactory.Create();
        var item = await ctx.ActionItems.FindAsync(id);
        if (item == null) return;
        ctx.ActionItems.Remove(item);
        await ctx.SaveChangesAsync();
        await LoadActionItemsAsync();
    }

    /// <summary>Saves the meeting, marks checked glows/grows as communicated, upserts notes, and saves checklist answers.</summary>
    private async Task SaveAsync()
    {
        var meetingId = await EnsureMeetingSavedAsync();

        await using var ctx = DbFactory.Create();

        // Glows/Grows — mark checked ones as communicated
        var checkedIds = new List<int>();
        foreach (int i in _clbGlows.CheckedIndices) checkedIds.Add(_glows[i].GlowGrowId);
        foreach (int i in _clbGrows.CheckedIndices)  checkedIds.Add(_grows[i].GlowGrowId);

        if (checkedIds.Count > 0)
        {
            var entities = await ctx.GlowsGrows
                .Where(g => checkedIds.Contains(g.GlowGrowId))
                .ToListAsync();
            foreach (var e in entities)
                e.CommunicatedDate = _meetingDate;
        }

        // Notes — upsert one record per category
        var existingNotes = await ctx.MeetingNotes
            .Where(n => n.MeetingId == meetingId)
            .ToListAsync();

        foreach (var (cat, rtb) in _noteBoxes)
        {
            var text     = rtb.Text.Trim();
            var existing = existingNotes.FirstOrDefault(n => n.Category == cat);
            if (existing != null)
            {
                if (string.IsNullOrWhiteSpace(text))
                    ctx.MeetingNotes.Remove(existing);
                else
                    existing.NoteText = text;
            }
            else if (!string.IsNullOrWhiteSpace(text))
            {
                ctx.MeetingNotes.Add(new MeetingNote
                {
                    MeetingId = meetingId,
                    Category  = cat,
                    NoteText  = text
                });
            }
        }

        await ctx.SaveChangesAsync();
        await SaveChecklistAsync(meetingId);

        MessageBox.Show("Meeting saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        await LoadAsync();
    }

    /// <summary>Upserts one <see cref="ChecklistItemEvaluation"/> per checklist row that has an answer; removes records for cleared answers.</summary>
    /// <param name="meetingId">The meeting to associate the evaluations with.</param>
    private async Task SaveChecklistAsync(int meetingId)
    {
        if (_checklistRows.Count == 0) return;

        await using var ctx = DbFactory.Create();
        var qIds     = _checklistRows.Select(r => r.QuestionId).ToList();
        var existing = await ctx.ChecklistItemEvaluations
            .Where(e => e.PersonId == _personId &&
                        e.MeetingId == meetingId &&
                        qIds.Contains(e.QuestionId))
            .ToListAsync();

        foreach (var row in _checklistRows)
        {
            var value = GetAnswerValue(row.ValueType, row.AnswerControl);
            var eval  = existing.FirstOrDefault(e => e.QuestionId == row.QuestionId);

            if (eval != null)
            {
                if (string.IsNullOrWhiteSpace(value))
                    ctx.ChecklistItemEvaluations.Remove(eval);
                else
                    eval.Value = value;
            }
            else if (!string.IsNullOrWhiteSpace(value))
            {
                ctx.ChecklistItemEvaluations.Add(new ChecklistItemEvaluation
                {
                    PersonId      = _personId,
                    QuestionId    = row.QuestionId,
                    MeetingId     = meetingId,
                    EvaluatedDate = _meetingDate.Date,
                    Value         = value
                });
            }
        }

        await ctx.SaveChangesAsync();
    }

    /// <summary>Reads the current value from an answer control and returns it as a string, or null if blank.</summary>
    private static string? GetAnswerValue(ChecklistValueType valueType, Control control) =>
        valueType switch
        {
            ChecklistValueType.YesNo =>
                control is ComboBox c && c.SelectedIndex > 0 ? c.SelectedItem?.ToString() : null,
            ChecklistValueType.Integer or ChecklistValueType.Percentage =>
                control is NumericUpDown n ? n.Value.ToString() : null,
            ChecklistValueType.Date =>
                control is DateTimePicker d && d.Checked ? d.Value.Date.ToShortDateString() : null,
            _ =>
                control is TextBox t && !string.IsNullOrWhiteSpace(t.Text) ? t.Text.Trim() : null
        };

    /// <summary>Creates a <see cref="Meeting"/> row if one does not yet exist, then returns its ID.</summary>
    private async Task<int> EnsureMeetingSavedAsync()
    {
        if (_meetingId != null) return _meetingId.Value;

        await using var ctx = DbFactory.Create();
        var meeting = new Meeting { PersonId = _personId, MeetingDate = _meetingDate };
        ctx.Meetings.Add(meeting);
        await ctx.SaveChangesAsync();
        _meetingId = meeting.MeetingId;
        return _meetingId.Value;
    }

    private void OpenGlowGrowDetail(CheckedListBox clb, List<GlowGrow> source, Point location)
    {
        int idx = clb.IndexFromPoint(location);
        if (idx == ListBox.NoMatches) return;
        using var form = new GlowGrowDetailForm(source[idx]);
        form.ShowDialog(this);
    }

    private async void BtnSave_Click(object? sender, EventArgs e) { await SaveAsync(); }
    private void ClbGlows_MouseDoubleClick(object? sender, MouseEventArgs e) { OpenGlowGrowDetail(_clbGlows, _glows, e.Location); }
    private void ClbGrows_MouseDoubleClick(object? sender, MouseEventArgs e) { OpenGlowGrowDetail(_clbGrows, _grows, e.Location); }
    private async void BtnAddAI_Click(object? sender, EventArgs e) { await AddActionItemAsync(); }
    private async void BtnComplete_Click(object? sender, EventArgs e) { await CompleteActionItemAsync(); }
    private async void BtnDeleteAI_Click(object? sender, EventArgs e) { await DeleteActionItemAsync(); }
    private async void CboAiFilter_SelectedIndexChanged(object? sender, EventArgs e) { await LoadActionItemsAsync(); }
    private void TabsMain_SelectedIndexChanged(object? sender, EventArgs e) { _tabsMain.Invalidate(); }
}
