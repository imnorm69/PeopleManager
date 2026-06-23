using PeopleManager.Data;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for marking an action item as complete. Displays the item description,
/// captures a completion date and optional notes, and optionally links the completion to a meeting.
/// </summary>
public partial class CompleteActionItemForm : Form
{
    private readonly int  _actionItemId;
    private readonly int? _meetingId;

    /// <summary>Initialises the completion form.</summary>
    /// <param name="actionItemId">The action item being marked complete.</param>
    /// <param name="meetingId">The meeting to link the completion to, or null if completed outside a meeting.</param>
    public CompleteActionItemForm() : this(0) { }

    public CompleteActionItemForm(int actionItemId, int? meetingId = null)
    {
        _actionItemId = actionItemId;
        _meetingId    = meetingId;
        InitializeComponent();
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            _ = LoadAsync();
    }

    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();
        var item = await ctx.ActionItems.FindAsync(_actionItemId);
        if (item == null) return;

        _lblDescription.Text = item.Description.Length > 120
            ? item.Description[..120] + "…"
            : item.Description;
    }

    private async Task SaveAsync()
    {
        await using var ctx = DbFactory.Create();
        var item = await ctx.ActionItems.FindAsync(_actionItemId);
        if (item == null) return;

        item.IsComplete           = true;
        item.CompletedDate        = _dtpCompleted.Value.Date;
        item.CompletionNotes      = string.IsNullOrWhiteSpace(_rtbNotes.Text) ? null : _rtbNotes.Text.Trim();
        item.CompletedInMeetingId = _meetingId;

        await ctx.SaveChangesAsync();
    }

    private async void BtnSave_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
