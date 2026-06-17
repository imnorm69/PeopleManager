using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Forms;
using PeopleManager.Models;

namespace PeopleManager.Controls;

/// <summary>
/// Glows &amp; Grows screen listing all recorded feedback items with filters for person, type,
/// and communication status. Supports add, edit, and mark-as-communicated actions.
/// </summary>
public class GlowsGrowsControl : UserControl
{
    private DataGridView _grid = null!;
    private ComboBox _cboPerson = null!;
    private ComboBox _cboType = null!;
    private CheckBox _chkUncommunicated = null!;

    /// <summary>Initialises the control, builds the UI, and starts an async data load.</summary>
    public GlowsGrowsControl()
    {
        BuildUI();
        _ = LoadAsync();
    }

    private void BuildUI()
    {
        BackColor = Color.FromArgb(240, 242, 245);

        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 90,
            BackColor = Color.White,
            Padding = new Padding(16, 0, 16, 0)
        };

        var lblTitle = new Label
        {
            Text = "Glows & Grows",
            Font = new Font("Segoe UI", 21f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 58, 95),
            Dock = DockStyle.Left,
            AutoSize = false,
            Width = 270,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var toolBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 960,
            FlowDirection = FlowDirection.LeftToRight
        };

        _cboPerson = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 270, Margin = new Padding(0, 24, 9, 0) };
        _cboType   = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 165, Margin = new Padding(0, 24, 9, 0) };
        _cboType.Items.AddRange(new object[] { "All", "Glows", "Grows" });
        _cboType.SelectedIndex = 0;

        _chkUncommunicated = new CheckBox
        {
            Text = "Not yet communicated",
            AutoSize = true,
            Margin = new Padding(0, 27, 9, 0)
        };

        var btnAdd           = MakeButton("+ Add",              Color.FromArgb(39, 174, 96));
        var btnEdit          = MakeButton("Edit",               Color.FromArgb(41, 128, 185));
        var btnCommunicated  = MakeButton("Mark Communicated",  Color.FromArgb(142, 68, 173));

        _cboPerson.SelectedIndexChanged  += async (_, _) => await LoadAsync();
        _cboType.SelectedIndexChanged    += async (_, _) => await LoadAsync();
        _chkUncommunicated.CheckedChanged += async (_, _) => await LoadAsync();
        btnAdd.Click          += async (_, _) => await AddAsync();
        btnEdit.Click         += async (_, _) => await EditAsync();
        btnCommunicated.Click += async (_, _) => await MarkCommunicatedAsync();

        toolBar.Controls.AddRange(new Control[] { _cboPerson, _cboType, _chkUncommunicated, btnAdd, btnEdit, btnCommunicated });
        header.Controls.Add(toolBar);
        header.Controls.Add(lblTitle);

        _grid = BuildGrid();
        _grid.CellDoubleClick += async (_, _) => await EditAsync();

        var wrapper = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };
        wrapper.Controls.Add(_grid);

        Controls.Add(wrapper);
        Controls.Add(header);
    }

    /// <summary>Loads people into the filter dropdown (once) and refreshes the glows/grows grid.</summary>
    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();

        if (_cboPerson.Items.Count == 0)
        {
            var people = await ctx.People.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToListAsync();
            _cboPerson.Items.Add("All People");
            foreach (var p in people)
                _cboPerson.Items.Add(new PersonItem(p.PersonId, p.DisplayName));
            _cboPerson.SelectedIndex = 0;
        }

        var query = ctx.GlowsGrows.Include(g => g.Person).AsQueryable();

        if (_cboPerson.SelectedItem is PersonItem pi)
            query = query.Where(g => g.PersonId == pi.Id);

        if (_cboType.SelectedIndex == 1) query = query.Where(g => g.Type == GlowGrowType.Glow);
        if (_cboType.SelectedIndex == 2) query = query.Where(g => g.Type == GlowGrowType.Grow);
        if (_chkUncommunicated.Checked)  query = query.Where(g => g.CommunicatedDate == null);

        var items = await query.OrderByDescending(g => g.CreatedDate).ToListAsync();

        _grid.Rows.Clear();
        foreach (var item in items)
        {
            var communicated = item.CommunicatedDate.HasValue
                ? item.CommunicatedDate.Value.ToShortDateString()
                : "—";
            _grid.Rows.Add(
                item.Person.DisplayName,
                item.Type.ToString(),
                item.Source ?? "",
                item.Note.Length > 100 ? item.Note[..100] + "…" : item.Note,
                item.CreatedDate.ToShortDateString(),
                communicated
            );
            _grid.Rows[^1].Tag = item.GlowGrowId;

            _grid.Rows[^1].DefaultCellStyle.ForeColor =
                item.Type == GlowGrowType.Glow ? Color.FromArgb(39, 174, 96) : Color.FromArgb(192, 57, 43);
        }
    }

    /// <summary>Opens the Add Glow/Grow dialog, pre-selecting the currently filtered person if applicable.</summary>
    private async Task AddAsync()
    {
        int? preselectedPersonId = (_cboPerson.SelectedItem is PersonItem pi) ? pi.Id : null;
        using var form = new AddGlowGrowForm(null, preselectedPersonId);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    /// <summary>Opens the Edit Glow/Grow dialog for the selected item.</summary>
    private async Task EditAsync()
    {
        if (_grid.CurrentRow?.Tag is not int id) { MessageBox.Show("Select an item first.", "No Selection"); return; }
        using var form = new AddGlowGrowForm(id, null);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    /// <summary>Sets today as the communicated date on the selected glow/grow item.</summary>
    private async Task MarkCommunicatedAsync()
    {
        if (_grid.CurrentRow?.Tag is not int id) { MessageBox.Show("Select an item first.", "No Selection"); return; }
        await using var ctx = DbFactory.Create();
        var item = await ctx.GlowsGrows.FindAsync(id);
        if (item == null) return;
        item.CommunicatedDate = DateTime.Today;
        await ctx.SaveChangesAsync();
        await LoadAsync();
    }

    private static Button MakeButton(string text, Color back)
    {
        var btn = new Button
        {
            Text = text, Height = 42, AutoSize = true,
            FlatStyle = FlatStyle.Flat, BackColor = back, ForeColor = Color.White,
            Cursor = Cursors.Hand, Margin = new Padding(6, 24, 0, 0), Padding = new Padding(12, 0, 12, 0)
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }

    private static DataGridView BuildGrid()
    {
        var dgv = new DataGridView { Dock = DockStyle.Fill };
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
        dgv.ColumnHeadersHeight = 51;
        dgv.RowTemplate.Height = 45;
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 14f);
        dgv.GridColor = Color.FromArgb(220, 230, 240);
        dgv.BorderStyle = BorderStyle.None;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.BackgroundColor = Color.White;

        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Person",       Width = 225 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Type",         Width = 90 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Source",       Width = 270 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Note",         Width = 390, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Recorded",     Width = 135 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Communicated", Width = 165 });
        return dgv;
    }

    private record PersonItem(int Id, string Name) { public override string ToString() => Name; }
}
