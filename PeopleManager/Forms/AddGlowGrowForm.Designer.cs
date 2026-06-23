namespace PeopleManager.Forms;

partial class AddGlowGrowForm
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
        _cboPerson = new ComboBox();
        _cboType = new ComboBox();
        _txtSource = new TextBox();
        _txtNote = new RichTextBox();
        _chkCommunicated = new CheckBox();
        _dtpCommunicated = new DateTimePicker();
        layout = new TableLayoutPanel();
        lblPerson = new Label();
        lblType = new Label();
        lblSource = new Label();
        lblNote = new Label();
        lblDate = new Label();
        btnPanel = new FlowLayoutPanel();
        btnCancel = new Button();
        btnSave = new Button();
        layout.SuspendLayout();
        btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _cboPerson
        // 
        _cboPerson.Dock = DockStyle.Fill;
        _cboPerson.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboPerson.Location = new Point(199, 19);
        _cboPerson.Name = "_cboPerson";
        _cboPerson.Size = new Size(526, 33);
        _cboPerson.TabIndex = 1;
        // 
        // _cboType
        // 
        _cboType.Dock = DockStyle.Fill;
        _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboType.Items.AddRange(new object[] { "Glow", "Grow" });
        _cboType.Location = new Point(199, 70);
        _cboType.Name = "_cboType";
        _cboType.Size = new Size(526, 33);
        _cboType.TabIndex = 3;
        // 
        // _txtSource
        // 
        _txtSource.Dock = DockStyle.Fill;
        _txtSource.Location = new Point(199, 121);
        _txtSource.MaxLength = 500;
        _txtSource.Name = "_txtSource";
        _txtSource.PlaceholderText = "e.g. Emailed from PO, Observed during refinement…";
        _txtSource.Size = new Size(526, 32);
        _txtSource.TabIndex = 5;
        // 
        // _txtNote
        // 
        _txtNote.Dock = DockStyle.Fill;
        _txtNote.Location = new Point(199, 172);
        _txtNote.Name = "_txtNote";
        _txtNote.ScrollBars = RichTextBoxScrollBars.Vertical;
        _txtNote.Size = new Size(526, 238);
        _txtNote.TabIndex = 7;
        _txtNote.Text = "";
        // 
        // _chkCommunicated
        // 
        layout.SetColumnSpan(_chkCommunicated, 2);
        _chkCommunicated.Dock = DockStyle.Fill;
        _chkCommunicated.Location = new Point(19, 416);
        _chkCommunicated.Name = "_chkCommunicated";
        _chkCommunicated.Size = new Size(706, 45);
        _chkCommunicated.TabIndex = 8;
        _chkCommunicated.Text = "Communicated?";
        _chkCommunicated.CheckedChanged += ChkCommunicated_CheckedChanged;
        // 
        // _dtpCommunicated
        // 
        _dtpCommunicated.Dock = DockStyle.Fill;
        _dtpCommunicated.Enabled = false;
        _dtpCommunicated.Format = DateTimePickerFormat.Short;
        _dtpCommunicated.Location = new Point(199, 467);
        _dtpCommunicated.Name = "_dtpCommunicated";
        _dtpCommunicated.Size = new Size(526, 32);
        _dtpCommunicated.TabIndex = 10;
        _dtpCommunicated.Value = new DateTime(2026, 6, 23, 0, 0, 0, 0);
        // 
        // layout
        // 
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(lblPerson, 0, 0);
        layout.Controls.Add(_cboPerson, 1, 0);
        layout.Controls.Add(lblType, 0, 1);
        layout.Controls.Add(_cboType, 1, 1);
        layout.Controls.Add(lblSource, 0, 2);
        layout.Controls.Add(_txtSource, 1, 2);
        layout.Controls.Add(lblNote, 0, 3);
        layout.Controls.Add(_txtNote, 1, 3);
        layout.Controls.Add(_chkCommunicated, 0, 4);
        layout.Controls.Add(lblDate, 0, 5);
        layout.Controls.Add(_dtpCommunicated, 1, 5);
        layout.Controls.Add(btnPanel, 0, 6);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.Padding = new Padding(16);
        layout.RowCount = 7;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layout.Size = new Size(744, 591);
        layout.TabIndex = 0;
        // 
        // lblPerson
        // 
        lblPerson.Dock = DockStyle.Fill;
        lblPerson.Location = new Point(19, 16);
        lblPerson.Name = "lblPerson";
        lblPerson.Size = new Size(174, 51);
        lblPerson.TabIndex = 0;
        lblPerson.Text = "Person *";
        lblPerson.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblType
        // 
        lblType.Dock = DockStyle.Fill;
        lblType.Location = new Point(19, 67);
        lblType.Name = "lblType";
        lblType.Size = new Size(174, 51);
        lblType.TabIndex = 2;
        lblType.Text = "Type *";
        lblType.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblSource
        // 
        lblSource.Dock = DockStyle.Fill;
        lblSource.Location = new Point(19, 118);
        lblSource.Name = "lblSource";
        lblSource.Size = new Size(174, 51);
        lblSource.TabIndex = 4;
        lblSource.Text = "Source";
        lblSource.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblNote
        // 
        lblNote.Dock = DockStyle.Fill;
        lblNote.Location = new Point(19, 169);
        lblNote.Name = "lblNote";
        lblNote.Padding = new Padding(0, 6, 4, 0);
        lblNote.Size = new Size(174, 244);
        lblNote.TabIndex = 6;
        lblNote.Text = "Note *";
        lblNote.TextAlign = ContentAlignment.TopRight;
        // 
        // lblDate
        // 
        lblDate.Dock = DockStyle.Fill;
        lblDate.Location = new Point(19, 464);
        lblDate.Name = "lblDate";
        lblDate.Size = new Size(174, 51);
        lblDate.TabIndex = 9;
        lblDate.Text = "Date:";
        lblDate.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnPanel
        // 
        layout.SetColumnSpan(btnPanel, 2);
        btnPanel.Controls.Add(btnCancel);
        btnPanel.Controls.Add(btnSave);
        btnPanel.Dock = DockStyle.Fill;
        btnPanel.FlowDirection = FlowDirection.RightToLeft;
        btnPanel.Location = new Point(19, 518);
        btnPanel.Name = "btnPanel";
        btnPanel.Padding = new Padding(0, 8, 0, 0);
        btnPanel.Size = new Size(706, 54);
        btnPanel.TabIndex = 11;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(583, 11);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(120, 30);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancel";
        // 
        // btnSave
        // 
        btnSave.DialogResult = DialogResult.OK;
        btnSave.Location = new Point(457, 11);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(120, 30);
        btnSave.TabIndex = 1;
        btnSave.Text = "Save";
        btnSave.Click += BtnSave_Click;
        // 
        // AddGlowGrowForm
        // 
        AcceptButton = btnSave;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(744, 591);
        Controls.Add(layout);
        Font = new Font("Segoe UI", 14F);
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(600, 540);
        Name = "AddGlowGrowForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add Glow/Grow";
        layout.ResumeLayout(false);
        layout.PerformLayout();
        btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox _cboPerson = null!;
    private System.Windows.Forms.ComboBox _cboType = null!;
    private System.Windows.Forms.TextBox _txtSource = null!;
    private System.Windows.Forms.RichTextBox _txtNote = null!;
    private System.Windows.Forms.CheckBox _chkCommunicated = null!;
    private System.Windows.Forms.DateTimePicker _dtpCommunicated = null!;
    private TableLayoutPanel layout;
    private Label lblPerson;
    private Label lblType;
    private Label lblSource;
    private Label lblNote;
    private Label lblDate;
    private FlowLayoutPanel btnPanel;
    private Button btnCancel;
    private Button btnSave;
}
