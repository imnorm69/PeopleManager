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
        this._pnlHeader = new System.Windows.Forms.Panel();
        this._pnlNameStack = new System.Windows.Forms.Panel();
        this._lblName = new System.Windows.Forms.Label();
        this._lblStatus = new System.Windows.Forms.Label();
        this._pnlHeaderButtons = new System.Windows.Forms.FlowLayoutPanel();
        this._btnSeparate = new System.Windows.Forms.Button();
        this._btnReHire = new System.Windows.Forms.Button();
        this._btnEdit = new System.Windows.Forms.Button();
        this._tabs = new System.Windows.Forms.TabControl();
        this._pageJobTitles = new System.Windows.Forms.TabPage("Job Titles");
        this._pnlTitleToolbar = new System.Windows.Forms.FlowLayoutPanel();
        this._btnAddTitle = new System.Windows.Forms.Button();
        this._gridTitles = new System.Windows.Forms.DataGridView();
        this._colTitleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colTitleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colTitleCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._pageTeams = new System.Windows.Forms.TabPage("Teams / Projects");
        this._splitTeams = new System.Windows.Forms.SplitContainer();
        this._lblCurrentTeams = new System.Windows.Forms.Label();
        this._pnlTeamToolbar = new System.Windows.Forms.FlowLayoutPanel();
        this._btnAddTeam = new System.Windows.Forms.Button();
        this._btnRemoveTeam = new System.Windows.Forms.Button();
        this._gridTeamsCurrent = new System.Windows.Forms.DataGridView();
        this._colCurrentTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colCurrentAssigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colCurrentEffective = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._lblTeamHistory = new System.Windows.Forms.Label();
        this._gridTeamsHistory = new System.Windows.Forms.DataGridView();
        this._colHistoryTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colHistoryAssigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colHistoryEffective = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colHistoryRemoved = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._pageEmployment = new System.Windows.Forms.TabPage("Employment History");
        this._gridEmployment = new System.Windows.Forms.DataGridView();
        this._colEmpHireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colEmpSepDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colEmpReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colEmpNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._btnClose = new System.Windows.Forms.Button();
        this._pnlHeader.SuspendLayout();
        this._pnlNameStack.SuspendLayout();
        this._pnlHeaderButtons.SuspendLayout();
        this._pnlTitleToolbar.SuspendLayout();
        this._pnlTeamToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this._gridTitles).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this._gridTeamsCurrent).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this._gridTeamsHistory).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this._gridEmployment).BeginInit();
        this.SuspendLayout();

        // _pnlHeader
        this._pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
        this._pnlHeader.Controls.Add(this._pnlHeaderButtons);
        this._pnlHeader.Controls.Add(this._pnlNameStack);
        this._pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this._pnlHeader.Height = 100;
        this._pnlHeader.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);

        // _pnlNameStack
        this._pnlNameStack.BackColor = System.Drawing.Color.Transparent;
        this._pnlNameStack.Controls.Add(this._lblStatus);
        this._pnlNameStack.Controls.Add(this._lblName);
        this._pnlNameStack.Dock = System.Windows.Forms.DockStyle.Left;
        this._pnlNameStack.Width = 690;

        // _lblName
        this._lblName.Dock = System.Windows.Forms.DockStyle.Top;
        this._lblName.Font = new System.Drawing.Font("Segoe UI", 20f, System.Drawing.FontStyle.Bold);
        this._lblName.ForeColor = System.Drawing.Color.White;
        this._lblName.Height = 54;
        this._lblName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

        // _lblStatus
        this._lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
        this._lblStatus.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Italic);
        this._lblStatus.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
        this._lblStatus.Height = 33;
        this._lblStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft;

        // _pnlHeaderButtons
        this._pnlHeaderButtons.BackColor = System.Drawing.Color.Transparent;
        this._pnlHeaderButtons.Controls.AddRange(new System.Windows.Forms.Control[] { this._btnSeparate, this._btnReHire, this._btnEdit });
        this._pnlHeaderButtons.Dock = System.Windows.Forms.DockStyle.Right;
        this._pnlHeaderButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this._pnlHeaderButtons.Padding = new System.Windows.Forms.Padding(0, 28, 0, 0);
        this._pnlHeaderButtons.Width = 435;

        // _btnSeparate
        this._btnSeparate.AutoSize = true;
        this._btnSeparate.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
        this._btnSeparate.Cursor = System.Windows.Forms.Cursors.Hand;
        this._btnSeparate.FlatAppearance.BorderSize = 0;
        this._btnSeparate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnSeparate.ForeColor = System.Drawing.Color.White;
        this._btnSeparate.Height = 45;
        this._btnSeparate.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
        this._btnSeparate.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
        this._btnSeparate.Text = "Separate";
        this._btnSeparate.Click += BtnSeparate_Click;

        // _btnReHire
        this._btnReHire.AutoSize = true;
        this._btnReHire.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
        this._btnReHire.Cursor = System.Windows.Forms.Cursors.Hand;
        this._btnReHire.FlatAppearance.BorderSize = 0;
        this._btnReHire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnReHire.ForeColor = System.Drawing.Color.White;
        this._btnReHire.Height = 45;
        this._btnReHire.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
        this._btnReHire.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
        this._btnReHire.Text = "Re-hire";
        this._btnReHire.Click += BtnReHire_Click;

        // _btnEdit
        this._btnEdit.AutoSize = true;
        this._btnEdit.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
        this._btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
        this._btnEdit.FlatAppearance.BorderSize = 0;
        this._btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnEdit.ForeColor = System.Drawing.Color.White;
        this._btnEdit.Height = 45;
        this._btnEdit.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
        this._btnEdit.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
        this._btnEdit.Text = "Edit Info";
        this._btnEdit.Click += BtnEdit_Click;

        // _tabs
        this._tabs.Dock = System.Windows.Forms.DockStyle.Fill;
        this._tabs.Font = new System.Drawing.Font("Segoe UI", 14f);
        this._tabs.TabPages.Add(this._pageJobTitles);
        this._tabs.TabPages.Add(this._pageTeams);
        this._tabs.TabPages.Add(this._pageEmployment);

        // _pageJobTitles
        this._pageJobTitles.Controls.Add(this._gridTitles);
        this._pageJobTitles.Controls.Add(this._pnlTitleToolbar);

        // _pnlTitleToolbar
        this._pnlTitleToolbar.Controls.Add(this._btnAddTitle);
        this._pnlTitleToolbar.Dock = System.Windows.Forms.DockStyle.Top;
        this._pnlTitleToolbar.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        this._pnlTitleToolbar.Height = 60;
        this._pnlTitleToolbar.Padding = new System.Windows.Forms.Padding(8, 9, 0, 0);

        // _btnAddTitle
        this._btnAddTitle.AutoSize = true;
        this._btnAddTitle.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
        this._btnAddTitle.Cursor = System.Windows.Forms.Cursors.Hand;
        this._btnAddTitle.FlatAppearance.BorderSize = 0;
        this._btnAddTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnAddTitle.ForeColor = System.Drawing.Color.White;
        this._btnAddTitle.Height = 40;
        this._btnAddTitle.Margin = new System.Windows.Forms.Padding(0, 0, 9, 0);
        this._btnAddTitle.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
        this._btnAddTitle.Text = "+ Add Title";
        this._btnAddTitle.Click += BtnAddTitle_Click;

        // _gridTitles
        this._gridTitles.AllowUserToAddRows = false;
        this._gridTitles.AllowUserToDeleteRows = false;
        this._gridTitles.BackgroundColor = System.Drawing.Color.White;
        this._gridTitles.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this._gridTitles.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
        this._gridTitles.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
        this._gridTitles.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this._gridTitles.ColumnHeadersHeight = 42;
        this._gridTitles.Columns.AddRange(this._colTitleName, this._colTitleDate, this._colTitleCurrent);
        this._gridTitles.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14f);
        this._gridTitles.Dock = System.Windows.Forms.DockStyle.Fill;
        this._gridTitles.EnableHeadersVisualStyles = false;
        this._gridTitles.GridColor = System.Drawing.Color.FromArgb(220, 230, 240);
        this._gridTitles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 240, 255);
        this._gridTitles.MultiSelect = false;
        this._gridTitles.ReadOnly = true;
        this._gridTitles.RowHeadersVisible = false;
        this._gridTitles.RowTemplate.Height = 40;
        this._gridTitles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this._gridTitles.CellDoubleClick += GridTitles_CellDoubleClick;

        // _colTitleName
        this._colTitleName.HeaderText = "Title";
        this._colTitleName.Width = 390;

        // _colTitleDate
        this._colTitleDate.HeaderText = "Effective Date";
        this._colTitleDate.Width = 195;

        // _colTitleCurrent
        this._colTitleCurrent.HeaderText = "Current?";
        this._colTitleCurrent.Width = 120;

        // _pageTeams
        this._pageTeams.Controls.Add(this._splitTeams);

        // _splitTeams
        this._splitTeams.Dock = System.Windows.Forms.DockStyle.Fill;
        this._splitTeams.Orientation = System.Windows.Forms.Orientation.Horizontal;
        this._splitTeams.Panel1MinSize = 180;
        this._splitTeams.Panel2MinSize = 120;
        this._splitTeams.Panel1.Controls.Add(this._gridTeamsCurrent);
        this._splitTeams.Panel1.Controls.Add(this._pnlTeamToolbar);
        this._splitTeams.Panel1.Controls.Add(this._lblCurrentTeams);
        this._splitTeams.Panel2.Controls.Add(this._gridTeamsHistory);
        this._splitTeams.Panel2.Controls.Add(this._lblTeamHistory);

        // _lblCurrentTeams
        this._lblCurrentTeams.Dock = System.Windows.Forms.DockStyle.Top;
        this._lblCurrentTeams.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        this._lblCurrentTeams.Height = 33;
        this._lblCurrentTeams.Text = "Current Assignments";

        // _pnlTeamToolbar
        this._pnlTeamToolbar.Controls.AddRange(new System.Windows.Forms.Control[] { this._btnAddTeam, this._btnRemoveTeam });
        this._pnlTeamToolbar.Dock = System.Windows.Forms.DockStyle.Top;
        this._pnlTeamToolbar.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        this._pnlTeamToolbar.Height = 54;
        this._pnlTeamToolbar.Padding = new System.Windows.Forms.Padding(6, 6, 0, 0);

        // _btnAddTeam
        this._btnAddTeam.AutoSize = true;
        this._btnAddTeam.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
        this._btnAddTeam.Cursor = System.Windows.Forms.Cursors.Hand;
        this._btnAddTeam.FlatAppearance.BorderSize = 0;
        this._btnAddTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnAddTeam.ForeColor = System.Drawing.Color.White;
        this._btnAddTeam.Height = 40;
        this._btnAddTeam.Margin = new System.Windows.Forms.Padding(0, 0, 9, 0);
        this._btnAddTeam.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
        this._btnAddTeam.Text = "+ Assign Team";
        this._btnAddTeam.Click += BtnAddTeam_Click;

        // _btnRemoveTeam
        this._btnRemoveTeam.AutoSize = true;
        this._btnRemoveTeam.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
        this._btnRemoveTeam.Cursor = System.Windows.Forms.Cursors.Hand;
        this._btnRemoveTeam.FlatAppearance.BorderSize = 0;
        this._btnRemoveTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnRemoveTeam.ForeColor = System.Drawing.Color.White;
        this._btnRemoveTeam.Height = 40;
        this._btnRemoveTeam.Margin = new System.Windows.Forms.Padding(0, 0, 9, 0);
        this._btnRemoveTeam.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
        this._btnRemoveTeam.Text = "Remove";
        this._btnRemoveTeam.Click += BtnRemoveTeam_Click;

        // _gridTeamsCurrent
        this._gridTeamsCurrent.AllowUserToAddRows = false;
        this._gridTeamsCurrent.AllowUserToDeleteRows = false;
        this._gridTeamsCurrent.BackgroundColor = System.Drawing.Color.White;
        this._gridTeamsCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this._gridTeamsCurrent.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
        this._gridTeamsCurrent.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
        this._gridTeamsCurrent.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this._gridTeamsCurrent.ColumnHeadersHeight = 42;
        this._gridTeamsCurrent.Columns.AddRange(this._colCurrentTeam, this._colCurrentAssigned, this._colCurrentEffective);
        this._gridTeamsCurrent.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14f);
        this._gridTeamsCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
        this._gridTeamsCurrent.EnableHeadersVisualStyles = false;
        this._gridTeamsCurrent.GridColor = System.Drawing.Color.FromArgb(220, 230, 240);
        this._gridTeamsCurrent.MultiSelect = false;
        this._gridTeamsCurrent.ReadOnly = true;
        this._gridTeamsCurrent.RowHeadersVisible = false;
        this._gridTeamsCurrent.RowTemplate.Height = 40;
        this._gridTeamsCurrent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

        // _colCurrentTeam
        this._colCurrentTeam.HeaderText = "Team/Project";
        this._colCurrentTeam.Width = 300;

        // _colCurrentAssigned
        this._colCurrentAssigned.HeaderText = "Assigned Date";
        this._colCurrentAssigned.Width = 180;

        // _colCurrentEffective
        this._colCurrentEffective.HeaderText = "Effective Date";
        this._colCurrentEffective.Width = 180;

        // _lblTeamHistory
        this._lblTeamHistory.Dock = System.Windows.Forms.DockStyle.Top;
        this._lblTeamHistory.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        this._lblTeamHistory.Height = 33;
        this._lblTeamHistory.Text = "History";

        // _gridTeamsHistory
        this._gridTeamsHistory.AllowUserToAddRows = false;
        this._gridTeamsHistory.AllowUserToDeleteRows = false;
        this._gridTeamsHistory.BackgroundColor = System.Drawing.Color.White;
        this._gridTeamsHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this._gridTeamsHistory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
        this._gridTeamsHistory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
        this._gridTeamsHistory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this._gridTeamsHistory.ColumnHeadersHeight = 42;
        this._gridTeamsHistory.Columns.AddRange(this._colHistoryTeam, this._colHistoryAssigned, this._colHistoryEffective, this._colHistoryRemoved);
        this._gridTeamsHistory.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14f);
        this._gridTeamsHistory.Dock = System.Windows.Forms.DockStyle.Fill;
        this._gridTeamsHistory.EnableHeadersVisualStyles = false;
        this._gridTeamsHistory.GridColor = System.Drawing.Color.FromArgb(220, 230, 240);
        this._gridTeamsHistory.MultiSelect = false;
        this._gridTeamsHistory.ReadOnly = true;
        this._gridTeamsHistory.RowHeadersVisible = false;
        this._gridTeamsHistory.RowTemplate.Height = 40;
        this._gridTeamsHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

        // _colHistoryTeam
        this._colHistoryTeam.HeaderText = "Team/Project";
        this._colHistoryTeam.Width = 300;

        // _colHistoryAssigned
        this._colHistoryAssigned.HeaderText = "Assigned";
        this._colHistoryAssigned.Width = 165;

        // _colHistoryEffective
        this._colHistoryEffective.HeaderText = "Effective";
        this._colHistoryEffective.Width = 165;

        // _colHistoryRemoved
        this._colHistoryRemoved.HeaderText = "Removed";
        this._colHistoryRemoved.Width = 165;

        // _pageEmployment
        this._pageEmployment.Controls.Add(this._gridEmployment);

        // _gridEmployment
        this._gridEmployment.AllowUserToAddRows = false;
        this._gridEmployment.AllowUserToDeleteRows = false;
        this._gridEmployment.BackgroundColor = System.Drawing.Color.White;
        this._gridEmployment.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this._gridEmployment.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
        this._gridEmployment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
        this._gridEmployment.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this._gridEmployment.ColumnHeadersHeight = 42;
        this._gridEmployment.Columns.AddRange(this._colEmpHireDate, this._colEmpSepDate, this._colEmpReason, this._colEmpNotes);
        this._gridEmployment.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14f);
        this._gridEmployment.Dock = System.Windows.Forms.DockStyle.Fill;
        this._gridEmployment.EnableHeadersVisualStyles = false;
        this._gridEmployment.GridColor = System.Drawing.Color.FromArgb(220, 230, 240);
        this._gridEmployment.MultiSelect = false;
        this._gridEmployment.ReadOnly = true;
        this._gridEmployment.RowHeadersVisible = false;
        this._gridEmployment.RowTemplate.Height = 40;
        this._gridEmployment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

        // _colEmpHireDate
        this._colEmpHireDate.HeaderText = "Hire Date";
        this._colEmpHireDate.Width = 165;

        // _colEmpSepDate
        this._colEmpSepDate.HeaderText = "Separation Date";
        this._colEmpSepDate.Width = 180;

        // _colEmpReason
        this._colEmpReason.HeaderText = "Reason";
        this._colEmpReason.Width = 255;

        // _colEmpNotes
        this._colEmpNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this._colEmpNotes.HeaderText = "Notes";
        this._colEmpNotes.Width = 390;

        // _btnClose
        this._btnClose.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
        this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
        this._btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
        this._btnClose.FlatAppearance.BorderSize = 0;
        this._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnClose.ForeColor = System.Drawing.Color.White;
        this._btnClose.Height = 54;
        this._btnClose.Text = "Close";

        // PersonDetailForm
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this._tabs);
        this.Controls.Add(this._pnlHeader);
        this.Controls.Add(this._btnClose);
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MinimumSize = new System.Drawing.Size(980, 750);
        this.Size = new System.Drawing.Size(1220, 930);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Person Details";

        this._pnlHeader.ResumeLayout(false);
        this._pnlNameStack.ResumeLayout(false);
        this._pnlHeaderButtons.ResumeLayout(false);
        this._pnlTitleToolbar.ResumeLayout(false);
        this._pnlTeamToolbar.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this._gridTitles).EndInit();
        ((System.ComponentModel.ISupportInitialize)this._gridTeamsCurrent).EndInit();
        ((System.ComponentModel.ISupportInitialize)this._gridTeamsHistory).EndInit();
        ((System.ComponentModel.ISupportInitialize)this._gridEmployment).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Panel        _pnlHeader;
    private System.Windows.Forms.Panel        _pnlNameStack;
    private System.Windows.Forms.Label        _lblName;
    private System.Windows.Forms.Label        _lblStatus;
    private System.Windows.Forms.FlowLayoutPanel _pnlHeaderButtons;
    private System.Windows.Forms.Button       _btnSeparate;
    private System.Windows.Forms.Button       _btnReHire;
    private System.Windows.Forms.Button       _btnEdit;
    private System.Windows.Forms.TabControl   _tabs;
    private System.Windows.Forms.TabPage      _pageJobTitles;
    private System.Windows.Forms.FlowLayoutPanel _pnlTitleToolbar;
    private System.Windows.Forms.Button       _btnAddTitle;
    private System.Windows.Forms.DataGridView _gridTitles;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colTitleName;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colTitleDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colTitleCurrent;
    private System.Windows.Forms.TabPage      _pageTeams;
    private System.Windows.Forms.SplitContainer _splitTeams;
    private System.Windows.Forms.Label        _lblCurrentTeams;
    private System.Windows.Forms.FlowLayoutPanel _pnlTeamToolbar;
    private System.Windows.Forms.Button       _btnAddTeam;
    private System.Windows.Forms.Button       _btnRemoveTeam;
    private System.Windows.Forms.DataGridView _gridTeamsCurrent;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colCurrentTeam;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colCurrentAssigned;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colCurrentEffective;
    private System.Windows.Forms.Label        _lblTeamHistory;
    private System.Windows.Forms.DataGridView _gridTeamsHistory;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colHistoryTeam;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colHistoryAssigned;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colHistoryEffective;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colHistoryRemoved;
    private System.Windows.Forms.TabPage      _pageEmployment;
    private System.Windows.Forms.DataGridView _gridEmployment;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colEmpHireDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colEmpSepDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colEmpReason;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colEmpNotes;
    private System.Windows.Forms.Button       _btnClose;
}
