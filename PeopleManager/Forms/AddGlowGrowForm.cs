using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

public class AddGlowGrowForm : Form
{
    private readonly int? _glowGrowId;
    private readonly int? _preselectedPersonId;
    private ComboBox _cboPerson = null!;
    private ComboBox _cboType = null!;
    private TextBox _txtSource = null!;
    private RichTextBox _txtNote = null!;
    private CheckBox _chkCommunicated = null!;
    private DateTimePicker _dtpCommunicated = null!;

    public AddGlowGrowForm(int? glowGrowId, int? preselectedPersonId)
    {
        _glowGrowId = glowGrowId;
        _preselectedPersonId = preselectedPersonId;
        BuildUI();
        _ = LoadAsync();
    }

    private void BuildUI()
    {
        Text = _glowGrowId.HasValue ? "Edit Glow/Grow" : "Add Glow/Grow";
        Size = new Size(520, 420);
        FormBorderStyle = FormBorderStyle.Sizable;
        MinimumSize = new Size(400, 360);
        MaximizeBox = false; MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 9f);
        BackColor = Color.White;

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16),
            ColumnCount = 2,
            RowCount = 7,
            AutoSize = false
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34)); // Person
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34)); // Type
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34)); // Source
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Note
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34)); // Communicated checkbox
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34)); // Communicated date
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Buttons

        _cboPerson = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
        _cboType   = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
        _cboType.Items.AddRange(new object[] { "Glow", "Grow" });
        _cboType.SelectedIndex = 0;

        _txtSource = new TextBox
        {
            Dock = DockStyle.Fill,
            PlaceholderText = "e.g. Emailed from PO, Observed during refinement…",
            MaxLength = 500
        };

        _txtNote = new RichTextBox { Dock = DockStyle.Fill, ScrollBars = RichTextBoxScrollBars.Vertical };

        _chkCommunicated = new CheckBox
        {
            Text = "Communicated?",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        };
        _dtpCommunicated = new DateTimePicker
        {
            Dock = DockStyle.Fill,
            Format = DateTimePickerFormat.Short,
            Value = DateTime.Today,
            Enabled = false
        };
        _chkCommunicated.CheckedChanged += (_, _) => _dtpCommunicated.Enabled = _chkCommunicated.Checked;

        layout.Controls.Add(new Label { Text = "Person *",  TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 0);
        layout.Controls.Add(_cboPerson, 1, 0);
        layout.Controls.Add(new Label { Text = "Type *",    TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 1);
        layout.Controls.Add(_cboType,   1, 1);
        layout.Controls.Add(new Label { Text = "Source",    TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 2);
        layout.Controls.Add(_txtSource, 1, 2);
        layout.Controls.Add(new Label { Text = "Note *",    TextAlign = ContentAlignment.TopRight, Dock = DockStyle.Fill, Padding = new Padding(0, 6, 4, 0) }, 0, 3);
        layout.Controls.Add(_txtNote,   1, 3);
        layout.Controls.Add(_chkCommunicated, 0, 4);
        layout.SetColumnSpan(_chkCommunicated, 2);
        layout.Controls.Add(new Label { Text = "Date:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 5);
        layout.Controls.Add(_dtpCommunicated, 1, 5);

        var btnPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, Padding = new Padding(0, 4, 0, 0) };
        layout.SetColumnSpan(btnPanel, 2);
        var btnSave   = new Button { Text = "Save",   DialogResult = DialogResult.OK,     Width = 80 };
        var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Width = 80 };
        btnSave.Click += async (_, _) => await SaveAsync();
        btnPanel.Controls.AddRange(new Control[] { btnCancel, btnSave });
        layout.Controls.Add(btnPanel, 0, 6);

        AcceptButton = btnSave;
        CancelButton = btnCancel;
        Controls.Add(layout);
    }

    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();
        var people = await ctx.People
            .OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
            .ToListAsync();
        foreach (var p in people)
            _cboPerson.Items.Add(new PersonItem(p.PersonId, p.DisplayName));

        if (_glowGrowId.HasValue)
        {
            var item = await ctx.GlowsGrows.FindAsync(_glowGrowId.Value);
            if (item == null) return;
            _cboPerson.SelectedItem = _cboPerson.Items.OfType<PersonItem>().FirstOrDefault(p => p.Id == item.PersonId);
            _cboType.SelectedIndex  = (int)item.Type;
            _txtSource.Text         = item.Source ?? "";
            _txtNote.Text           = item.Note;
            if (item.CommunicatedDate.HasValue)
            {
                _chkCommunicated.Checked = true;
                _dtpCommunicated.Value   = item.CommunicatedDate.Value;
            }
        }
        else if (_preselectedPersonId.HasValue)
        {
            _cboPerson.SelectedItem = _cboPerson.Items.OfType<PersonItem>()
                .FirstOrDefault(p => p.Id == _preselectedPersonId.Value);
        }
        else if (_cboPerson.Items.Count > 0)
        {
            _cboPerson.SelectedIndex = 0;
        }
    }

    private async Task SaveAsync()
    {
        if (_cboPerson.SelectedItem is not PersonItem pi)
        {
            MessageBox.Show("Select a person.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None; return;
        }
        if (string.IsNullOrWhiteSpace(_txtNote.Text))
        {
            MessageBox.Show("Note is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None; return;
        }

        var source = string.IsNullOrWhiteSpace(_txtSource.Text) ? null : _txtSource.Text.Trim();

        await using var ctx = DbFactory.Create();
        if (_glowGrowId.HasValue)
        {
            var item = await ctx.GlowsGrows.FindAsync(_glowGrowId.Value);
            if (item == null) return;
            item.PersonId         = pi.Id;
            item.Type             = (GlowGrowType)_cboType.SelectedIndex;
            item.Source           = source;
            item.Note             = _txtNote.Text.Trim();
            item.CommunicatedDate = _chkCommunicated.Checked ? _dtpCommunicated.Value.Date : null;
        }
        else
        {
            ctx.GlowsGrows.Add(new GlowGrow
            {
                PersonId          = pi.Id,
                Type              = (GlowGrowType)_cboType.SelectedIndex,
                Source            = source,
                Note              = _txtNote.Text.Trim(),
                CreatedDate       = DateTime.Today,
                CommunicatedDate  = _chkCommunicated.Checked ? _dtpCommunicated.Value.Date : null
            });
        }
        await ctx.SaveChangesAsync();
    }

    private record PersonItem(int Id, string Name) { public override string ToString() => Name; }
}
