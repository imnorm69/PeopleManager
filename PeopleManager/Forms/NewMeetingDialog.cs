using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;

namespace PeopleManager.Forms;

public class NewMeetingDialog : Form
{
    public int      SelectedPersonId   { get; private set; }
    public string   SelectedPersonName { get; private set; } = "";
    public DateTime MeetingDate        { get; private set; } = DateTime.Today;

    private ComboBox        _cboPerson = null!;
    private DateTimePicker  _dtp       = null!;

    public NewMeetingDialog()
    {
        BuildUI();
        _ = LoadPeopleAsync();
    }

    private void BuildUI()
    {
        Text = "New 1:1 Meeting";
        Size = new Size(360, 175);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 9f);
        BackColor = Color.White;

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16),
            ColumnCount = 2,
            RowCount = 3
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

        _cboPerson = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Dock = DockStyle.Fill
        };
        _dtp = new DateTimePicker
        {
            Dock = DockStyle.Fill,
            Format = DateTimePickerFormat.Short,
            Value = DateTime.Today
        };

        layout.Controls.Add(MkLabel("Person *"), 0, 0);
        layout.Controls.Add(_cboPerson, 1, 0);
        layout.Controls.Add(MkLabel("Date *"), 0, 1);
        layout.Controls.Add(_dtp, 1, 1);

        var btnPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 6, 0, 0)
        };
        layout.SetColumnSpan(btnPanel, 2);

        var btnOK     = new Button { Text = "OK",     Width = 80, DialogResult = DialogResult.OK };
        var btnCancel = new Button { Text = "Cancel", Width = 80, DialogResult = DialogResult.Cancel };
        btnOK.Click += (_, _) => ValidateAndAccept();
        btnPanel.Controls.AddRange(new Control[] { btnCancel, btnOK });
        layout.Controls.Add(btnPanel, 0, 2);

        AcceptButton = btnOK;
        CancelButton = btnCancel;
        Controls.Add(layout);
    }

    private async Task LoadPeopleAsync()
    {
        await using var ctx = DbFactory.Create();
        var people = await ctx.People
            .Where(p => p.IsActive)
            .OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
            .ToListAsync();
        foreach (var p in people)
            _cboPerson.Items.Add(new PersonItem(p.PersonId, p.DisplayName));
        // No default selection — person must actively choose
    }

    private void ValidateAndAccept()
    {
        if (_cboPerson.SelectedItem is not PersonItem pi)
        {
            MessageBox.Show("Please select a person before continuing.",
                "Person Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }
        SelectedPersonId   = pi.Id;
        SelectedPersonName = pi.Name;
        MeetingDate        = _dtp.Value.Date;
    }

    private static Label MkLabel(string text) => new()
    {
        Text = text,
        TextAlign = ContentAlignment.MiddleRight,
        Dock = DockStyle.Fill
    };

    private record PersonItem(int Id, string Name) { public override string ToString() => Name; }
}
