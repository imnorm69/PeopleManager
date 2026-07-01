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
        _layout = new TableLayoutPanel();
        _lblDesc = new Label();
        _rtbDesc = new RichTextBox();
        _lblAssign = new Label();
        _cboAssignee = new ComboBox();
        _lblDue = new Label();
        _dtpDue = new DateTimePicker();
        _btnPanel = new FlowLayoutPanel();
        _btnCancel = new Button();
        _btnAdd = new Button();
        _pnlBanner.SuspendLayout();
        _layout.SuspendLayout();
        _btnPanel.SuspendLayout();
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
        // _layout
        // 
        _layout.ColumnCount = 2;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.Controls.Add(_lblDesc, 0, 0);
        _layout.Controls.Add(_rtbDesc, 1, 0);
        _layout.Controls.Add(_lblAssign, 0, 1);
        _layout.Controls.Add(_cboAssignee, 1, 1);
        _layout.Controls.Add(_lblDue, 0, 2);
        _layout.Controls.Add(_dtpDue, 1, 2);
        _layout.Controls.Add(_btnPanel, 0, 3);
        _layout.Dock = DockStyle.Fill;
        _layout.Location = new Point(0, 45);
        _layout.Name = "_layout";
        _layout.Padding = new Padding(14);
        _layout.RowCount = 4;
        _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        _layout.Size = new Size(724, 411);
        _layout.TabIndex = 0;
        // 
        // _lblDesc
        // 
        _lblDesc.Dock = DockStyle.Fill;
        _lblDesc.Location = new Point(17, 14);
        _lblDesc.Name = "_lblDesc";
        _lblDesc.Padding = new Padding(0, 5, 4, 0);
        _lblDesc.Size = new Size(129, 221);
        _lblDesc.TabIndex = 0;
        _lblDesc.Text = "Description *";
        _lblDesc.TextAlign = ContentAlignment.TopRight;
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
        // _lblAssign
        // 
        _lblAssign.Dock = DockStyle.Fill;
        _lblAssign.Location = new Point(17, 235);
        _lblAssign.Name = "_lblAssign";
        _lblAssign.Size = new Size(129, 51);
        _lblAssign.TabIndex = 2;
        _lblAssign.Text = "Assign to";
        _lblAssign.TextAlign = ContentAlignment.MiddleRight;
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
        // _lblDue
        // 
        _lblDue.Dock = DockStyle.Fill;
        _lblDue.Location = new Point(17, 286);
        _lblDue.Name = "_lblDue";
        _lblDue.Size = new Size(129, 51);
        _lblDue.TabIndex = 4;
        _lblDue.Text = "Due Date";
        _lblDue.TextAlign = ContentAlignment.MiddleRight;
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
        // _btnPanel
        // 
        _layout.SetColumnSpan(_btnPanel, 2);
        _btnPanel.Controls.Add(_btnCancel);
        _btnPanel.Controls.Add(_btnAdd);
        _btnPanel.Dock = DockStyle.Fill;
        _btnPanel.FlowDirection = FlowDirection.RightToLeft;
        _btnPanel.Location = new Point(17, 340);
        _btnPanel.Name = "_btnPanel";
        _btnPanel.Padding = new Padding(0, 6, 0, 0);
        _btnPanel.Size = new Size(690, 54);
        _btnPanel.TabIndex = 6;
        // 
        // _btnCancel
        // 
        _btnCancel.DialogResult = DialogResult.Cancel;
        _btnCancel.Location = new Point(567, 9);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new Size(120, 23);
        _btnCancel.TabIndex = 0;
        _btnCancel.Text = "Cancel";
        // 
        // _btnAdd
        // 
        _btnAdd.DialogResult = DialogResult.OK;
        _btnAdd.Location = new Point(441, 9);
        _btnAdd.Name = "_btnAdd";
        _btnAdd.Size = new Size(120, 23);
        _btnAdd.TabIndex = 1;
        _btnAdd.Text = "Add";
        _btnAdd.Click += BtnAdd_Click;
        // 
        // AddActionItemForm
        // 
        AcceptButton = _btnAdd;
        BackColor = Color.White;
        CancelButton = _btnCancel;
        ClientSize = new Size(724, 456);
        Controls.Add(_layout);
        Controls.Add(_pnlBanner);
        Font = new Font("Segoe UI", 14F);
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(620, 420);
        Name = "AddActionItemForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add Action Item";
        _pnlBanner.ResumeLayout(false);
        _layout.ResumeLayout(false);
        _layout.PerformLayout();
        _btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel _pnlBanner = null!;
    private System.Windows.Forms.Label _lblBanner = null!;
    private System.Windows.Forms.RichTextBox _rtbDesc = null!;
    private System.Windows.Forms.ComboBox _cboAssignee = null!;
    private System.Windows.Forms.DateTimePicker _dtpDue = null!;
    private TableLayoutPanel _layout;
    private Label _lblDesc;
    private Label _lblAssign;
    private Label _lblDue;
    private FlowLayoutPanel _btnPanel;
    private Button _btnCancel;
    private Button _btnAdd;
}
