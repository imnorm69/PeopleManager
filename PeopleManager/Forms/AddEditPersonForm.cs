using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for adding a new person (with initial job title) or editing an existing person's basic info.
/// </summary>
public partial class AddEditPersonForm : Form
{
    private readonly int? _personId;

    /// <summary>Initialises the form in add mode when <paramref name="personId"/> is null, or edit mode otherwise.</summary>
    /// <param name="personId">The person to edit, or null to create a new person.</param>
    public AddEditPersonForm() : this((int?)null) { }

    public AddEditPersonForm(int? personId)
    {
        _personId = personId;
        InitializeComponent();

        if (_personId.HasValue)
        {
            Text = "Edit Person";
            Height = 390;
            _txtTitle.Visible = false;
            _lblTitle.Visible = false;
        }

        if (personId.HasValue) _ = LoadAsync(personId.Value);
    }

    private async Task LoadAsync(int id)
    {
        await using var ctx = DbFactory.Create();
        var p = await ctx.People.FindAsync(id);
        if (p == null) return;
        _txtFirst.Text  = p.FirstName;
        _txtLast.Text   = p.LastName;
        _dtpStart.Value = p.StartDate;
    }

    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(_txtFirst.Text) || string.IsNullOrWhiteSpace(_txtLast.Text))
        {
            MessageBox.Show("First Name and Last Name are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }
        if (!_personId.HasValue && string.IsNullOrWhiteSpace(_txtTitle?.Text))
        {
            MessageBox.Show("Job Title is required for a new person.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        await using var ctx = DbFactory.Create();

        if (_personId.HasValue)
        {
            var p = await ctx.People.FindAsync(_personId.Value);
            if (p == null) return;
            p.FirstName = _txtFirst.Text.Trim();
            p.LastName  = _txtLast.Text.Trim();
            p.StartDate = _dtpStart.Value.Date;
        }
        else
        {
            var p = new Person
            {
                FirstName = _txtFirst.Text.Trim(),
                LastName  = _txtLast.Text.Trim(),
                StartDate = _dtpStart.Value.Date,
                IsActive  = true
            };
            p.EmploymentPeriods.Add(new PersonEmploymentPeriod
            {
                HireDate = _dtpStart.Value.Date
            });
            p.JobTitles.Add(new PersonJobTitle
            {
                Title         = _txtTitle.Text.Trim(),
                EffectiveDate = _dtpStart.Value.Date
            });
            ctx.People.Add(p);
        }

        await ctx.SaveChangesAsync();
        DialogResult = DialogResult.OK;
    }

    private async void BtnSave_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
