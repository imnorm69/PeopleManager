namespace PeopleManager.Forms;

partial class AssignQuestionForm
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
        this._lblInfo = new System.Windows.Forms.Label();
        this._grid = new System.Windows.Forms.DataGridView();
        this._colAssigned = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this._colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this._colFreq = new System.Windows.Forms.DataGridViewComboBoxColumn();
        this._btnPanel = new System.Windows.Forms.Panel();
        this._btnSave = new System.Windows.Forms.Button();
        this._btnCancel = new System.Windows.Forms.Button();
        this._btnPanel.SuspendLayout();
        this.SuspendLayout();

        // _lblInfo
        this._lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
        this._lblInfo.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Italic);
        this._lblInfo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
        this._lblInfo.Height = 42;
        this._lblInfo.Padding = new System.Windows.Forms.Padding(8, 9, 0, 0);
        this._lblInfo.Text = "Check each person to assign this question. Set the review frequency per person.";

        // _grid
        this._grid.AllowUserToAddRows = false;
        this._grid.AllowUserToDeleteRows = false;
        this._grid.BackgroundColor = System.Drawing.Color.White;
        this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this._grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
        this._grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        this._grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this._grid.ColumnHeadersHeight = 45;
        this._grid.Columns.AddRange(this._colAssigned, this._colName, this._colFreq);
        this._grid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14f);
        this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
        this._grid.EnableHeadersVisualStyles = false;
        this._grid.GridColor = System.Drawing.Color.FromArgb(220, 230, 240);
        this._grid.MultiSelect = false;
        this._grid.RowHeadersVisible = false;
        this._grid.RowTemplate.Height = 42;
        this._grid.CellValueChanged += OnCellValueChanged;
        this._grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;

        // _colAssigned
        this._colAssigned.FalseValue = false;
        this._colAssigned.HeaderText = "Assign";
        this._colAssigned.Name = "Assigned";
        this._colAssigned.TrueValue = true;
        this._colAssigned.Width = 90;

        // _colName
        this._colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this._colName.HeaderText = "Person";
        this._colName.Name = "PersonName";
        this._colName.ReadOnly = true;

        // _colFreq
        this._colFreq.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
        this._colFreq.HeaderText = "Frequency";
        this._colFreq.Name = "Frequency";
        this._colFreq.Width = 210;

        // _btnPanel
        this._btnPanel.BackColor = System.Drawing.Color.White;
        this._btnPanel.Controls.Add(this._btnSave);
        this._btnPanel.Controls.Add(this._btnCancel);
        this._btnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        this._btnPanel.Height = 70;
        this._btnPanel.Padding = new System.Windows.Forms.Padding(8, 12, 8, 12);

        // _btnSave
        this._btnSave.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
        this._btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
        this._btnSave.Dock = System.Windows.Forms.DockStyle.Right;
        this._btnSave.FlatAppearance.BorderSize = 0;
        this._btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnSave.ForeColor = System.Drawing.Color.White;
        this._btnSave.Height = 45;
        this._btnSave.Text = "Save";
        this._btnSave.Width = 135;
        this._btnSave.Click += BtnSave_Click;

        // _btnCancel
        this._btnCancel.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
        this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this._btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
        this._btnCancel.FlatAppearance.BorderSize = 0;
        this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnCancel.ForeColor = System.Drawing.Color.White;
        this._btnCancel.Height = 45;
        this._btnCancel.Text = "Cancel";
        this._btnCancel.Width = 120;

        // AssignQuestionForm
        this.AcceptButton = this._btnSave;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this._btnCancel;
        this.Controls.Add(this._grid);
        this.Controls.Add(this._lblInfo);
        this.Controls.Add(this._btnPanel);
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MinimumSize = new System.Drawing.Size(680, 510);
        this.Size = new System.Drawing.Size(820, 660);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Assign Question to People";

        this._btnPanel.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label _lblInfo;
    private System.Windows.Forms.DataGridView _grid;
    private System.Windows.Forms.DataGridViewCheckBoxColumn _colAssigned;
    private System.Windows.Forms.DataGridViewTextBoxColumn _colName;
    private System.Windows.Forms.DataGridViewComboBoxColumn _colFreq;
    private System.Windows.Forms.Panel _btnPanel;
    private System.Windows.Forms.Button _btnSave;
    private System.Windows.Forms.Button _btnCancel;
}
