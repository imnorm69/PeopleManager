using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for adding a new job title or editing an existing one in a person's title history.
/// Pass <paramref name="existingTitleId"/> to open in edit mode.
/// </summary>
public partial class AddJobTitleForm : Form
{
    private readonly int  _personId;
    private readonly int? _existingTitleId;

    public AddJobTitleForm() : this(0) { }

    /// <summary>Opens the form in add mode for the specified person.</summary>
    public AddJobTitleForm(int personId) : this(personId, null) { }

    /// <summary>Opens the form in edit mode for an existing job title record.</summary>
    public AddJobTitleForm(int personId, int? existingTitleId)
    {
        _personId        = personId;
        _existingTitleId = existingTitleId;
        InitializeComponent();
        Text = existingTitleId.HasValue ? "Edit Job Title" : "Add Job Title";
        if (existingTitleId.HasValue) _ = LoadAsync(existingTitleId.Value);
    }

    private async Task LoadAsync(int titleId)
    {
        await using var ctx = DbFactory.Create();
        var jt = await ctx.PersonJobTitles.FindAsync(titleId);
        if (jt == null) return;
        _txtTitle.Text  = jt.Title;
        _dtpDate.Value  = jt.EffectiveDate;
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

        if (_existingTitleId.HasValue)
        {
            var jt = await ctx.PersonJobTitles.FindAsync(_existingTitleId.Value);
            if (jt == null) return;
            jt.Title         = _txtTitle.Text.Trim();
            jt.EffectiveDate = _dtpDate.Value.Date;
        }
        else
        {
            ctx.PersonJobTitles.Add(new PersonJobTitle
            {
                PersonId      = _personId,
                Title         = _txtTitle.Text.Trim(),
                EffectiveDate = _dtpDate.Value.Date
            });
        }

        await ctx.SaveChangesAsync();
    }

    private async void BtnSave_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
