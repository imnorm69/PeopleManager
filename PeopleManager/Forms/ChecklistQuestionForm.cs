using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for creating or editing a checklist question, including its description and answer value type.
/// </summary>
public class ChecklistQuestionForm : Form
{
    private readonly int? _questionId;
    private TextBox  _txtDescription = null!;
    private ComboBox _cboValueType   = null!;

    /// <summary>Initialises the form in create mode when <paramref name="questionId"/> is null, or edit mode otherwise.</summary>
    /// <param name="questionId">The question to edit, or null to create a new one.</param>
    public ChecklistQuestionForm(int? questionId)
    {
        _questionId = questionId;
        BuildUI();
        if (questionId.HasValue) _ = LoadAsync(questionId.Value);
    }

    private void BuildUI()
    {
        Text = _questionId.HasValue ? "Edit Question" : "New Checklist Question";
        Size = new Size(700, 285);
        FormBorderStyle = FormBorderStyle.Sizable;
        MinimumSize = new Size(560, 255);
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 14f);
        BackColor = Color.White;

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16),
            ColumnCount = 2,
            RowCount = 3
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 63));

        _txtDescription = new TextBox { Dock = DockStyle.Fill, MaxLength = 500 };
        _cboValueType   = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };

        foreach (var v in Enum.GetValues<ChecklistValueType>())
            _cboValueType.Items.Add(v.ToString());
        _cboValueType.SelectedIndex = 0;

        layout.Controls.Add(new Label { Text = "Description *", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 0);
        layout.Controls.Add(_txtDescription, 1, 0);
        layout.Controls.Add(new Label { Text = "Value Type",    TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 1);
        layout.Controls.Add(_cboValueType,   1, 1);

        var btnPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, Padding = new Padding(0, 6, 0, 0) };
        layout.SetColumnSpan(btnPanel, 2);
        var btnSave   = new Button { Text = "Save",   Width = 120, DialogResult = DialogResult.OK };
        var btnCancel = new Button { Text = "Cancel", Width = 120, DialogResult = DialogResult.Cancel };
        btnSave.Click += async (_, _) => await SaveAsync();
        btnPanel.Controls.AddRange(new Control[] { btnCancel, btnSave });
        layout.Controls.Add(btnPanel, 0, 2);

        AcceptButton = btnSave;
        CancelButton = btnCancel;
        Controls.Add(layout);
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
}
