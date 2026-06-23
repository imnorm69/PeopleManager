using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for creating a new action item within a 1:1 meeting.
/// Supports @-mention autocomplete to tag other people in the description.
/// </summary>
public partial class AddActionItemForm : Form
{
    private readonly int      _meetingId;
    private readonly int      _personId;
    private readonly string   _personDisplayName;
    private readonly DateTime _meetingDate;

    private List<(int Id, string FullName)> _mentionPeople = new();
    private ToolStripDropDown? _mentionDrop;
    private ListBox            _mentionList  = null!;
    private int                _mentionStart = -1;
    private bool               _inserting    = false;

    /// <summary>Initialises the add action item form.</summary>
    /// <param name="meetingId">The meeting this action item belongs to.</param>
    /// <param name="personId">The direct report the action item concerns.</param>
    /// <param name="personDisplayName">Display name shown in the banner and assignee dropdown.</param>
    /// <param name="meetingDate">Used as the created date and default due date basis.</param>
    public AddActionItemForm() : this(0, 0, "", DateTime.Today) { }

    public AddActionItemForm(int meetingId, int personId, string personDisplayName, DateTime meetingDate)
    {
        _meetingId         = meetingId;
        _personId          = personId;
        _personDisplayName = personDisplayName;
        _meetingDate       = meetingDate;
        InitializeComponent();
        _lblBanner.Text = $"Meeting with {_personDisplayName}  ·  {_meetingDate:MMMM d, yyyy}";
        _cboAssignee.Items.Add("Manager");
        _cboAssignee.Items.Add(_personDisplayName);
        _cboAssignee.SelectedIndex = 0;
        _dtpDue.Value = _meetingDate.AddDays(14);
        InitMentionDropdown();
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            _ = LoadPeopleAsync();
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

    private void RtbDesc_Leave(object? sender, EventArgs e) { _mentionDrop?.Close(); }
    private async void BtnAdd_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
