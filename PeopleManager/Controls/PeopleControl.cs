using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Forms;

namespace PeopleManager.Controls;

public class PeopleControl : UserControl
{
    private DataGridView _grid = null!;
    private TextBox _txtSearch = null!;
    private List<PersonRow> _allRows = new();

    private record PersonRow(int Id, string LastName, string FirstName, string StartDate,
                              string JobTitle, string Teams, bool IsActive);

    private ComboBox _cboStatus = null!;

    public PeopleControl()
    {
        BuildUI();
        _ = LoadAsync().ContinueWith(t =>
        {
            if (t.IsFaulted)
                MessageBox.Show($"Failed to load people:\n\n{t.Exception?.InnerException?.Message}",
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }, TaskScheduler.FromCurrentSynchronizationContext());
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
            Text = "People",
            Font = new Font("Segoe UI", 21f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 58, 95),
            Dock = DockStyle.Left,
            AutoSize = false,
            Width = 180,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var toolBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 900,
            FlowDirection = FlowDirection.LeftToRight,
            AutoSize = false
        };

        _txtSearch = new TextBox
        {
            PlaceholderText = "Search by name…",
            Width = 270,
            Margin = new Padding(0, 24, 9, 0)
        };
        _txtSearch.TextChanged += (_, _) => FilterGrid();

        _cboStatus = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Width = 180,
            Margin = new Padding(0, 24, 12, 0)
        };
        _cboStatus.Items.AddRange(new object[] { "Active Only", "All", "Separated" });
        _cboStatus.SelectedIndex = 0;
        _cboStatus.SelectedIndexChanged += (_, _) => FilterGrid();

        var btnAdd    = MakeButton("+ Add Person", Color.FromArgb(39, 174, 96));
        var btnEdit   = MakeButton("Edit",         Color.FromArgb(41, 128, 185));
        var btnDelete = MakeButton("Delete",       Color.FromArgb(192, 57, 43));

        btnAdd.Click    += async (_, _) => await AddPersonAsync();
        btnEdit.Click   += async (_, _) => await EditPersonAsync();
        btnDelete.Click += async (_, _) => await DeletePersonAsync();

        toolBar.Controls.AddRange(new Control[] { _txtSearch, _cboStatus, btnAdd, btnEdit, btnDelete });
        header.Controls.Add(toolBar);
        header.Controls.Add(lblTitle);

        _grid = BuildGrid();
        _grid.CellDoubleClick += async (_, _) => await EditPersonAsync();

        var wrapper = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };
        wrapper.Controls.Add(_grid);

        Controls.Add(wrapper);
        Controls.Add(header);
    }

    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();
        var people = await ctx.People
            .Include(p => p.JobTitles)
            .Include(p => p.ProjectAssignments.Where(a => a.RemovedDate == null))
                .ThenInclude(a => a.ProjectTeam)
            .OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
            .ToListAsync();

        _allRows = people.Select(p =>
        {
            var title = p.JobTitles.OrderByDescending(j => j.EffectiveDate).FirstOrDefault()?.Title ?? "";
            var teams = string.Join(", ", p.ProjectAssignments
                .Where(a => a.RemovedDate == null)
                .Select(a => a.ProjectTeam.Name));
            return new PersonRow(p.PersonId, p.LastName, p.FirstName,
                                 p.StartDate.ToShortDateString(), title, teams, p.IsActive);
        }).ToList();

        FilterGrid();
    }

    private void FilterGrid()
    {
        var search = _txtSearch.Text.Trim().ToLower();

        var rows = _allRows.AsEnumerable();

        if (_cboStatus.SelectedIndex == 0)      rows = rows.Where(r => r.IsActive);
        else if (_cboStatus.SelectedIndex == 2)  rows = rows.Where(r => !r.IsActive);

        if (!string.IsNullOrEmpty(search))
            rows = rows.Where(r =>
                r.LastName.ToLower().Contains(search) ||
                r.FirstName.ToLower().Contains(search));

        _grid.Rows.Clear();
        foreach (var r in rows)
        {
            _grid.Rows.Add(r.LastName, r.FirstName, r.StartDate, r.JobTitle, r.Teams);
            _grid.Rows[^1].Tag = r.Id;
            if (!r.IsActive)
            {
                _grid.Rows[^1].DefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 160);
                _grid.Rows[^1].DefaultCellStyle.Font = new Font("Segoe UI", 14f, FontStyle.Italic);
            }
        }
    }

    private int? SelectedPersonId()
    {
        if (_grid.CurrentRow == null) return null;
        return _grid.CurrentRow.Tag as int?;
    }

    private async Task AddPersonAsync()
    {
        using var form = new AddEditPersonForm(null);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    private async Task EditPersonAsync()
    {
        var id = SelectedPersonId();
        if (id == null) { MessageBox.Show("Select a person first.", "No Selection"); return; }
        using var form = new PersonDetailForm(id.Value);
        form.ShowDialog();
        await LoadAsync();
    }

    private async Task DeletePersonAsync()
    {
        var id = SelectedPersonId();
        if (id == null) { MessageBox.Show("Select a person first.", "No Selection"); return; }

        if (MessageBox.Show("Delete this person and all their data?", "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

        await using var ctx = DbFactory.Create();
        var person = await ctx.People.FindAsync(id);
        if (person == null) return;
        ctx.People.Remove(person);
        await ctx.SaveChangesAsync();
        await LoadAsync();
    }

    private static Button MakeButton(string text, Color back)
    {
        var btn = new Button
        {
            Text = text,
            Height = 42,
            AutoSize = true,
            FlatStyle = FlatStyle.Flat,
            BackColor = back,
            ForeColor = Color.White,
            Cursor = Cursors.Hand,
            Margin = new Padding(6, 24, 0, 0),
            Padding = new Padding(12, 0, 12, 0)
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
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
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

        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Last Name",  Width = 225 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "First Name", Width = 195 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Start Date", Width = 150 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Job Title",  Width = 300, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teams",      Width = 300 });
        return dgv;
    }
}
