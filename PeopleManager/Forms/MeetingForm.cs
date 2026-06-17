using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

public class MeetingForm : Form
{
    internal static readonly Color OverdueBg = Color.FromArgb(255, 235, 235);
    internal static readonly Color OverdueFg = Color.FromArgb(180, 0, 0);

    private readonly int      _personId;
    private readonly DateTime _meetingDate;
    private int?              _meetingId;

    private string _personDisplayName = "";
    private string _personFullName    = "";

    private Label _lblName = null!;
    private Label _lblDate = null!;

    private Label          _lblGlowsHeader = null!;
    private Label          _lblGrowsHeader  = null!;
    private CheckedListBox _clbGlows        = null!;
    private CheckedListBox _clbGrows        = null!;
    private readonly List<GlowGrow> _glows = new();
    private readonly List<GlowGrow> _grows = new();

    private DataGridView _gridActionItems = null!;
    private ComboBox     _cboAiFilter     = null!;
    private Label        _lblAiCount      = null!;

    private DataGridView _gridMentions = null!;

    private readonly Dictionary<MeetingNoteCategory, RichTextBox> _noteBoxes = new();

    private Panel _checklistContainer = null!;
    private readonly List<ChecklistRow> _checklistRows = new();
    private sealed record ChecklistRow(int QuestionId, ChecklistValueType ValueType, Control AnswerControl);

    public MeetingForm(int personId, DateTime meetingDate, int? existingMeetingId = null)
    {
        _personId    = personId;
        _meetingDate = meetingDate;
        _meetingId   = existingMeetingId;
        BuildUI();
        _ = LoadAsync();
    }

    private void BuildUI()
    {
        Text = "1:1 Meeting";
        Size = new Size(1800, 860);
        MinimumSize = new Size(1300, 680);
        FormBorderStyle = FormBorderStyle.Sizable;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 14f);
        BackColor = Color.FromArgb(245, 247, 250);

