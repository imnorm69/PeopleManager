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
        this._layout = new System.Windows.Forms.TableLayoutPanel();
        this._lblQuestion = new System.Windows.Forms.Label();
        this._txtDescription = new System.Windows.Forms.TextBox();
        this._lblValueType = new System.Windows.Forms.Label();
        this._cboValueType = new System.Windows.Forms.ComboBox();
        this._btnPanel = new System.Windows.Forms.FlowLayoutPanel();
        this._btnSave = new System.Windows.Forms.Button();
        this._btnCancel = new System.Windows.Forms.Button();
        this._layout.SuspendLayout();
        this._btnPanel.SuspendLayout();
        this.SuspendLayout();

        // _layout
        this._layout.ColumnCount = 2;
        this._layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
        this._layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this._layout.Controls.Add(this._lblQuestion, 0, 0);
        this._layout.Controls.Add(this._txtDescription, 1, 0);
        this._layout.Controls.Add(this._lblValueType, 0, 1);
        this._layout.Controls.Add(this._cboValueType, 1, 1);
        this._layout.Controls.Add(this._btnPanel, 0, 2);
        this._layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this._layout.Padding = new System.Windows.Forms.Padding(16);
        this._layout.RowCount = 3;
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
        this._layout.SetColumnSpan(this._btnPanel, 2);

        // _lblQuestion
        this._lblQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblQuestion.Text = "Question *";
        this._lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // _txtDescription
        this._txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;

        // _lblValueType
        this._lblValueType.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblValueType.Text = "Value Type *";
        this._lblValueType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // _cboValueType
        this._cboValueType.Dock = System.Windows.Forms.DockStyle.Fill;
        this._cboValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        // _btnPanel
        this._btnPanel.Controls.Add(this._btnCancel);
        this._btnPanel.Controls.Add(this._btnSave);
        this._btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._btnPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this._btnPanel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);

        // _btnSave
        this._btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
        this._btnSave.Text = "Save";
        this._btnSave.Width = 120;
        this._btnSave.Click += BtnSave_Click;

        // _btnCancel
        this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this._btnCancel.Text = "Cancel";
        this._btnCancel.Width = 120;

        // ChecklistQuestionForm
        this.AcceptButton = this._btnSave;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this._btnCancel;
        this.Controls.Add(this._layout);
        this.Font = new System.Drawing.Font("Segoe UI", 14F);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(560, 255);
        this.Size = new System.Drawing.Size(600, 255);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "New Checklist Question";

        this._layout.ResumeLayout(false);
        this._layout.PerformLayout();
        this._btnPanel.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.TableLayoutPanel _layout;
    private System.Windows.Forms.Label _lblQuestion;
    private System.Windows.Forms.TextBox _txtDescription;
    private System.Windows.Forms.Label _lblValueType;
    private System.Windows.Forms.ComboBox _cboValueType;
    private System.Windows.Forms.FlowLayoutPanel _btnPanel;
    private System.Windows.Forms.Button _btnSave;
    private System.Windows.Forms.Button _btnCancel;
}
