using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Forms;
using PeopleManager.Models;

namespace PeopleManager.Controls;

public class DashboardControl : UserControl
{
    private DataGridView _grid = null!;
    private ComboBox _cboAssignee = null!;

    public DashboardControl()
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
            Height = 60,
            BackColor = Color.White,
            Padding = new Padding(16, 0, 16, 0)
        };
        var lblTitle = new Label
        {
            Text = "Dashboard — Open Action Items",
            Font = new Font("Segoe UI", 14f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 58, 95),
            Dock = DockStyle.Left,
            AutoSize = false,
            Width = 400,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var filterPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 320,
            FlowDirection = FlowDirection.LeftToRight,
            AutoSize = false
        };
        filterPanel.Controls.Add(new Label
        {
            Text = "Show:",
            TextAlign = ContentAlignment.MiddleRight,
            Width = 45,
            Height = 26,
            Margin = new Padding(0, 17, 4, 0)
        });
        _cboAssignee = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Width = 130,
            Margin = new Padding(0, 16, 8, 0)
        };
        _cboAssignee.Items.AddRange(new object[] { "All Open", "Assigned to Me", "Assigned to Person" });
        _cboAssignee.SelectedIndex = 0;
        _cboAssignee.SelectedIndexChanged += async (_, _) => await LoadAsync();
        var btnRefresh = new Button
        {
            Text = "Refresh",
            Width = 80,
            Height = 28,
            Margin = new Padding(0, 15, 0, 0),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(41, 128, 185),
            ForeColor = Color.White,
            Cursor = Cursors.Hand
        };
        btnRefresh.FlatAppearance.BorderSize = 0;
        btnRefresh.Click += async (_, _) => await LoadAsync();
        filterPanel.Controls.AddRange(new Control[] { _cboAssignee, btnRefresh });
        header.Controls.Add(filterPanel);
        header.Controls.Add(lblTitle);

        _grid = BuildGrid();
        _grid.Dock = DockStyle.Fill;
        _grid.Margin = new Padding(16);

        var wrapper = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };
        wrapper.Controls.Add(_grid);

        Controls.Add(wrapper);
        Controls.Add(BuildActionToolbar());
        Controls.Add(header);
    }

    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();
        var query = ctx.ActionItems
            .Include(a => a.Person)
            .Include(a => a.CreatedInMeeting)
            .Where(a => !a.IsComplete);

        if (_cboAssignee.SelectedIndex == 1)
            query = query.Where(a => a.AssignedTo == ActionItemAssignee.Me);
        else if (_cboAssignee.SelectedIndex == 2)
            query = query.Where(a => a.AssignedTo == ActionItemAssignee.Person);

        var items = await query
            .OrderBy(a => a.AssignedTo)   // Me (0) before Person (1)
            .ThenBy(a => a.CreatedDate)
            .ToListAsync();

        _grid.Rows.Clear();
        foreach (var item in items)
        {
            _grid.Rows.Add(
                item.Person.DisplayName,
                item.Description.Length > 80 ? item.Description[..80] + "…" : item.Description,
                item.AssignedTo == ActionItemAssignee.Me ? "Me" : item.Person.FirstName,
                item.CreatedDate.ToShortDateString(),
                item.CreatedInMeeting.MeetingDate.ToShortDateString()
            );
            _grid.Rows[^1].Tag = item.ActionItemId;
        }
    }

    private Panel BuildActionToolbar()
    {
        var toolbar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 40,
            BackColor = Color.FromArgb(248, 249, 250),
            Padding = new Padding(12, 6, 12, 6)
        };
        var flow = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };

        var btnComplete = MakeToolbarButton("Mark Complete", Color.FromArgb(41, 128, 185));
        btnComplete.Click += async (_, _) => await CompleteActionItemAsync();

        var btnDelete = MakeToolbarButton("Delete", Color.FromArgb(192, 57, 43));
        btnDelete.Click += async (_, _) => await DeleteActionItemAsync();

        flow.Controls.AddRange(new Control[] { btnComplete, btnDelete });
        toolbar.Controls.Add(flow);
        return toolbar;
    }

    private static Button MakeToolbarButton(string text, Color back)
    {
        var btn = new Button
        {
            Text = text,
            Height = 26,
            AutoSize = true,
            FlatStyle = FlatStyle.Flat,
            BackColor = back,
            ForeColor = Color.White,
            Cursor = Cursors.Hand,
            Margin = new Padding(0, 0, 6, 0),
            Padding = new Padding(8, 0, 8, 0)
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }

    private async Task CompleteActionItemAsync()
    {
        if (_grid.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Select an action item first.", "No Selection");
            return;
        }
        using var form = new CompleteActionItemForm(id);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    private async Task DeleteActionItemAsync()
    {
        if (_grid.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Select an action item first.", "No Selection");
            return;
        }
        if (MessageBox.Show(
                "Delete this action item?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            != DialogResult.Yes) return;

        await using var ctx = DbFactory.Create();
        var item = await ctx.ActionItems.FindAsync(id);
        if (item == null) return;
        ctx.ActionItems.Remove(item);
        await ctx.SaveChangesAsync();
        await LoadAsync();
    }

    private static DataGridView BuildGrid()
    {
        var dgv = new DataGridView();
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        dgv.ColumnHeadersHeight = 34;
        dgv.RowTemplate.Height = 30;
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
        dgv.GridColor = Color.FromArgb(220, 230, 240);
        dgv.BorderStyle = BorderStyle.None;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.BackgroundColor = Color.White;

        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Person",       Width = 160, Name = "Person" });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Description",  Width = 340, Name = "Description", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Assigned To",  Width = 100, Name = "AssignedTo" });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Created",      Width = 90,  Name = "Created" });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Meeting Date", Width = 100, Name = "MeetingDate" });

        return dgv;
    }
}
