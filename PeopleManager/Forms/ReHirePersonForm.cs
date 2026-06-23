using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for re-hiring a previously separated employee, capturing a new start date and job title.
/// Creates a new employment period and job title record.
/// </summary>
public partial class ReHirePersonForm : Form
{
    private readonly int _personId;
    private readonly string _personName;

    /// <summary>Initialises the re-hire form for the specified person.</summary>
    /// <param name="personId">The person being re-hired.</param>
    /// <param name="personName">Display name shown at the top of the form.</param>
    public ReHirePersonForm() : this(0, "") { }

    public ReHirePersonForm(int personId, string personName)
    {
        _personId   = personId;
        _personName = personName;
        InitializeComponent();
        _lblPersonName.Text = _personName;
    }

    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(_txtJobTitle.Text))
        {
            MessageBox.Show("Job Title is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        await using var ctx = DbFactory.Create();

        ctx.PersonEmploymentPeriods.Add(new PersonEmploymentPeriod
        {
            PersonId = _personId,
            HireDate = _dtpHireDate.Value.Date
        });

        ctx.PersonJobTitles.Add(new PersonJobTitle
        {
            PersonId      = _personId,
            Title         = _txtJobTitle.Text.Trim(),
            EffectiveDate = _dtpHireDate.Value.Date
        });

        var person = await ctx.People.FindAsync(_personId);
        person!.IsActive = true;

        await ctx.SaveChangesAsync();
    }

    private async void BtnReHire_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
