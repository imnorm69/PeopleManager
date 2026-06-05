using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

public class ReHirePersonForm : Form
{
    private readonly int _personId;
    private readonly string _personName;

    private DateTimePicker _dtpHireDate = null!;
    private TextBox _txtJobTitle = null!;

    public ReHirePersonForm(int personId, string personName)
    {
        _personId   = personId;
        _personName = personName;
        BuildUI();
    }

    private void BuildUI()
    {
        Text = "Re-hire Employee";
        Size = new Size(420, 220);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 9f);
        BackColor = Color.White;

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20),
            ColumnCount = 2,
            RowCount = 4
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        // Person name
        var lblPerson = new Label
        {
            Text = _personName,
            Font = new Font("Segoe UI", 11f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 58, 95),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        };
        layout.SetColumnSpan(lblPerson, 2);
        layout.Controls.Add(lblPerson, 0, 0);

        // Hire date
        _dtpHireDate = new DateTimePicker
        {
            Dock = DockStyle.Fill,
            Format = DateTimePickerFormat.Short,
            Value = DateTime.Today
        };
        layout.Controls.Add(MakeLabel("New Start Date *"), 0, 1);
        layout.Controls.Add(_dtpHireDate, 1, 1);

        // Job title
        _txtJobTitle = new TextBox { Dock = DockStyle.Fill };
        layout.Controls.Add(MakeLabel("Job Title *"), 0, 2);
        layout.Controls.Add(_txtJobTitle, 1, 2);

        // Buttons
        var btnPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 6, 0, 0)
        };
        layout.SetColumnSpan(btnPanel, 2);

        var btnReHire = new Button
        {
            Text = "Re-hire",
            Width = 80,
            DialogResult = DialogResult.OK,
            BackColor = Color.FromArgb(39, 174, 96),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        btnReHire.FlatAppearance.BorderSize = 0;
        btnReHire.Click += async (_, _) => await SaveAsync();

        var btnCancel = new Button { Text = "Cancel", Width = 80, DialogResult = DialogResult.Cancel };
        btnPanel.Controls.AddRange(new Control[] { btnCancel, btnReHire });
        layout.Controls.Add(btnPanel, 0, 3);

        AcceptButton = btnReHire;
        CancelButton = btnCancel;
        Controls.Add(layout);
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

        // New employment period
        ctx.PersonEmploymentPeriods.Add(new PersonEmploymentPeriod
        {
            PersonId = _personId,
            HireDate = _dtpHireDate.Value.Date
        });

        // New job title effective on hire date
        ctx.PersonJobTitles.Add(new PersonJobTitle
        {
            PersonId      = _personId,
            Title         = _txtJobTitle.Text.Trim(),
            EffectiveDate = _dtpHireDate.Value.Date
        });

        // Mark person active again
        var person = await ctx.People.FindAsync(_personId);
        person!.IsActive = true;

        await ctx.SaveChangesAsync();
    }

    private static Label MakeLabel(string text) => new()
    {
        Text = text,
        TextAlign = ContentAlignment.MiddleRight,
        Dock = DockStyle.Fill
    };
}
