namespace PeopleManager.Forms;

partial class AddTeamAssignmentForm
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
        _rbExisting = new RadioButton();
        _rbNew = new RadioButton();
        _cboTeam = new ComboBox();
        _txtNewTeam = new TextBox();
        _dtpAssigned = new DateTimePicker();
        _dtpEffective = new DateTimePicker();
        layout = new TableLayoutPanel();
        lblAssigned = new Label();
        lblEffective = new Label();
        btnPanel = new FlowLayoutPanel();
        btnCancel = new Button();
        btnSave = new Button();
        layout.SuspendLayout();
        btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _rbExisting
        // 
        _rbExisting.Checked = true;
        _rbExisting.Dock = DockStyle.Fill;
        _rbExisting.Location = new Point(19, 19);
        _rbExisting.Name = "_rbExisting";
        _rbExisting.Size = new Size(174, 45);
        _rbExisting.TabIndex = 0;
        _rbExisting.TabStop = true;
        _rbExisting.Text = "Existing team:";
        _rbExisting.CheckedChanged += RbExisting_CheckedChanged;
        // 
        // _rbNew
        // 
        _rbNew.Dock = DockStyle.Fill;
        _rbNew.Location = new Point(19, 70);
        _rbNew.Name = "_rbNew";
        _rbNew.Size = new Size(174, 45);
        _rbNew.TabIndex = 2;
        _rbNew.Text = "New team:";
        _rbNew.CheckedChanged += RbNew_CheckedChanged;
        // 
        // _cboTeam
        // 
        _cboTeam.Dock = DockStyle.Fill;
        _cboTeam.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboTeam.Location = new Point(199, 19);
        _cboTeam.Name = "_cboTeam";
        _cboTeam.Size = new Size(386, 33);
        _cboTeam.TabIndex = 1;
        // 
        // _txtNewTeam
        // 
        _txtNewTeam.Dock = DockStyle.Fill;
        _txtNewTeam.Enabled = false;
        _txtNewTeam.Location = new Point(199, 70);
        _txtNewTeam.Name = "_txtNewTeam";
        _txtNewTeam.Size = new Size(386, 32);
        _txtNewTeam.TabIndex = 3;
        // 
        // _dtpAssigned
        // 
        _dtpAssigned.Dock = DockStyle.Fill;
        _dtpAssigned.Format = DateTimePickerFormat.Short;
        _dtpAssigned.Location = new Point(199, 121);
        _dtpAssigned.Name = "_dtpAssigned";
        _dtpAssigned.Size = new Size(386, 32);
        _dtpAssigned.TabIndex = 5;
        _dtpAssigned.Value = new DateTime(2026, 6, 23, 0, 0, 0, 0);
        // 
        // _dtpEffective
        // 
        _dtpEffective.Dock = DockStyle.Fill;
        _dtpEffective.Format = DateTimePickerFormat.Short;
        _dtpEffective.Location = new Point(199, 172);
        _dtpEffective.Name = "_dtpEffective";
        _dtpEffective.Size = new Size(386, 32);
        _dtpEffective.TabIndex = 7;
        _dtpEffective.Value = new DateTime(2026, 6, 23, 0, 0, 0, 0);
        // 
        // layout
        // 
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(_rbExisting, 0, 0);
        layout.Controls.Add(_cboTeam, 1, 0);
        layout.Controls.Add(_rbNew, 0, 1);
        layout.Controls.Add(_txtNewTeam, 1, 1);
        layout.Controls.Add(lblAssigned, 0, 2);
        layout.Controls.Add(_dtpAssigned, 1, 2);
        layout.Controls.Add(lblEffective, 0, 3);
        layout.Controls.Add(_dtpEffective, 1, 3);
        layout.Controls.Add(btnPanel, 0, 4);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.Padding = new Padding(16);
        layout.RowCount = 5;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layout.Size = new Size(604, 381);
        layout.TabIndex = 0;
        // 
        // lblAssigned
        // 
        lblAssigned.Dock = DockStyle.Fill;
        lblAssigned.Location = new Point(19, 118);
        lblAssigned.Name = "lblAssigned";
        lblAssigned.Size = new Size(174, 51);
        lblAssigned.TabIndex = 4;
        lblAssigned.Text = "Assigned Date *";
        lblAssigned.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblEffective
        // 
        lblEffective.Dock = DockStyle.Fill;
        lblEffective.Location = new Point(19, 169);
        lblEffective.Name = "lblEffective";
        lblEffective.Size = new Size(174, 51);
        lblEffective.TabIndex = 6;
        lblEffective.Text = "Effective Date *";
        lblEffective.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnPanel
        // 
        layout.SetColumnSpan(btnPanel, 2);
        btnPanel.Controls.Add(btnCancel);
        btnPanel.Controls.Add(btnSave);
        btnPanel.Dock = DockStyle.Fill;
        btnPanel.FlowDirection = FlowDirection.RightToLeft;
        btnPanel.Location = new Point(19, 223);
        btnPanel.Name = "btnPanel";
        btnPanel.Padding = new Padding(0, 6, 0, 0);
        btnPanel.Size = new Size(566, 139);
        btnPanel.TabIndex = 8;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(443, 9);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(120, 23);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancel";
        // 
        // btnSave
        // 
        btnSave.DialogResult = DialogResult.OK;
        btnSave.Location = new Point(317, 9);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(120, 23);
        btnSave.TabIndex = 1;
        btnSave.Text = "Save";
        btnSave.Click += BtnSave_Click;
        // 
        // AddTeamAssignmentForm
        // 
        AcceptButton = btnSave;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(604, 381);
        Controls.Add(layout);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AddTeamAssignmentForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Assign to Team / Project";
        layout.ResumeLayout(false);
        layout.PerformLayout();
        btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.RadioButton _rbExisting = null!;
    private System.Windows.Forms.RadioButton _rbNew = null!;
    private System.Windows.Forms.ComboBox _cboTeam = null!;
    private System.Windows.Forms.TextBox _txtNewTeam = null!;
    private System.Windows.Forms.DateTimePicker _dtpAssigned = null!;
    private System.Windows.Forms.DateTimePicker _dtpEffective = null!;
    private TableLayoutPanel layout;
    private Label lblAssigned;
    private Label lblEffective;
    private FlowLayoutPanel btnPanel;
    private Button btnCancel;
    private Button btnSave;
}
