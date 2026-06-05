using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

public class AddJobTitleForm : Form
{
    private readonly int _personId;
    private TextBox _txtTitle = null!;
    private DateTimePicker _dtpDate = null!;

    public AddJobTitleForm(int personId)
    {
        _personId = personId;
        BuildUI();
    }

    private void BuildUI()
    {
        Text = "Add Job Title";
        Size = new Size(380, 180);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false; MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 9f);
        BackColor = Color.White;

        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(16), ColumnCount = 2, RowCount = 3 };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        _txtTitle = new TextBox { Dock = DockStyle.Fill };
        _dtpDate  = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short, Value = DateTime.Today };

        layout.Controls.Add(new Label { Text = "Title *", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 0);
        layout.Controls.Add(_txtTitle, 1, 0);
        layout.Controls.Add(new Label { Text = "Effective Date *", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 1);
        layout.Controls.Add(_dtpDate, 1, 1);

        var btnPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, Padding = new Padding(0, 6, 0, 0) };
        layout.SetColumnSpan(btnPanel, 2);
        var btnSave   = new Button { Text = "Save",   DialogResult = DialogResult.OK,     Width = 80 };
        var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Width = 80 };
        btnSave.Click += async (_, _) => await SaveAsync();
        btnPanel.Controls.AddRange(new Control[] { btnCancel, btnSave });
        layout.Controls.Add(btnPanel, 0, 2);

        AcceptButton = btnSave; CancelButton = btnCancel;
        Controls.Add(layout);
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
            PersonId = _personId,
            Title = _txtTitle.Text.Trim(),
            EffectiveDate = _dtpDate.Value.Date
        });
        await ctx.SaveChangesAsync();
    }
}
