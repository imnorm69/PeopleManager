namespace PeopleManager.Forms;

partial class PersonDetailForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.SuspendLayout();

        // ── Header ────────────────────────────────────────────────────────────────
        this._lblName = new System.Windows.Forms.Label();
        this._lblName.ForeColor = System.Drawing.Color.White;
        this._lblName.Font      = new System.Drawing.Font("Segoe UI", 20f, System.Drawing.FontStyle.Bold);
        this._lblName.Dock      = System.Windows.Forms.DockStyle.Top;
        this._lblName.Height    = 54;
        this._lblName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

        this._lblStatus = new System.Windows.Forms.Label();
        this._lblStatus.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
        this._lblStatus.Font      = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Italic);
        this._lblStatus.Dock      = System.Windows.Forms.DockStyle.Top;
        this._lblStatus.Height    = 33;
        this._lblStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft;

        var nameStack = new System.Windows.Forms.Panel();
        nameStack.Dock      = System.Windows.Forms.DockStyle.Left;
        nameStack.Width     = 690;
        nameStack.BackColor = System.Drawing.Color.Transparent;
        nameStack.Controls.Add(this._lblStatus);
        nameStack.Controls.Add(this._lblName);

        this._btnSeparate = new System.Windows.Forms.Button();
        this._btnSeparate.Text      = "Separate";
        this._btnSeparate.Height    = 45;
        this._btnSeparate.AutoSize  = true;
        this._btnSeparate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnSeparate.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
        this._btnSeparate.ForeColor = System.Drawing.Color.White;
        this._btnSeparate.Cursor    = System.Windows.Forms.Cursors.Hand;
        this._btnSeparate.Margin    = new System.Windows.Forms.Padding(9, 0, 0, 0);
        this._btnSeparate.Padding   = new System.Windows.Forms.Padding(15, 0, 15, 0);
        this._btnSeparate.FlatAppearance.BorderSize = 0;
        this._btnSeparate.Click += BtnSeparate_Click;

        this._btnReHire = new System.Windows.Forms.Button();
        this._btnReHire.Text      = "Re-hire";
        this._btnReHire.Height    = 45;
        this._btnReHire.AutoSize  = true;
        this._btnReHire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnReHire.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
        this._btnReHire.ForeColor = System.Drawing.Color.White;
        this._btnReHire.Cursor    = System.Windows.Forms.Cursors.Hand;
        this._btnReHire.Margin    = new System.Windows.Forms.Padding(9, 0, 0, 0);
        this._btnReHire.Padding   = new System.Windows.Forms.Padding(15, 0, 15, 0);
        this._btnReHire.FlatAppearance.BorderSize = 0;
        this._btnReHire.Click += BtnReHire_Click;

        var btnEdit = new System.Windows.Forms.Button();
        btnEdit.Text      = "Edit Info";
        btnEdit.Height    = 45;
        btnEdit.AutoSize  = true;
        btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnEdit.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
        btnEdit.ForeColor = System.Drawing.Color.White;
        btnEdit.Cursor    = System.Windows.Forms.Cursors.Hand;
        btnEdit.Margin    = new System.Windows.Forms.Padding(9, 0, 0, 0);
        btnEdit.Padding   = new System.Windows.Forms.Padding(15, 0, 15, 0);
        btnEdit.FlatAppearance.BorderSize = 0;
        btnEdit.Click += BtnEdit_Click;

        var btnPanel = new System.Windows.Forms.FlowLayoutPanel();
        btnPanel.Dock          = System.Windows.Forms.DockStyle.Right;
        btnPanel.Width         = 435;
        btnPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        btnPanel.BackColor     = System.Drawing.Color.Transparent;
        btnPanel.Padding       = new System.Windows.Forms.Padding(0, 28, 0, 0);
        btnPanel.Controls.AddRange(new System.Windows.Forms.Control[] { this._btnSeparate, this._btnReHire, btnEdit });

        var header = new System.Windows.Forms.Panel();
        header.Dock      = System.Windows.Forms.DockStyle.Top;
        header.Height    = 100;
        header.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
        header.Padding   = new System.Windows.Forms.Padding(16, 0, 8, 0);
        header.Controls.Add(btnPanel);
        header.Controls.Add(nameStack);

        // ── Tabs ──────────────────────────────────────────────────────────────────
        this._tabs = new System.Windows.Forms.TabControl();
        this._tabs.Dock = System.Windows.Forms.DockStyle.Fill;
        this._tabs.Font = new System.Drawing.Font("Segoe UI", 14f);

        // Job Titles tab
        var pageJobTitles = new System.Windows.Forms.TabPage("Job Titles");

        var btnAddTitle = new System.Windows.Forms.Button();
        btnAddTitle.Text      = "+ Add Title";
        btnAddTitle.Height    = 40;
        btnAddTitle.AutoSize  = true;
        btnAddTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnAddTitle.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
        btnAddTitle.ForeColor = System.Drawing.Color.White;
        btnAddTitle.Cursor    = System.Windows.Forms.Cursors.Hand;
        btnAddTitle.Margin    = new System.Windows.Forms.Padding(0, 0, 9, 0);
        btnAddTitle.Padding   = new System.Windows.Forms.Padding(9, 0, 9, 0);
        btnAddTitle.FlatAppearance.BorderSize = 0;
        btnAddTitle.Click += BtnAddTitle_Click;

        var toolbarTitles = new System.Windows.Forms.FlowLayoutPanel();
        toolbarTitles.Dock          = System.Windows.Forms.DockStyle.Top;
        toolbarTitles.Height        = 60;
        toolbarTitles.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        toolbarTitles.Padding       = new System.Windows.Forms.Padding(8, 9, 0, 0);
        toolbarTitles.Controls.Add(btnAddTitle);

        this._gridTitles = new System.Windows.Forms.DataGridView();
        this._gridTitles.Dock                                      = System.Windows.Forms.DockStyle.Fill;
        this._gridTitles.EnableHeadersVisualStyles                 = false;
        this._gridTitles.ColumnHeadersDefaultCellStyle.BackColor   = System.Drawing.Color.FromArgb(52, 73, 94);
        this._gridTitles.ColumnHeadersDefaultCellStyle.ForeColor   = System.Drawing.Color.White;
        this._gridTitles.ColumnHeadersDefaultCellStyle.Font        = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
        this._gridTitles.ColumnHeadersHeight                       = 42;
        this._gridTitles.RowTemplate.Height                        = 40;
        this._gridTitles.DefaultCellStyle.Font                     = new System.Drawing.Font("Segoe UI", 14f);
        this._gridTitles.GridColor                                 = System.Drawing.Color.FromArgb(220, 230, 240);
        this._gridTitles.BorderStyle                               = System.Windows.Forms.BorderStyle.None;
        this._gridTitles.RowHeadersVisible                         = false;
        this._gridTitles.SelectionMode                             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this._gridTitles.MultiSelect                               = false;
        this._gridTitles.ReadOnly                                  = true;
        this._gridTitles.AllowUserToAddRows                        = false;
        this._gridTitles.AllowUserToDeleteRows                     = false;
        this._gridTitles.BackgroundColor                           = System.Drawing.Color.White;
        var gtCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        gtCol0.HeaderText = "Title";
        gtCol0.Width      = 390;
        this._gridTitles.Columns.Add(gtCol0);
        var gtCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        gtCol1.HeaderText = "Effective Date";
        gtCol1.Width      = 195;
        this._gridTitles.Columns.Add(gtCol1);
        var gtCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        gtCol2.HeaderText = "Current?";
        gtCol2.Width      = 120;
        this._gridTitles.Columns.Add(gtCol2);

        pageJobTitles.Controls.Add(this._gridTitles);
        pageJobTitles.Controls.Add(toolbarTitles);

        // Teams / Projects tab
        var pageTeams = new System.Windows.Forms.TabPage("Teams / Projects");

        var btnAddTeam = new System.Windows.Forms.Button();
        btnAddTeam.Text      = "+ Assign Team";
        btnAddTeam.Height    = 40;
        btnAddTeam.AutoSize  = true;
        btnAddTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnAddTeam.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
        btnAddTeam.ForeColor = System.Drawing.Color.White;
        btnAddTeam.Cursor    = System.Windows.Forms.Cursors.Hand;
        btnAddTeam.Margin    = new System.Windows.Forms.Padding(0, 0, 9, 0);
        btnAddTeam.Padding   = new System.Windows.Forms.Padding(9, 0, 9, 0);
        btnAddTeam.FlatAppearance.BorderSize = 0;
        btnAddTeam.Click += BtnAddTeam_Click;

        var btnRemoveTeam = new System.Windows.Forms.Button();
        btnRemoveTeam.Text      = "Remove";
        btnRemoveTeam.Height    = 40;
        btnRemoveTeam.AutoSize  = true;
        btnRemoveTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnRemoveTeam.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
        btnRemoveTeam.ForeColor = System.Drawing.Color.White;
        btnRemoveTeam.Cursor    = System.Windows.Forms.Cursors.Hand;
        btnRemoveTeam.Margin    = new System.Windows.Forms.Padding(0, 0, 9, 0);
        btnRemoveTeam.Padding   = new System.Windows.Forms.Padding(9, 0, 9, 0);
        btnRemoveTeam.FlatAppearance.BorderSize = 0;
        btnRemoveTeam.Click += BtnRemoveTeam_Click;

        var btnToolbar = new System.Windows.Forms.FlowLayoutPanel();
        btnToolbar.Dock          = System.Windows.Forms.DockStyle.Top;
        btnToolbar.Height        = 54;
        btnToolbar.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        btnToolbar.Padding       = new System.Windows.Forms.Padding(6, 6, 0, 0);
        btnToolbar.Controls.AddRange(new System.Windows.Forms.Control[] { btnAddTeam, btnRemoveTeam });

        this._gridTeamsCurrent = new System.Windows.Forms.DataGridView();
        this._gridTeamsCurrent.Dock                                      = System.Windows.Forms.DockStyle.Fill;
        this._gridTeamsCurrent.EnableHeadersVisualStyles                 = false;
        this._gridTeamsCurrent.ColumnHeadersDefaultCellStyle.BackColor   = System.Drawing.Color.FromArgb(52, 73, 94);
        this._gridTeamsCurrent.ColumnHeadersDefaultCellStyle.ForeColor   = System.Drawing.Color.White;
        this._gridTeamsCurrent.ColumnHeadersDefaultCellStyle.Font        = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
        this._gridTeamsCurrent.ColumnHeadersHeight                       = 42;
        this._gridTeamsCurrent.RowTemplate.Height                        = 40;
        this._gridTeamsCurrent.DefaultCellStyle.Font                     = new System.Drawing.Font("Segoe UI", 14f);
        this._gridTeamsCurrent.GridColor                                 = System.Drawing.Color.FromArgb(220, 230, 240);
        this._gridTeamsCurrent.BorderStyle                               = System.Windows.Forms.BorderStyle.None;
        this._gridTeamsCurrent.RowHeadersVisible                         = false;
        this._gridTeamsCurrent.SelectionMode                             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this._gridTeamsCurrent.MultiSelect                               = false;
        this._gridTeamsCurrent.ReadOnly                                  = true;
        this._gridTeamsCurrent.AllowUserToAddRows                        = false;
        this._gridTeamsCurrent.AllowUserToDeleteRows                     = false;
        this._gridTeamsCurrent.BackgroundColor                           = System.Drawing.Color.White;
        var gcCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        gcCol0.HeaderText = "Team/Project";
        gcCol0.Width      = 300;
        this._gridTeamsCurrent.Columns.Add(gcCol0);
        var gcCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        gcCol1.HeaderText = "Assigned Date";
        gcCol1.Width      = 180;
        this._gridTeamsCurrent.Columns.Add(gcCol1);
        var gcCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        gcCol2.HeaderText = "Effective Date";
        gcCol2.Width      = 180;
        this._gridTeamsCurrent.Columns.Add(gcCol2);

        var lblCurrent = new System.Windows.Forms.Label();
        lblCurrent.Text   = "Current Assignments";
        lblCurrent.Font   = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        lblCurrent.Dock   = System.Windows.Forms.DockStyle.Top;
        lblCurrent.Height = 33;

        this._gridTeamsHistory = new System.Windows.Forms.DataGridView();
        this._gridTeamsHistory.Dock                                      = System.Windows.Forms.DockStyle.Fill;
        this._gridTeamsHistory.EnableHeadersVisualStyles                 = false;
        this._gridTeamsHistory.ColumnHeadersDefaultCellStyle.BackColor   = System.Drawing.Color.FromArgb(52, 73, 94);
        this._gridTeamsHistory.ColumnHeadersDefaultCellStyle.ForeColor   = System.Drawing.Color.White;
        this._gridTeamsHistory.ColumnHeadersDefaultCellStyle.Font        = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
        this._gridTeamsHistory.ColumnHeadersHeight                       = 42;
        this._gridTeamsHistory.RowTemplate.Height                        = 40;
        this._gridTeamsHistory.DefaultCellStyle.Font                     = new System.Drawing.Font("Segoe UI", 14f);
        this._gridTeamsHistory.GridColor                                 = System.Drawing.Color.FromArgb(220, 230, 240);
        this._gridTeamsHistory.BorderStyle                               = System.Windows.Forms.BorderStyle.None;
        this._gridTeamsHistory.RowHeadersVisible                         = false;
        this._gridTeamsHistory.SelectionMode                             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this._gridTeamsHistory.MultiSelect                               = false;
        this._gridTeamsHistory.ReadOnly                                  = true;
        this._gridTeamsHistory.AllowUserToAddRows                        = false;
        this._gridTeamsHistory.AllowUserToDeleteRows                     = false;
        this._gridTeamsHistory.BackgroundColor                           = System.Drawing.Color.White;
        var ghCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ghCol0.HeaderText = "Team/Project";
        ghCol0.Width      = 300;
        this._gridTeamsHistory.Columns.Add(ghCol0);
        var ghCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ghCol1.HeaderText = "Assigned";
        ghCol1.Width      = 165;
        this._gridTeamsHistory.Columns.Add(ghCol1);
        var ghCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ghCol2.HeaderText = "Effective";
        ghCol2.Width      = 165;
        this._gridTeamsHistory.Columns.Add(ghCol2);
        var ghCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ghCol3.HeaderText = "Removed";
        ghCol3.Width      = 165;
        this._gridTeamsHistory.Columns.Add(ghCol3);

        var lblHistory = new System.Windows.Forms.Label();
        lblHistory.Text   = "History";
        lblHistory.Font   = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        lblHistory.Dock   = System.Windows.Forms.DockStyle.Top;
        lblHistory.Height = 33;

        var split = new System.Windows.Forms.SplitContainer();
        split.Dock             = System.Windows.Forms.DockStyle.Fill;
        split.Orientation      = System.Windows.Forms.Orientation.Horizontal;
        split.SplitterDistance = 300;
        split.Panel1MinSize    = 180;
        split.Panel2MinSize    = 120;
        split.Panel1.Controls.Add(this._gridTeamsCurrent);
        split.Panel1.Controls.Add(btnToolbar);
        split.Panel1.Controls.Add(lblCurrent);
        split.Panel2.Controls.Add(this._gridTeamsHistory);
        split.Panel2.Controls.Add(lblHistory);

        pageTeams.Controls.Add(split);

        // Employment History tab
        var pageEmployment = new System.Windows.Forms.TabPage("Employment History");

        this._gridEmployment = new System.Windows.Forms.DataGridView();
        this._gridEmployment.Dock                                      = System.Windows.Forms.DockStyle.Fill;
        this._gridEmployment.EnableHeadersVisualStyles                 = false;
        this._gridEmployment.ColumnHeadersDefaultCellStyle.BackColor   = System.Drawing.Color.FromArgb(52, 73, 94);
        this._gridEmployment.ColumnHeadersDefaultCellStyle.ForeColor   = System.Drawing.Color.White;
        this._gridEmployment.ColumnHeadersDefaultCellStyle.Font        = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
        this._gridEmployment.ColumnHeadersHeight                       = 42;
        this._gridEmployment.RowTemplate.Height                        = 40;
        this._gridEmployment.DefaultCellStyle.Font                     = new System.Drawing.Font("Segoe UI", 14f);
        this._gridEmployment.GridColor                                 = System.Drawing.Color.FromArgb(220, 230, 240);
        this._gridEmployment.BorderStyle                               = System.Windows.Forms.BorderStyle.None;
        this._gridEmployment.RowHeadersVisible                         = false;
        this._gridEmployment.SelectionMode                             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this._gridEmployment.MultiSelect                               = false;
        this._gridEmployment.ReadOnly                                  = true;
        this._gridEmployment.AllowUserToAddRows                        = false;
        this._gridEmployment.AllowUserToDeleteRows                     = false;
        this._gridEmployment.BackgroundColor                           = System.Drawing.Color.White;
        var geCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        geCol0.HeaderText = "Hire Date";
        geCol0.Width      = 165;
        this._gridEmployment.Columns.Add(geCol0);
        var geCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        geCol1.HeaderText = "Separation Date";
        geCol1.Width      = 180;
        this._gridEmployment.Columns.Add(geCol1);
        var geCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        geCol2.HeaderText = "Reason";
        geCol2.Width      = 255;
        this._gridEmployment.Columns.Add(geCol2);
        var geCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        geCol3.HeaderText   = "Notes";
        geCol3.Width        = 390;
        geCol3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this._gridEmployment.Columns.Add(geCol3);

        pageEmployment.Controls.Add(this._gridEmployment);

        this._tabs.TabPages.Add(pageJobTitles);
        this._tabs.TabPages.Add(pageTeams);
        this._tabs.TabPages.Add(pageEmployment);

        // ── Close button ──────────────────────────────────────────────────────────
        var btnClose = new System.Windows.Forms.Button();
        btnClose.Text         = "Close";
        btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
        btnClose.Dock         = System.Windows.Forms.DockStyle.Bottom;
        btnClose.Height       = 54;
        btnClose.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
        btnClose.BackColor    = System.Drawing.Color.FromArgb(52, 73, 94);
        btnClose.ForeColor    = System.Drawing.Color.White;
        btnClose.FlatAppearance.BorderSize = 0;

        // ── Form properties ───────────────────────────────────────────────────────
        this.Text            = "Person Details";
        this.Size            = new System.Drawing.Size(1220, 930);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MinimumSize     = new System.Drawing.Size(980, 750);
        this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Font            = new System.Drawing.Font("Segoe UI", 14f);
        this.BackColor       = System.Drawing.Color.White;

        this.Controls.Add(this._tabs);
        this.Controls.Add(header);
        this.Controls.Add(btnClose);

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label        _lblName          = null!;
    private System.Windows.Forms.Label        _lblStatus        = null!;
    private System.Windows.Forms.Button       _btnSeparate      = null!;
    private System.Windows.Forms.Button       _btnReHire        = null!;
    private System.Windows.Forms.TabControl   _tabs             = null!;
    private System.Windows.Forms.DataGridView _gridTitles       = null!;
    private System.Windows.Forms.DataGridView _gridTeamsCurrent = null!;
    private System.Windows.Forms.DataGridView _gridTeamsHistory = null!;
    private System.Windows.Forms.DataGridView _gridEmployment   = null!;
}
