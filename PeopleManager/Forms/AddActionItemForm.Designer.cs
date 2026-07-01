namespace PeopleManager.Forms;

partial class AddActionItemForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _mentionDrop?.Dispose();
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _pnlBanner = new Panel();
        _lblBanner = new Label();
        layout = new TableLayoutPanel();
        lblDesc = new Label();
        _rtbDesc = new RichTextBox();
        lblAssign = new Label();
        _cboAssignee = new ComboBox();
        lblDue = new Label();
        _dtpDue = new DateTimePicker();
        btnPanel = new FlowLayoutPanel();
        btnCancel = new Button();
        btnAdd = new Button();
        _pnlBanner.SuspendLayout();
        layout.SuspendLayout();
        btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _pnlBanner
        // 
        _pnlBanner.BackColor = Color.FromArgb(30, 58, 95);
        _pnlBanner.Controls.Add(_lblBanner);
        _pnlBanner.Dock = DockStyle.Top;
        _pnlBanner.Location = new Point(0, 0);
        _pnlBanner.Name = "_pnlBanner";
        _pnlBanner.Padding = new Padding(12, 0, 0, 0);
        _pnlBanner.Size = new Size(724, 45);
        _pnlBanner.TabIndex = 1;
        // 
        // _lblBanner
        // 
        _lblBanner.Dock = DockStyle.Fill;
        _lblBanner.Font = new Font("Segoe UI", 13F);
        _lblBanner.ForeColor = Color.White;
        _lblBanner.Location = new Point(12, 0);
        _lblBanner.Name = "_lblBanner";
        _lblBanner.Size = new Size(712, 45);
        _lblBanner.TabIndex = 0;
        _lblBanner.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // layout
        // 
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(lblDesc, 0, 0);
        layout.Controls.Add(_rtbDesc, 1, 0);
        layout.Controls.Add(lblAssign, 0, 1);
        layout.Controls.Add(_cboAssignee, 1, 1);
        layout.Controls.Add(lblDue, 0, 2);
        layout.Controls.Add(_dtpDue, 1, 2);
        layout.Controls.Add(btnPanel, 0, 3);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 45);
        layout.Name = "layout";
        layout.Padding = new Padding(14);
        layout.RowCount = 4;
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layout.Size = new Size(724, 411);
        layout.TabIndex = 0;
        // 
        // lblDesc
        // 
        lblDesc.Dock = DockStyle.Fill;
        lblDesc.Location = new Point(17, 14);
        lblDesc.Name = "lblDesc";
        lblDesc.Padding = new Padding(0, 5, 4, 0);
        lblDesc.Size = new Size(129, 221);
        lblDesc.TabIndex = 0;
        lblDesc.Text = "Description *";
        lblDesc.TextAlign = ContentAlignment.TopRight;
        // 
        // _rtbDesc
        // 
        _rtbDesc.Dock = DockStyle.Fill;
        _rtbDesc.Font = new Font("Segoe UI", 14F);
        _rtbDesc.Location = new Point(152, 17);
        _rtbDesc.Name = "_rtbDesc";
        _rtbDesc.ScrollBars = RichTextBoxScrollBars.Vertical;
        _rtbDesc.Size = new Size(555, 215);
        _rtbDesc.TabIndex = 1;
        _rtbDesc.Text = "";
        _rtbDesc.TextChanged += OnDescTextChanged;
        _rtbDesc.KeyDown += OnDescKeyDown;
        _rtbDesc.Leave += RtbDesc_Leave;
        // 
        // lblAssign
        // 
        lblAssign.Dock = DockStyle.Fill;
        lblAssign.Location = new Point(17, 235);
        lblAssign.Name = "lblAssign";
        lblAssign.Size = new Size(129, 51);
        lblAssign.TabIndex = 2;
        lblAssign.Text = "Assign to";
        lblAssign.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _cboAssignee
        // 
        _cboAssignee.Dock = DockStyle.Fill;
        _cboAssignee.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboAssignee.Location = new Point(152, 238);
        _cboAssignee.Name = "_cboAssignee";
        _cboAssignee.Size = new Size(555, 33);
        _cboAssignee.TabIndex = 3;
        // 
        // lblDue
        // 
        lblDue.Dock = DockStyle.Fill;
        lblDue.Location = new Point(17, 286);
        lblDue.Name = "lblDue";
        lblDue.Size = new Size(129, 51);
        lblDue.TabIndex = 4;
        lblDue.Text = "Due Date";
        lblDue.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _dtpDue
        // 
        _dtpDue.Dock = DockStyle.Fill;
        _dtpDue.Format = DateTimePickerFormat.Short;
        _dtpDue.Location = new Point(152, 289);
        _dtpDue.Name = "_dtpDue";
        _dtpDue.Size = new Size(555, 32);
        _dtpDue.TabIndex = 5;
        // 
        // btnPanel
        // 
        layout.SetColumnSpan(btnPanel, 2);
        btnPanel.Controls.Add(btnCancel);
        btnPanel.Controls.Add(btnAdd);
        btnPanel.Dock = DockStyle.Fill;
        btnPanel.FlowDirection = FlowDirection.RightToLeft;
        btnPanel.Location = new Point(17, 340);
        btnPanel.Name = "btnPanel";
        btnPanel.Padding = new Padding(0, 6, 0, 0);
        btnPanel.Size = new Size(690, 54);
        btnPanel.TabIndex = 6;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(567, 9);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(120, 23);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancel";
        // 
        // btnAdd
        // 
        btnAdd.DialogResult = DialogResult.OK;
        btnAdd.Location = new Point(441, 9);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(120, 23);
        btnAdd.TabIndex = 1;
        btnAdd.Text = "Add";
        btnAdd.Click += BtnAdd_Click;
        // 
        // AddActionItemForm
        // 
        AcceptButton = btnAdd;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(724, 456);
        Controls.Add(layout);
        Controls.Add(_pnlBanner);
        Font = new Font("Segoe UI", 14F);
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(620, 420);
        Name = "AddActionItemForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add Action Item";
        _pnlBanner.ResumeLayout(false);
        layout.ResumeLayout(false);
        layout.PerformLayout();
        btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel _pnlBanner = null!;
    private System.Windows.Forms.Label _lblBanner = null!;
    private System.Windows.Forms.RichTextBox _rtbDesc = null!;
    private System.Windows.Forms.ComboBox _cboAssignee = null!;
    private System.Windows.Forms.DateTimePicker _dtpDue = null!;
    private TableLayoutPanel layout;
    private Label lblDesc;
    private Label lblAssign;
    private Label lblDue;
    private FlowLayoutPanel btnPanel;
    private Button btnCancel;
    private Button btnAdd;
}
