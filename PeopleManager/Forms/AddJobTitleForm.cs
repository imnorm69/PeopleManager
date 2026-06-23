using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for adding a new job title entry to a person's title history.
/// </summary>
public partial class AddJobTitleForm : Form
{
    private readonly int _personId;

    /// <summary>Initialises the form for the specified person.</summary>
    /// <param name="personId">The person receiving the new title.</param>
    public AddJobTitleForm() : this(0) { }

    public AddJobTitleForm(int personId)
    {
        _personId = personId;
        InitializeComponent();
    }

    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(_txtTitle.Text))
        {
            MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }
        await using var ctx = DbFactory.Create();
        ctx.PersonJobTitles.Add(new PersonJobTitle
        {
            PersonId      = _personId,
            Title         = _txtTitle.Text.Trim(),
            EffectiveDate = _dtpDate.Value.Date
        });
        await ctx.SaveChangesAsync();
    }

    private async void BtnSave_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
