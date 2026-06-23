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
        this.SuspendLayout();

        // Info label
        var infoLabel = new System.Windows.Forms.Label();
        infoLabel.Text = "Check each person to assign this question. Set the review frequency per person.";
        infoLabel.Dock = System.Windows.Forms.DockStyle.Top;
        infoLabel.Height = 42;
        infoLabel.Padding = new System.Windows.Forms.Padding(8, 9, 0, 0);
        infoLabel.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
        infoLabel.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Italic);

        // Grid
        this._grid = new System.Windows.Forms.DataGridView();
        this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
        this._grid.RowHeadersVisible = false;
        this._grid.MultiSelect = false;
        this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this._grid.BackgroundColor = System.Drawing.Color.White;
        this._grid.GridColor = System.Drawing.Color.FromArgb(220, 230, 240);
        this._grid.EnableHeadersVisualStyles = false;
        this._grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
        this._grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this._grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        this._grid.ColumnHeadersHeight = 45;
        this._grid.RowTemplate.Height = 42;
        this._grid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14f);
        this._grid.AllowUserToAddRows = false;
        this._grid.AllowUserToDeleteRows = false;

        var colAssigned = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        colAssigned.HeaderText = "Assign";
        colAssigned.Width = 90;
        colAssigned.Name = "Assigned";
        colAssigned.TrueValue = true;
        colAssigned.FalseValue = false;

        var colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colName.HeaderText = "Person";
        colName.Name = "PersonName";
        colName.ReadOnly = true;
        colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

        var colFreq = new System.Windows.Forms.DataGridViewComboBoxColumn();
        colFreq.HeaderText = "Frequency";
        colFreq.Width = 210;
        colFreq.Name = "Frequency";
        colFreq.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;

        this._grid.Columns.AddRange(colAssigned, colName, colFreq);

        this._grid.CellValueChanged += OnCellValueChanged;
        this._grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;

        // Button panel
        var btnPanel = new System.Windows.Forms.Panel();
        btnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        btnPanel.Height = 70;
        btnPanel.BackColor = System.Drawing.Color.White;
        btnPanel.Padding = new System.Windows.Forms.Padding(8, 12, 8, 12);
        btnPanel.SuspendLayout();

        var btnSave = new System.Windows.Forms.Button();
        btnSave.Text = "Save";
        btnSave.Width = 135;
        btnSave.Height = 45;
        btnSave.Dock = System.Windows.Forms.DockStyle.Right;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Click += BtnSave_Click;

        var btnCancel = new System.Windows.Forms.Button();
        btnCancel.Text = "Cancel";
        btnCancel.Width = 120;
        btnCancel.Height = 45;
        btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
        btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCancel.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
        btnCancel.ForeColor = System.Drawing.Color.White;
        btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        btnCancel.FlatAppearance.BorderSize = 0;

        btnPanel.Controls.Add(btnSave);
        btnPanel.Controls.Add(btnCancel);
        btnPanel.ResumeLayout(false);

        // Form
        this.Controls.Add(this._grid);
        this.Controls.Add(infoLabel);
        this.Controls.Add(btnPanel);

        this.Text = "Assign Question to People";
        this.Size = new System.Drawing.Size(820, 660);
        this.MinimumSize = new System.Drawing.Size(680, 510);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.BackColor = System.Drawing.Color.White;

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.DataGridView _grid = null!;
}
