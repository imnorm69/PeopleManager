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
        _cboPerson = new ComboBox();
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
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(_cboPerson, 1, 0);
        layout.Controls.Add(_dtp, 1, 1);
        layout.Controls.Add(btnPanel, 0, 2);
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layout.Size = new Size(200, 100);
        layout.TabIndex = 0;
        // 
        // _cboPerson
        // 
        _cboPerson.Location = new Point(93, 3);
        _cboPerson.Name = "_cboPerson";
        _cboPerson.Size = new Size(104, 33);
        _cboPerson.TabIndex = 0;
        // 
        // _dtp
        // 
        _dtp.Location = new Point(93, 54);
        _dtp.Name = "_dtp";
        _dtp.Size = new Size(104, 32);
        _dtp.TabIndex = 1;
        // 
        // btnPanel
        // 
        layout.SetColumnSpan(btnPanel, 2);
        btnPanel.Controls.Add(btnCancel);
        btnPanel.Controls.Add(btnOK);
        btnPanel.Location = new Point(3, 105);
        btnPanel.Name = "btnPanel";
        btnPanel.Size = new Size(194, 54);
        btnPanel.TabIndex = 2;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(3, 3);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 0;
        // 
        // btnOK
        // 
        btnOK.Location = new Point(84, 3);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(75, 23);
        btnOK.TabIndex = 1;
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

    private static System.Windows.Forms.Label MkLabel(string text) => new()
    {
        Text = text,
        TextAlign = System.Drawing.ContentAlignment.MiddleRight,
        Dock = System.Windows.Forms.DockStyle.Fill
    };

    private System.Windows.Forms.ComboBox _cboPerson = null!;
    private System.Windows.Forms.DateTimePicker _dtp = null!;
    private TableLayoutPanel layout;
    private FlowLayoutPanel btnPanel;
    private Button btnCancel;
    private Button btnOK;
}
