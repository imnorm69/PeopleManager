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
        _layout = new TableLayoutPanel();
        _lblPerson = new Label();
        _cboPerson = new ComboBox();
        _lblDate = new Label();
        _dtp = new DateTimePicker();
        _btnPanel = new FlowLayoutPanel();
        _btnCancel = new Button();
        _btnOK = new Button();
        _layout.SuspendLayout();
        _btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _layout
        // 
        _layout.ColumnCount = 2;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.Controls.Add(_lblPerson, 0, 0);
        _layout.Controls.Add(_cboPerson, 1, 0);
        _layout.Controls.Add(_lblDate, 0, 1);
        _layout.Controls.Add(_dtp, 1, 1);
        _layout.Controls.Add(_btnPanel, 0, 2);
        _layout.Dock = DockStyle.Fill;
        _layout.Location = new Point(0, 0);
        _layout.Name = "_layout";
        _layout.Padding = new Padding(16);
        _layout.RowCount = 3;
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
        _layout.Size = new Size(504, 221);
        _layout.TabIndex = 0;
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
        // _btnPanel
        // 
        _layout.SetColumnSpan(_btnPanel, 2);
        _btnPanel.Controls.Add(_btnCancel);
        _btnPanel.Controls.Add(_btnOK);
        _btnPanel.Dock = DockStyle.Fill;
        _btnPanel.FlowDirection = FlowDirection.RightToLeft;
        _btnPanel.Location = new Point(19, 121);
        _btnPanel.Name = "_btnPanel";
        _btnPanel.Padding = new Padding(0, 6, 0, 0);
        _btnPanel.Size = new Size(466, 81);
        _btnPanel.TabIndex = 4;
        // 
        // _btnCancel
        // 
        _btnCancel.DialogResult = DialogResult.Cancel;
        _btnCancel.Location = new Point(343, 9);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new Size(120, 38);
        _btnCancel.TabIndex = 0;
        _btnCancel.Text = "Cancel";
        // 
        // _btnOK
        // 
        _btnOK.DialogResult = DialogResult.OK;
        _btnOK.Location = new Point(217, 9);
        _btnOK.Name = "_btnOK";
        _btnOK.Size = new Size(120, 38);
        _btnOK.TabIndex = 1;
        _btnOK.Text = "OK";
        _btnOK.Click += BtnOK_Click;
        // 
        // NewMeetingDialog
        // 
        AcceptButton = _btnOK;
        BackColor = Color.White;
        CancelButton = _btnCancel;
        ClientSize = new Size(504, 221);
        Controls.Add(_layout);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "NewMeetingDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "New 1:1 Meeting";
        _layout.ResumeLayout(false);
        _btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label _lblPerson;
    private System.Windows.Forms.ComboBox _cboPerson;
    private System.Windows.Forms.Label _lblDate;
    private System.Windows.Forms.DateTimePicker _dtp;
    private TableLayoutPanel _layout;
    private FlowLayoutPanel _btnPanel;
    private Button _btnCancel;
    private Button _btnOK;
}
