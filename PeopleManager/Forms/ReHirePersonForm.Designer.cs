namespace PeopleManager.Forms;

partial class ReHirePersonForm
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
        this._lblPersonName = new System.Windows.Forms.Label();
        this._lblNewStartDate = new System.Windows.Forms.Label();
        this._dtpHireDate = new System.Windows.Forms.DateTimePicker();
        this._lblJobTitle = new System.Windows.Forms.Label();
        this._txtJobTitle = new System.Windows.Forms.TextBox();
        this._btnPanel = new System.Windows.Forms.FlowLayoutPanel();
        this._btnReHire = new System.Windows.Forms.Button();
        this._btnCancel = new System.Windows.Forms.Button();
        this._layout.SuspendLayout();
        this._btnPanel.SuspendLayout();
        this.SuspendLayout();

        // _layout
        this._layout.ColumnCount = 2;
        this._layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180));
        this._layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));
        this._layout.Controls.Add(this._lblPersonName, 0, 0);
        this._layout.Controls.Add(this._lblNewStartDate, 0, 1);
        this._layout.Controls.Add(this._dtpHireDate, 1, 1);
        this._layout.Controls.Add(this._lblJobTitle, 0, 2);
        this._layout.Controls.Add(this._txtJobTitle, 1, 2);
        this._layout.Controls.Add(this._btnPanel, 0, 3);
        this._layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this._layout.Padding = new System.Windows.Forms.Padding(20);
        this._layout.RowCount = 4;
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63));
        this._layout.SetColumnSpan(this._lblPersonName, 2);
        this._layout.SetColumnSpan(this._btnPanel, 2);

        // _lblPersonName
        this._lblPersonName.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblPersonName.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
        this._lblPersonName.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
        this._lblPersonName.Text = "";
        this._lblPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // _lblNewStartDate
        this._lblNewStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblNewStartDate.Text = "New Start Date *";
        this._lblNewStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // _dtpHireDate
        this._dtpHireDate.Dock = System.Windows.Forms.DockStyle.Fill;
        this._dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this._dtpHireDate.Value = System.DateTime.Today;

        // _lblJobTitle
        this._lblJobTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblJobTitle.Text = "Job Title *";
        this._lblJobTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // _txtJobTitle
        this._txtJobTitle.Dock = System.Windows.Forms.DockStyle.Fill;

        // _btnPanel
        this._btnPanel.Controls.Add(this._btnCancel);
        this._btnPanel.Controls.Add(this._btnReHire);
        this._btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._btnPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this._btnPanel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);

        // _btnReHire
        this._btnReHire.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
        this._btnReHire.DialogResult = System.Windows.Forms.DialogResult.OK;
        this._btnReHire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this._btnReHire.ForeColor = System.Drawing.Color.White;
        this._btnReHire.Text = "Re-hire";
        this._btnReHire.Width = 120;
        this._btnReHire.FlatAppearance.BorderSize = 0;
        this._btnReHire.Click += BtnReHire_Click;

        // _btnCancel
        this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this._btnCancel.Text = "Cancel";
        this._btnCancel.Width = 120;

        // ReHirePersonForm
        this.AcceptButton = this._btnReHire;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this._btnCancel;
        this.Controls.Add(this._layout);
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Size = new System.Drawing.Size(620, 330);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Re-hire Employee";

        this._layout.ResumeLayout(false);
        this._layout.PerformLayout();
        this._btnPanel.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.TableLayoutPanel _layout;
    private System.Windows.Forms.Label _lblPersonName;
    private System.Windows.Forms.Label _lblNewStartDate;
    private System.Windows.Forms.DateTimePicker _dtpHireDate;
    private System.Windows.Forms.Label _lblJobTitle;
    private System.Windows.Forms.TextBox _txtJobTitle;
    private System.Windows.Forms.FlowLayoutPanel _btnPanel;
    private System.Windows.Forms.Button _btnReHire;
    private System.Windows.Forms.Button _btnCancel;
}
