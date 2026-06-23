using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for creating or editing a checklist question, including its description and answer value type.
/// </summary>
public partial class ChecklistQuestionForm : Form
{
    private readonly int? _questionId;

    /// <summary>Initialises the form in create mode when <paramref name="questionId"/> is null, or edit mode otherwise.</summary>
    /// <param name="questionId">The question to edit, or null to create a new one.</param>
    public ChecklistQuestionForm() : this((int?)null) { }

    public ChecklistQuestionForm(int? questionId)
    {
        _questionId = questionId;
        InitializeComponent();
        foreach (var v in Enum.GetValues<ChecklistValueType>())
            _cboValueType.Items.Add(v.ToString());
        _cboValueType.SelectedIndex = 0;
        this.Text = _questionId.HasValue ? "Edit Question" : "New Checklist Question";
        if (questionId.HasValue) _ = LoadAsync(questionId.Value);
    }

    private async Task LoadAsync(int id)
    {
        await using var ctx = DbFactory.Create();
        var q = await ctx.ChecklistQuestions.FindAsync(id);
        if (q == null) return;
        _txtDescription.Text        = q.Description;
        _cboValueType.SelectedIndex = (int)q.ValueType;
    }

    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(_txtDescription.Text))
        {
            MessageBox.Show("Description is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        await using var ctx = DbFactory.Create();

        if (_questionId.HasValue)
        {
            var q = await ctx.ChecklistQuestions.FindAsync(_questionId.Value);
            if (q == null) return;
            q.Description = _txtDescription.Text.Trim();
            q.ValueType   = (ChecklistValueType)_cboValueType.SelectedIndex;
        }
        else
        {
            ctx.ChecklistQuestions.Add(new ChecklistQuestion
            {
                Description = _txtDescription.Text.Trim(),
                ValueType   = (ChecklistValueType)_cboValueType.SelectedIndex
            });
        }
        await ctx.SaveChangesAsync();
    }

    private async void BtnSave_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
