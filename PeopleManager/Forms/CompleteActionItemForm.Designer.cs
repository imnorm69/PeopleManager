namespace PeopleManager.Forms;

partial class CompleteActionItemForm
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
        this._lblActionItemLabel = new System.Windows.Forms.Label();
        this._lblDescription = new System.Windows.Forms.Label();
        this._lblCompletedLabel = new System.Windows.Forms.Label();
        this._dtpCompleted = new System.Windows.Forms.DateTimePicker();
        this._lblNotesLabel = new System.Windows.Forms.Label();
        this._rtbNotes = new System.Windows.Forms.RichTextBox();
        this._btnPanel = new System.Windows.Forms.FlowLayoutPanel();
        this._btnSave = new System.Windows.Forms.Button();
        this._btnCancel = new System.Windows.Forms.Button();
        this._layout.SuspendLayout();
        this._btnPanel.SuspendLayout();
        this.SuspendLayout();

        // _layout
        this._layout.ColumnCount = 2;
        this._layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165));
        this._layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));
        this._layout.Controls.Add(this._lblActionItemLabel, 0, 0);
        this._layout.Controls.Add(this._lblDescription, 1, 0);
        this._layout.Controls.Add(this._lblCompletedLabel, 0, 1);
        this._layout.Controls.Add(this._dtpCompleted, 1, 1);
        this._layout.Controls.Add(this._lblNotesLabel, 0, 2);
        this._layout.Controls.Add(this._rtbNotes, 1, 2);
        this._layout.Controls.Add(this._btnPanel, 0, 3);
        this._layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this._layout.Padding = new System.Windows.Forms.Padding(14);
        this._layout.RowCount = 4;
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60));
        this._layout.SetColumnSpan(this._btnPanel, 2);

        // _lblActionItemLabel
        this._lblActionItemLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblActionItemLabel.Padding = new System.Windows.Forms.Padding(0, 3, 4, 0);
        this._lblActionItemLabel.Text = "Action Item";
        this._lblActionItemLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;

        // _lblDescription
        this._lblDescription.AutoSize = false;
        this._lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblDescription.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Italic);
        this._lblDescription.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
        this._lblDescription.Padding = new System.Windows.Forms.Padding(2);
        this._lblDescription.TextAlign = System.Drawing.ContentAlignment.TopLeft;

        // _lblCompletedLabel
        this._lblCompletedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblCompletedLabel.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
        this._lblCompletedLabel.Text = "Completed";
        this._lblCompletedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // _dtpCompleted
        this._dtpCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
        this._dtpCompleted.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this._dtpCompleted.Value = System.DateTime.Today;

        // _lblNotesLabel
        this._lblNotesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblNotesLabel.Padding = new System.Windows.Forms.Padding(0, 3, 4, 0);
        this._lblNotesLabel.Text = "Notes\n(optional)";
        this._lblNotesLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;

        // _rtbNotes
        this._rtbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
        this._rtbNotes.Font = new System.Drawing.Font("Segoe UI", 14f);
        this._rtbNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

        // _btnPanel
        this._btnPanel.Controls.Add(this._btnCancel);
        this._btnPanel.Controls.Add(this._btnSave);
        this._btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._btnPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this._btnPanel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);

        // _btnSave
        this._btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
        this._btnSave.Text = "Mark Complete";
        this._btnSave.Width = 165;
        this._btnSave.Click += BtnSave_Click;

        // _btnCancel
        this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this._btnCancel.Text = "Cancel";
        this._btnCancel.Width = 120;

        // CompleteActionItemForm
        this.AcceptButton = this._btnSave;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this._btnCancel;
        this.Controls.Add(this._layout);
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(600, 390);
        this.Size = new System.Drawing.Size(700, 450);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Mark Action Item Complete";

        this._layout.ResumeLayout(false);
        this._layout.PerformLayout();
        this._btnPanel.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.TableLayoutPanel _layout;
    private System.Windows.Forms.Label _lblActionItemLabel;
    private System.Windows.Forms.Label _lblDescription;
    private System.Windows.Forms.Label _lblCompletedLabel;
    private System.Windows.Forms.DateTimePicker _dtpCompleted;
    private System.Windows.Forms.Label _lblNotesLabel;
    private System.Windows.Forms.RichTextBox _rtbNotes;
    private System.Windows.Forms.FlowLayoutPanel _btnPanel;
    private System.Windows.Forms.Button _btnSave;
    private System.Windows.Forms.Button _btnCancel;
}
