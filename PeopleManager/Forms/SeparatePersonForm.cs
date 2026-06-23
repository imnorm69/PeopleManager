using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for recording an employee separation, capturing the date, reason, and optional notes.
/// When reason is "Other", notes are required.
/// </summary>
public partial class SeparatePersonForm : Form
{
    private readonly int _personId;
    private readonly string _personName;

    /// <summary>Initialises the separation form for the specified person.</summary>
    /// <param name="personId">The person being separated.</param>
    /// <param name="personName">Display name shown at the top of the form.</param>
    public SeparatePersonForm() : this(0, "") { }

    public SeparatePersonForm(int personId, string personName)
    {
        _personId   = personId;
        _personName = personName;
        InitializeComponent();
        _lblPersonName.Text = _personName;
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

    private void CboReason_SelectedIndexChanged(object? sender, EventArgs e) => UpdateNotesRequirement();
    private async void BtnSeparate_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