        Controls.Add(BuildNotesTabs());
        Controls.Add(BuildBottomSeparator());
        Controls.Add(BuildBottomPanel());
        Controls.Add(BuildRightSeparator());
        Controls.Add(BuildRightPanel());
        Controls.Add(BuildFooter());
        Controls.Add(BuildHeader());
    }

    private Panel BuildHeader()
    {
        var pnl = new Panel
        {
            Dock = DockStyle.Top,
            Height = 78,
            BackColor = Color.FromArgb(30, 58, 95),
            Padding = new Padding(16, 0, 16, 0)
        };
        _lblName = new Label
        {
            Text = "Loading…",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 21f, FontStyle.Bold),
            Dock = DockStyle.Left,
            AutoSize = false,
            Width = 720,
            TextAlign = ContentAlignment.MiddleLeft
        };
        _lblDate = new Label
        {
            Text = _meetingDate.ToString("MMMM d, yyyy"),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 21f, FontStyle.Bold),
            Dock = DockStyle.Right,
            AutoSize = false,
            Width = 330,
            TextAlign = ContentAlignment.MiddleRight
        };
        pnl.Controls.Add(_lblDate);
        pnl.Controls.Add(_lblName);
        return pnl;
    }

    private Panel BuildFooter()
    {
        var pnl = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 72,
            BackColor = Color.White,
            Padding = new Padding(12, 12, 12, 12)
        };
        var btnSave = MakeFooterButton("Save Meeting", Color.FromArgb(41, 128, 185));
        btnSave.Click += async (_, _) => await SaveAsync();
        var btnClose = MakeFooterButton("Close", Color.FromArgb(127, 140, 141));
        btnClose.DialogResult = DialogResult.OK;
        pnl.Controls.Add(btnSave);
        pnl.Controls.Add(btnClose);
        return pnl;
    }

    private Panel BuildRightSeparator() =>
        new() { Dock = DockStyle.Right, Width = 1, BackColor = Color.FromArgb(210, 215, 220) };

    private Panel BuildRightPanel()
    {
        var pnl = new Panel
        {
            Dock = DockStyle.Right,
            Width = 440,
            BackColor = Color.White,
            Padding = new Padding(6)
        };
        var tbl = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 4
        };
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 39));
        tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 39));
        tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

        _lblGlowsHeader = MakeSectionLabel("Glows", Color.FromArgb(39, 174, 96));
        _lblGrowsHeader  = MakeSectionLabel("Grows",  Color.FromArgb(192, 57, 43));
        _clbGlows        = MakeCheckedListBox();
        _clbGrows        = MakeCheckedListBox();

        _clbGlows.MouseDoubleClick += (s, e) => OpenGlowGrowDetail(_clbGlows, _glows, e.Location);
        _clbGrows.MouseDoubleClick  += (s, e) => OpenGlowGrowDetail(_clbGrows,  _grows,  e.Location);

        tbl.Controls.Add(_lblGlowsHeader, 0, 0);
        tbl.Controls.Add(_clbGlows,       0, 1);
        tbl.Controls.Add(_lblGrowsHeader,  0, 2);
        tbl.Controls.Add(_clbGrows,        0, 3);
        pnl.Controls.Add(tbl);
        return pnl;
    }

    private Panel BuildBottomSeparator() =>
        new() { Dock = DockStyle.Bottom, Height = 1, BackColor = Color.FromArgb(210, 215, 220) };

    private Panel BuildBottomPanel()
    {
        var pnl = new Panel { Dock = DockStyle.Bottom, Height = 320, BackColor = Color.White };

        var tabs = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 14f) };
        tabs.TabPages.Add(BuildActionItemsTab());
        tabs.TabPages.Add(BuildMentionsTab());
        pnl.Controls.Add(tabs);
        return pnl;
    }

    private TabPage BuildActionItemsTab()
    {
        var page = new TabPage("Action Items");

        var toolbar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 54,
            BackColor = Color.FromArgb(248, 249, 250),
            Padding = new Padding(6, 6, 6, 6)
        };
        var flow = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };

        var btnAdd = new Button
        {
            Text = "+ Add Action Item",
            Height = 40,
            AutoSize = true,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(39, 174, 96),
            ForeColor = Color.White,
            Cursor = Cursors.Hand,
            Padding = new Padding(12, 0, 12, 0)
        };
        btnAdd.FlatAppearance.BorderSize = 0;
        btnAdd.Click += async (_, _) => await AddActionItemAsync();

        var btnComplete = new Button
        {
            Text = "Mark Complete",
            Height = 40,
            AutoSize = true,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(41, 128, 185),
            ForeColor = Color.White,
            Cursor = Cursors.Hand,
            Margin = new Padding(6, 0, 0, 0),
            Padding = new Padding(12, 0, 12, 0)
        };
        btnComplete.FlatAppearance.BorderSize = 0;
        btnComplete.Click += async (_, _) => await CompleteActionItemAsync();

        var btnDelete = new Button
        {
            Text = "Delete",
            Height = 40,
            AutoSize = true,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(192, 57, 43),
            ForeColor = Color.White,
            Cursor = Cursors.Hand,
            Margin = new Padding(6, 0, 0, 0),
            Padding = new Padding(12, 0, 12, 0)
        };
        btnDelete.FlatAppearance.BorderSize = 0;
        btnDelete.Click += async (_, _) => await DeleteActionItemAsync();

        _cboAiFilter = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Width = 150,
            Margin = new Padding(12, 1, 0, 0)
        };
        _cboAiFilter.Items.AddRange(new object[] { "Open Only", "All" });
        _cboAiFilter.SelectedIndex = 0;
        _cboAiFilter.SelectedIndexChanged += async (_, _) => await LoadActionItemsAsync();

        _lblAiCount = new Label
        {
            AutoSize = true,
            TextAlign = ContentAlignment.MiddleLeft,
            Margin = new Padding(12, 6, 0, 0),
            ForeColor = Color.FromArgb(100, 100, 100)
        };

        flow.Controls.AddRange(new Control[] { btnAdd, btnComplete, btnDelete, _cboAiFilter, _lblAiCount });
        toolbar.Controls.Add(flow);

        _gridActionItems = BuildGrid(
            ("Added",       120),
            ("Assigned To", 140),
            ("Description", 0),
            ("Due Date",    135));
        _gridActionItems.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        page.Controls.Add(_gridActionItems);
        page.Controls.Add(toolbar);
        return page;
    }

    private TabPage BuildMentionsTab()
    {
        var page = new TabPage("Mentions");

        var infoLabel = new Label
        {
            Text = "Open action items from other meetings that tag this person with @",
            Dock = DockStyle.Top,
            Height = 36,
            ForeColor = Color.FromArgb(100, 100, 100),
            Font = new Font("Segoe UI", 13f, FontStyle.Italic),
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(6, 0, 0, 0)
        };

        _gridMentions = BuildGrid(
            ("Their Meeting Person", 240),
            ("Description",         0),
            ("Due Date",            135));
        _gridMentions.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        page.Controls.Add(_gridMentions);
        page.Controls.Add(infoLabel);
        return page;
    }

    private Control BuildNotesTabs()
    {
        var tabDefs = new (string Title, MeetingNoteCategory? Cat, Color Color)[]
        {
            ("Project Notes",    MeetingNoteCategory.ProjectNotes,    Color.FromArgb(41,  128, 185)),
            ("Career Updates",   MeetingNoteCategory.CareerUpdates,   Color.FromArgb(142, 68,  173)),
            ("Training Updates", MeetingNoteCategory.TrainingUpdates, Color.FromArgb(22,  160, 133)),
            ("General Notes",    MeetingNoteCategory.GlowsGrows,      Color.FromArgb(211, 84,  0)),
            ("Checklist",        null,                                Color.FromArgb(52,  73,  94)),
        };

        var colors = tabDefs.Select(t => t.Color).ToArray();

        var tabs = new TabControl
        {
            Dock     = DockStyle.Fill,
            DrawMode = TabDrawMode.OwnerDrawFixed,
            SizeMode = TabSizeMode.Fixed,
            ItemSize = new Size(240, 40),
            Font     = new Font("Segoe UI", 13f, FontStyle.Bold),
            Padding  = new Point(0, 4)
        };

        foreach (var (title, cat, _) in tabDefs)
        {
            var page = new TabPage(title) { BackColor = Color.White, UseVisualStyleBackColor = false };
            if (cat.HasValue)
            {
                var rtb = new RichTextBox
                {
                    Dock        = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    ScrollBars  = RichTextBoxScrollBars.Vertical,
                    Font        = new Font("Segoe UI", 13f),
                    BackColor   = Color.White,
                    Padding     = new Padding(10)
                };
                _noteBoxes[cat.Value] = rtb;
                page.Controls.Add(rtb);
            }
            else
            {
                page.Controls.Add(BuildChecklistTab());
            }
            tabs.TabPages.Add(page);
        }

        tabs.DrawItem += (sender, e) =>
        {
            var tc         = (TabControl)sender!;
            var isSelected = e.Index == tc.SelectedIndex;
            var c          = colors[e.Index];
            var bgColor    = isSelected ? c
                : Color.FromArgb((int)(c.R * 0.6f), (int)(c.G * 0.6f), (int)(c.B * 0.6f));

            using var bg   = new SolidBrush(bgColor);
            e.Graphics.FillRectangle(bg, e.Bounds);

            using var fg   = new SolidBrush(Color.White);
            var style      = isSelected ? FontStyle.Bold : FontStyle.Regular;
            using var font = new Font(tabs.Font.FontFamily, tabs.Font.Size, style);
            var sf         = new StringFormat
            {
                Alignment     = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming      = StringTrimming.EllipsisCharacter
            };
            e.Graphics.DrawString(tc.TabPages[e.Index].Text, font, fg, (RectangleF)e.Bounds, sf);
        };

        tabs.SelectedIndexChanged += (_, _) => tabs.Invalidate();

        return tabs;
    }

    private Panel BuildChecklistTab()
    {
        var outer = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };

        var hdr = new Panel
        {
            Dock      = DockStyle.Top,
            Height    = 40,
            BackColor = Color.FromArgb(52, 73, 94)
        };
        var hdrTbl = new TableLayoutPanel { Dock = DockStyle.Fill };
        hdrTbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        hdrTbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
        hdrTbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260));
        hdrTbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        hdrTbl.Controls.Add(MakeHdrLabel("Question"),  0, 0);
        hdrTbl.Controls.Add(MakeHdrLabel("Frequency"), 1, 0);
        hdrTbl.Controls.Add(MakeHdrLabel("Answer"),    2, 0);
        hdr.Controls.Add(hdrTbl);

        _checklistContainer = new Panel
        {
            Dock        = DockStyle.Fill,
            AutoScroll  = true,
            BackColor   = Color.White
        };

        outer.Controls.Add(_checklistContainer);
        outer.Controls.Add(hdr);
        return outer;
    }

    private static Label MakeHdrLabel(string text) => new()
    {
        Text      = text,
        ForeColor = Color.White,
        Font      = new Font("Segoe UI", 12f, FontStyle.Bold),
        Dock      = DockStyle.Fill,
        TextAlign = ContentAlignment.MiddleCenter
    };

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
            var q       = a.Question;
            var rowH    = q.ValueType == ChecklistValueType.Text ? 72 : 54;
            var rowPnl  = new Panel
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
                    Format      = DateTimePickerFormat.Short,
                    Font        = new Font("Segoe UI", 13f),
                    ShowCheckBox = true,
                    Checked     = existing != null
                };
                if (DateTime.TryParse(existing, out var dv)) dtp.Value = dv;
                return dtp;

            default: // Text
                return new TextBox
                {
                    Font  = new Font("Segoe UI", 13f),
                    Text  = existing ?? ""
                };
        }
    }

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

    private async Task AddActionItemAsync()
    {
        var meetingId = await EnsureMeetingSavedAsync();

        using var form = new AddActionItemForm(meetingId, _personId, _personDisplayName, _meetingDate);
        if (form.ShowDialog(this) == DialogResult.OK)
            await LoadActionItemsAsync();
    }

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

    private async Task SaveChecklistAsync(int meetingId)
    {
        if (_checklistRows.Count == 0) return;

        await using var ctx = DbFactory.Create();
        var qIds    = _checklistRows.Select(r => r.QuestionId).ToList();
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

    private static DataGridView BuildGrid(params (string Header, int Width)[] columns)
    {
        var dgv = new DataGridView { Dock = DockStyle.Fill };
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
        dgv.ColumnHeadersHeight = 39;
        dgv.RowTemplate.Height  = 36;
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 13f);
        dgv.GridColor = Color.FromArgb(220, 230, 240);
        dgv.BorderStyle = BorderStyle.None;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.BackgroundColor = Color.White;

        foreach (var (header, width) in columns)
        {
            var col = new DataGridViewTextBoxColumn { HeaderText = header };
            if (width > 0) col.Width = width;
            dgv.Columns.Add(col);
        }
        return dgv;
    }

    private static Label MakeSectionLabel(string text, Color color) => new()
    {
        Text = text,
        Font = new Font("Segoe UI", 14f, FontStyle.Bold),
        ForeColor = color,
        Dock = DockStyle.Fill,
        TextAlign = ContentAlignment.BottomLeft,
        Padding = new Padding(2, 0, 0, 2)
    };

    private static CheckedListBox MakeCheckedListBox() => new()
    {
        Dock = DockStyle.Fill,
        BorderStyle = BorderStyle.FixedSingle,
        CheckOnClick = true,
        Font = new Font("Segoe UI", 14f)
    };

    private static Button MakeFooterButton(string text, Color back)
    {
        var btn = new Button
        {
            Text = text,
            Width = 180,
            Height = 48,
            Dock = DockStyle.Right,
            FlatStyle = FlatStyle.Flat,
            BackColor = back,
            ForeColor = Color.White,
            Cursor = Cursors.Hand
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }
}
