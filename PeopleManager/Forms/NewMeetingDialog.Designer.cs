namespace PeopleManager.Forms;

partial class NewMeetingDialog
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
        layout = new TableLayoutPanel();
        _lblPerson = new Label();
        _cboPerson = new ComboBox();
        _lblDate = new Label();
        _dtp = new DateTimePicker();
        btnPanel = new FlowLayoutPanel();
        btnCancel = new Button();
        btnOK = new Button();
        layout.SuspendLayout();
        btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // layout
        // 
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(_lblPerson, 0, 0);
        layout.Controls.Add(_cboPerson, 1, 0);
        layout.Controls.Add(_lblDate, 0, 1);
        layout.Controls.Add(_dtp, 1, 1);
        layout.Controls.Add(btnPanel, 0, 2);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.Padding = new Padding(16);
        layout.RowCount = 3;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
        layout.Size = new Size(504, 221);
        layout.TabIndex = 0;
        // 
        // _lblPerson
        // 
        _lblPerson.Dock = DockStyle.Fill;
        _lblPerson.Location = new Point(19, 16);
        _lblPerson.Name = "_lblPerson";
        _lblPerson.Size = new Size(114, 51);
        _lblPerson.TabIndex = 0;
        _lblPerson.Text = "Person *";
        _lblPerson.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _cboPerson
        // 
        _cboPerson.Dock = DockStyle.Fill;
        _cboPerson.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboPerson.Location = new Point(139, 19);
        _cboPerson.Name = "_cboPerson";
        _cboPerson.Size = new Size(346, 33);
        _cboPerson.TabIndex = 1;
        // 
        // _lblDate
        // 
        _lblDate.Dock = DockStyle.Fill;
        _lblDate.Location = new Point(19, 67);
        _lblDate.Name = "_lblDate";
        _lblDate.Size = new Size(114, 51);
        _lblDate.TabIndex = 2;
        _lblDate.Text = "Date";
        _lblDate.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _dtp
        // 
        _dtp.Dock = DockStyle.Fill;
        _dtp.Format = DateTimePickerFormat.Short;
        _dtp.Location = new Point(139, 70);
        _dtp.Name = "_dtp";
        _dtp.Size = new Size(346, 32);
        _dtp.TabIndex = 3;
        // 
        // btnPanel
        // 
        layout.SetColumnSpan(btnPanel, 2);
        btnPanel.Controls.Add(btnCancel);
        btnPanel.Controls.Add(btnOK);
        btnPanel.Dock = DockStyle.Fill;
        btnPanel.FlowDirection = FlowDirection.RightToLeft;
        btnPanel.Location = new Point(19, 121);
        btnPanel.Name = "btnPanel";
        btnPanel.Padding = new Padding(0, 6, 0, 0);
        btnPanel.Size = new Size(466, 81);
        btnPanel.TabIndex = 4;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(343, 9);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(120, 38);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancel";
        // 
        // btnOK
        // 
        btnOK.DialogResult = DialogResult.OK;
        btnOK.Location = new Point(217, 9);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(120, 38);
        btnOK.TabIndex = 1;
        btnOK.Text = "OK";
        btnOK.Click += BtnOK_Click;
        // 
        // NewMeetingDialog
        // 
        AcceptButton = btnOK;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(504, 221);
        Controls.Add(layout);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "NewMeetingDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "New 1:1 Meeting";
        layout.ResumeLayout(false);
        btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label _lblPerson;
    private System.Windows.Forms.ComboBox _cboPerson;
    private System.Windows.Forms.Label _lblDate;
    private System.Windows.Forms.DateTimePicker _dtp;
    private TableLayoutPanel layout;
    private FlowLayoutPanel btnPanel;
    private Button btnCancel;
    private Button btnOK;
}
