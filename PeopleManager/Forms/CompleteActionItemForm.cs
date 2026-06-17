using PeopleManager.Data;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for marking an action item as complete. Displays the item description,
/// captures a completion date and optional notes, and optionally links the completion to a meeting.
/// </summary>
public class CompleteActionItemForm : Form
{
    private readonly int  _actionItemId;
    private readonly int? _meetingId;

    private Label          _lblDescription = null!;
    private DateTimePicker _dtpCompleted   = null!;
    private RichTextBox    _rtbNotes       = null!;

    /// <summary>Initialises the completion form.</summary>
    /// <param name="actionItemId">The action item being marked complete.</param>
    /// <param name="meetingId">The meeting to link the completion to, or null if completed outside a meeting.</param>
    public CompleteActionItemForm(int actionItemId, int? meetingId = null)
    {
        _actionItemId = actionItemId;
        _meetingId    = meetingId;
        BuildUI();
        _ = LoadAsync();
    }

    private void BuildUI()
    {
        Text = "Mark Action Item Complete";
        Size = new Size(700, 450);
        MinimumSize = new Size(600, 390);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 14f);
        BackColor = Color.White;

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(14),
            ColumnCount = 2,
            RowCount = 4
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 69));   // description
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51));   // completed date
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));   // notes
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));   // buttons

        _lblDescription = new Label
        {
            Dock = DockStyle.Fill,
            AutoSize = false,
            TextAlign = ContentAlignment.TopLeft,
            Font = new Font("Segoe UI", 14f, FontStyle.Italic),
            ForeColor = Color.FromArgb(60, 60, 60),
            Padding = new Padding(2)
        };
        layout.Controls.Add(new Label { Text = "Action Item", TextAlign = ContentAlignment.TopRight, Dock = DockStyle.Fill, Padding = new Padding(0, 3, 4, 0) }, 0, 0);
        layout.Controls.Add(_lblDescription, 1, 0);

        _dtpCompleted = new DateTimePicker
        {
            Dock = DockStyle.Fill,
            Format = DateTimePickerFormat.Short,
            Value = DateTime.Today
        };
        layout.Controls.Add(new Label { Text = "Completed", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, Padding = new Padding(0, 0, 4, 0) }, 0, 1);
        layout.Controls.Add(_dtpCompleted, 1, 1);

        _rtbNotes = new RichTextBox
        {
            Dock = DockStyle.Fill,
            ScrollBars = RichTextBoxScrollBars.Vertical,
            Font = new Font("Segoe UI", 14f)
        };
        layout.Controls.Add(new Label { Text = "Notes\n(optional)", TextAlign = ContentAlignment.TopRight, Dock = DockStyle.Fill, Padding = new Padding(0, 3, 4, 0) }, 0, 2);
        layout.Controls.Add(_rtbNotes, 1, 2);

        var btnPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, Padding = new Padding(0, 6, 0, 0) };
        layout.SetColumnSpan(btnPanel, 2);
        var btnSave   = new Button { Text = "Mark Complete", Width = 165, DialogResult = DialogResult.OK };
        var btnCancel = new Button { Text = "Cancel",        Width = 120, DialogResult = DialogResult.Cancel };
        btnSave.Click += async (_, _) => await SaveAsync();
        btnPanel.Controls.AddRange(new Control[] { btnCancel, btnSave });
        layout.Controls.Add(btnPanel, 0, 3);

        AcceptButton = btnSave;
        CancelButton = btnCancel;

        Controls.Add(layout);
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
}
