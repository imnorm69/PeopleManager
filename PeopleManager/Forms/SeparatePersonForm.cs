using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for recording an employee separation, capturing the date, reason, and optional notes.
/// When reason is "Other", notes are required.
/// </summary>
public class SeparatePersonForm : Form
{
    private readonly int _personId;
    private readonly string _personName;

    private DateTimePicker _dtpSeparation = null!;
    private ComboBox _cboReason = null!;
    private RichTextBox _rtbNotes = null!;
    private Label _lblNotesRequired = null!;
    private Button _btnSeparate = null!;

    /// <summary>Initialises the separation form for the specified person.</summary>
    /// <param name="personId">The person being separated.</param>
    /// <param name="personName">Display name shown at the top of the form.</param>
    public SeparatePersonForm(int personId, string personName)
    {
        _personId   = personId;
        _personName = personName;
        BuildUI();
    }

    private void BuildUI()
    {
        Text = "Separate Employee";
        Size = new Size(680, 510);
        MinimumSize = new Size(600, 450);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 14f);
        BackColor = Color.White;

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20),
            ColumnCount = 2,
            RowCount = 6
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 195));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54));  // person label
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51));  // sep date
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51));  // reason
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));  // notes required hint
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));  // notes
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 63));  // buttons

        var lblPerson = new Label
        {
            Text = _personName,
            Font = new Font("Segoe UI", 16f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 58, 95),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        };
        layout.SetColumnSpan(lblPerson, 2);
        layout.Controls.Add(lblPerson, 0, 0);

        _dtpSeparation = new DateTimePicker
        {
            Dock = DockStyle.Fill,
            Format = DateTimePickerFormat.Short,
            Value = DateTime.Today
        };
        layout.Controls.Add(MakeLabel("Separation Date *"), 0, 1);
        layout.Controls.Add(_dtpSeparation, 1, 1);

        _cboReason = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
        _cboReason.Items.AddRange(new object[]
        {
            "End of Internship",
            "Voluntary Resignation",
            "Termination",
            "Other"
        });
        _cboReason.SelectedIndex = 0;
        _cboReason.SelectedIndexChanged += (_, _) => UpdateNotesRequirement();
        layout.Controls.Add(MakeLabel("Reason *"), 0, 2);
        layout.Controls.Add(_cboReason, 1, 2);

        _lblNotesRequired = new Label
        {
            Text = "",
            ForeColor = Color.FromArgb(192, 57, 43),
            Font = new Font("Segoe UI", 12f, FontStyle.Italic),
            Dock = DockStyle.Fill
        };
        layout.SetColumnSpan(_lblNotesRequired, 2);
        layout.Controls.Add(_lblNotesRequired, 0, 3);

        _rtbNotes = new RichTextBox
        {
            Dock = DockStyle.Fill,
            ScrollBars = RichTextBoxScrollBars.Vertical,
            Font = new Font("Segoe UI", 14f)
        };
        layout.Controls.Add(MakeLabel("Notes", top: true), 0, 4);
        layout.Controls.Add(_rtbNotes, 1, 4);

        var btnPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 6, 0, 0)
        };
        layout.SetColumnSpan(btnPanel, 2);

        _btnSeparate = new Button
        {
            Text = "Separate",
            Width = 135,
            DialogResult = DialogResult.OK,
            BackColor = Color.FromArgb(192, 57, 43),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        _btnSeparate.FlatAppearance.BorderSize = 0;
        _btnSeparate.Click += async (_, _) => await SaveAsync();

        var btnCancel = new Button { Text = "Cancel", Width = 120, DialogResult = DialogResult.Cancel };

        btnPanel.Controls.AddRange(new Control[] { btnCancel, _btnSeparate });
        layout.Controls.Add(btnPanel, 0, 5);

        AcceptButton = _btnSeparate;
        CancelButton = btnCancel;
        Controls.Add(layout);
    }

    private void UpdateNotesRequirement()
    {
        bool otherSelected = _cboReason.SelectedIndex == 3;
        _lblNotesRequired.Text = otherSelected ? "Notes are required when reason is \"Other\"" : "";
    }

    private async Task SaveAsync()
    {
        bool isOther = _cboReason.SelectedIndex == 3;
        if (isOther && string.IsNullOrWhiteSpace(_rtbNotes.Text))
        {
            MessageBox.Show("Notes are required when the reason is \"Other\".",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        var reason = (SeparationReason)_cboReason.SelectedIndex;

        await using var ctx = DbFactory.Create();

        var activePeriod = ctx.PersonEmploymentPeriods
            .Where(p => p.PersonId == _personId && p.SeparationDate == null)
            .OrderByDescending(p => p.HireDate)
            .FirstOrDefault();

        if (activePeriod != null)
        {
            activePeriod.SeparationDate   = _dtpSeparation.Value.Date;
            activePeriod.SeparationReason = reason;
            activePeriod.SeparationNotes  = string.IsNullOrWhiteSpace(_rtbNotes.Text)
                ? null : _rtbNotes.Text.Trim();
        }
        else
        {
            var person = await ctx.People.FindAsync(_personId);
            ctx.PersonEmploymentPeriods.Add(new PersonEmploymentPeriod
            {
                PersonId         = _personId,
                HireDate         = person!.StartDate,
                SeparationDate   = _dtpSeparation.Value.Date,
                SeparationReason = reason,
                SeparationNotes  = string.IsNullOrWhiteSpace(_rtbNotes.Text)
                    ? null : _rtbNotes.Text.Trim()
            });
        }

        var personRecord = await ctx.People.FindAsync(_personId);
        personRecord!.IsActive = false;
        await ctx.SaveChangesAsync();
    }

    private static Label MakeLabel(string text, bool top = false) => new()
    {
        Text = text,
        TextAlign = top ? ContentAlignment.TopRight : ContentAlignment.MiddleRight,
        Dock = DockStyle.Fill,
        Padding = top ? new Padding(0, 4, 4, 0) : Padding.Empty
    };
}
