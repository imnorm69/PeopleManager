using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

public class AddActionItemForm : Form
{
    private readonly int      _meetingId;
    private readonly int      _personId;
    private readonly string   _personDisplayName;
    private readonly DateTime _meetingDate;

    private RichTextBox    _rtbDesc     = null!;
    private ComboBox       _cboAssignee = null!;
    private DateTimePicker _dtpDue      = null!;

    private List<(int Id, string FullName)> _mentionPeople = new();
    private ToolStripDropDown? _mentionDrop;
    private ListBox            _mentionList  = null!;
    private int                _mentionStart = -1;
    private bool               _inserting    = false;

    public AddActionItemForm(int meetingId, int personId, string personDisplayName, DateTime meetingDate)
    {
        _meetingId          = meetingId;
        _personId           = personId;
        _personDisplayName  = personDisplayName;
        _meetingDate        = meetingDate;
        BuildUI();
        _ = LoadPeopleAsync();
    }

    private void BuildUI()
    {
        Text = "Add Action Item";
        Size = new Size(740, 495);
        MinimumSize = new Size(620, 420);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 14f);
        BackColor = Color.White;

        var banner = new Panel
        {
            Dock = DockStyle.Top,
            Height = 45,
            BackColor = Color.FromArgb(30, 58, 95),
            Padding = new Padding(12, 0, 0, 0)
        };
        banner.Controls.Add(new Label
        {
            Text = $"Meeting with {_personDisplayName}  ·  {_meetingDate:MMMM d, yyyy}",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 13f),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        });

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(14),
            ColumnCount = 2,
            RowCount = 4
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // description
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51)); // assigned to
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51)); // due date
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // buttons

        _rtbDesc = new RichTextBox
        {
            Dock = DockStyle.Fill,
            ScrollBars = RichTextBoxScrollBars.Vertical,
            Font = new Font("Segoe UI", 14f),
            AcceptsTab = false
        };
        _rtbDesc.KeyDown     += OnDescKeyDown;
        _rtbDesc.TextChanged += OnDescTextChanged;
        _rtbDesc.Leave       += (_, _) => _mentionDrop?.Close();

        layout.Controls.Add(new Label { Text = "Description *", TextAlign = ContentAlignment.TopRight, Dock = DockStyle.Fill, Padding = new Padding(0, 5, 4, 0) }, 0, 0);
        layout.Controls.Add(_rtbDesc, 1, 0);

        _cboAssignee = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
        _cboAssignee.Items.Add("Manager");
        _cboAssignee.Items.Add(_personDisplayName);
        _cboAssignee.SelectedIndex = 0;
        layout.Controls.Add(new Label { Text = "Assign to", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 1);
        layout.Controls.Add(_cboAssignee, 1, 1);

        _dtpDue = new DateTimePicker
        {
            Dock = DockStyle.Fill,
            Format = DateTimePickerFormat.Short,
            Value = _meetingDate.AddDays(14)
        };
        layout.Controls.Add(new Label { Text = "Due Date", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 2);
        layout.Controls.Add(_dtpDue, 1, 2);

        var btnPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, Padding = new Padding(0, 6, 0, 0) };
        layout.SetColumnSpan(btnPanel, 2);
        var btnAdd    = new Button { Text = "Add",    Width = 120, DialogResult = DialogResult.OK };
        var btnCancel = new Button { Text = "Cancel", Width = 120, DialogResult = DialogResult.Cancel };
        btnAdd.Click += async (_, _) => await SaveAsync();
        btnPanel.Controls.AddRange(new Control[] { btnCancel, btnAdd });
        layout.Controls.Add(btnPanel, 0, 3);

        AcceptButton = btnAdd;
        CancelButton = btnCancel;

        InitMentionDropdown();

        Controls.Add(layout);
        Controls.Add(banner);
    }

    private void InitMentionDropdown()
    {
        _mentionList = new ListBox
        {
            BorderStyle = BorderStyle.None,
            Font = new Font("Segoe UI", 14f),
            Width = 360,
            IntegralHeight = true
        };
        _mentionList.Click += (_, _) => CommitMention();

        var host = new ToolStripControlHost(_mentionList)
        {
            Padding  = Padding.Empty,
            Margin   = Padding.Empty,
            AutoSize = false,
            Size     = new Size(360, 180)
        };

        _mentionDrop = new ToolStripDropDown { Padding = Padding.Empty, AutoClose = false };
        _mentionDrop.Items.Add(host);
    }

    private void OnDescTextChanged(object? sender, EventArgs e)
    {
        if (_inserting) return;

        var pos = _rtbDesc.SelectionStart;
        if (pos == 0) { _mentionDrop?.Close(); return; }

        var text = _rtbDesc.Text[..pos];
        var atIdx = text.LastIndexOf('@');
        if (atIdx < 0) { _mentionDrop?.Close(); return; }

        var fragment = text[(atIdx + 1)..];
        if (fragment.Contains(' ')) { _mentionDrop?.Close(); return; }

        _mentionStart = atIdx;

        var matches = _mentionPeople
            .Where(p => fragment.Length == 0 ||
                        p.FullName.StartsWith(fragment, StringComparison.OrdinalIgnoreCase) ||
                        p.FullName.Contains(" " + fragment, StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p.FullName)
            .Take(8)
            .ToList();

        if (matches.Count == 0) { _mentionDrop?.Close(); return; }

        _mentionList.Items.Clear();
        foreach (var m in matches) _mentionList.Items.Add(m.FullName);
        _mentionList.SelectedIndex = 0;

        if (_mentionDrop!.Items[0] is ToolStripControlHost h)
            h.Size = new Size(360, Math.Min(matches.Count * _mentionList.ItemHeight, 240));

        var charPt   = _rtbDesc.GetPositionFromCharIndex(atIdx);
        var screenPt = _rtbDesc.PointToScreen(new Point(charPt.X, charPt.Y + _rtbDesc.Font.Height + 4));
        _mentionDrop.Show(screenPt);
    }

    private void OnDescKeyDown(object? sender, KeyEventArgs e)
    {
        if (_mentionDrop?.Visible != true) return;

        switch (e.KeyCode)
        {
            case Keys.Tab:
            case Keys.Return:
                CommitMention();
                e.Handled = true;
                e.SuppressKeyPress = true;
                break;
            case Keys.Down:
                if (_mentionList.SelectedIndex < _mentionList.Items.Count - 1)
                    _mentionList.SelectedIndex++;
                e.Handled = true;
                break;
            case Keys.Up:
                if (_mentionList.SelectedIndex > 0)
                    _mentionList.SelectedIndex--;
                e.Handled = true;
                break;
            case Keys.Escape:
                _mentionDrop.Close();
                e.Handled = true;
                break;
        }
    }

    private void CommitMention()
    {
        if (_mentionList.SelectedItem is not string name) return;
        if (_mentionStart < 0) return;

        _inserting = true;
        var curPos = _rtbDesc.SelectionStart;
        _rtbDesc.SelectionStart  = _mentionStart;
        _rtbDesc.SelectionLength = curPos - _mentionStart;
        _rtbDesc.SelectedText    = $"@{name} ";
        _inserting = false;

        _mentionDrop?.Close();
        _mentionStart = -1;
        _rtbDesc.Focus();
    }

    private async Task LoadPeopleAsync()
    {
        await using var ctx = DbFactory.Create();
        var people = await ctx.People
            .Where(p => p.IsActive && p.PersonId != _personId)
            .OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
            .Select(p => new { p.PersonId, FullName = p.FirstName + " " + p.LastName })
            .ToListAsync();

        _mentionPeople = people.Select(p => (p.PersonId, p.FullName)).ToList();
    }

    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(_rtbDesc.Text))
        {
            MessageBox.Show("Description is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        var assignee = _cboAssignee.SelectedIndex == 0
            ? ActionItemAssignee.Me
            : ActionItemAssignee.Person;

        await using var ctx = DbFactory.Create();
        ctx.ActionItems.Add(new ActionItem
        {
            PersonId           = _personId,
            CreatedInMeetingId = _meetingId,
            Description        = _rtbDesc.Text.Trim(),
            AssignedTo         = assignee,
            CreatedDate        = _meetingDate,
            DueDate            = _dtpDue.Value.Date,
            IsComplete         = false
        });
        await ctx.SaveChangesAsync();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) _mentionDrop?.Dispose();
        base.Dispose(disposing);
    }
}
