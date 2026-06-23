namespace PeopleManager.Forms;

partial class ChecklistQuestionForm
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
        _txtDescription = new TextBox();
        _cboValueType = new ComboBox();
        btnPanel = new FlowLayoutPanel();
        btnCancel = new Button();
        btnSave = new Button();
        layout.SuspendLayout();
        btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // layout
        // 
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(_txtDescription, 1, 0);
        layout.Controls.Add(_cboValueType, 1, 1);
        layout.Controls.Add(btnPanel, 0, 2);
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
        layout.Size = new Size(200, 100);
        layout.TabIndex = 0;
        // 
        // _txtDescription
        // 
        _txtDescription.Location = new Point(153, 3);
        _txtDescription.Name = "_txtDescription";
        _txtDescription.Size = new Size(44, 32);
        _txtDescription.TabIndex = 1;
        // 
        // _cboValueType
        // 
        _cboValueType.Location = new Point(153, 54);
        _cboValueType.Name = "_cboValueType";
        _cboValueType.Size = new Size(44, 33);
        _cboValueType.TabIndex = 3;
        // 
        // btnPanel
        // 
        layout.SetColumnSpan(btnPanel, 2);
        btnPanel.Controls.Add(btnCancel);
        btnPanel.Controls.Add(btnSave);
        btnPanel.Location = new Point(3, 105);
        btnPanel.Name = "btnPanel";
        btnPanel.Size = new Size(194, 57);
        btnPanel.TabIndex = 4;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(3, 3);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 0;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(84, 3);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(75, 23);
        btnSave.TabIndex = 1;
        btnSave.Click += BtnSave_Click;
        // 
        // ChecklistQuestionForm
        // 
        AcceptButton = btnSave;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(684, 246);
        Controls.Add(layout);
        Font = new Font("Segoe UI", 14F);
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(560, 255);
        Name = "ChecklistQuestionForm";
        StartPosition = FormStartPosition.CenterParent;
        layout.ResumeLayout(false);
        layout.PerformLayout();
        btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox _txtDescription = null!;
    private System.Windows.Forms.ComboBox _cboValueType = null!;
    private TableLayoutPanel layout;
    private FlowLayoutPanel btnPanel;
    private Button btnCancel;
    private Button btnSave;
}
