using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for adding a new person (with initial job title) or editing an existing person's basic info.
/// </summary>
public class AddEditPersonForm : Form
{
    private readonly int? _personId;
    private TextBox _txtFirst = null!;
    private TextBox _txtLast = null!;
    private DateTimePicker _dtpStart = null!;
    private TextBox _txtTitle = null!;

    /// <summary>Initialises the form in add mode when <paramref name="personId"/> is null, or edit mode otherwise.</summary>
    /// <param name="personId">The person to edit, or null to create a new person.</param>
    public AddEditPersonForm(int? personId)
    {
        _personId = personId;
        BuildUI();
        if (personId.HasValue) _ = LoadAsync(personId.Value);
    }

    private void BuildUI()
    {
        Text = _personId.HasValue ? "Edit Person" : "Add New Person";
        Size = new Size(620, _personId.HasValue ? 390 : 460);
        FormBorderStyle = FormBorderStyle.FixedDialog;
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
            RowCount = _personId.HasValue ? 5 : 6
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        int row = 0;
        _txtLast  = AddRow(layout, "Last Name *", row++);
        _txtFirst = AddRow(layout, "First Name *", row++);
        _dtpStart = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short, Value = DateTime.Today };
        layout.Controls.Add(MakeLabel("Start Date *"), 0, row);
        layout.Controls.Add(_dtpStart, 1, row++);

        if (!_personId.HasValue)
        {
            _txtTitle = AddRow(layout, "Job Title *", row++);
        }

        var btnPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 8, 0, 0)
        };
        layout.SetColumnSpan(btnPanel, 2);

        var btnSave   = new Button { Text = "Save",   DialogResult = DialogResult.OK,     Width = 120 };
        var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Width = 120 };
        btnSave.Click += async (_, _) => await SaveAsync();
        btnPanel.Controls.AddRange(new Control[] { btnCancel, btnSave });
        layout.Controls.Add(btnPanel, 0, row);

        AcceptButton = btnSave;
        CancelButton = btnCancel;
        Controls.Add(layout);
    }

    private static Label MakeLabel(string text) =>
        new() { Text = text, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill };

    private static TextBox AddRow(TableLayoutPanel layout, string label, int row)
    {
        var tb = new TextBox { Dock = DockStyle.Fill };
        layout.Controls.Add(MakeLabel(label), 0, row);
        layout.Controls.Add(tb, 1, row);
        return tb;
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
}
