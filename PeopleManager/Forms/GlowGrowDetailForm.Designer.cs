namespace PeopleManager.Forms;

partial class GlowGrowDetailForm
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
        this._pnlBanner = new System.Windows.Forms.Panel();
        this._lblType = new System.Windows.Forms.Label();
        this._layout = new System.Windows.Forms.TableLayoutPanel();
        this._lblPersonLabel = new System.Windows.Forms.Label();
        this._lblPerson = new System.Windows.Forms.Label();
        this._lblRecordedLabel = new System.Windows.Forms.Label();
        this._lblRecorded = new System.Windows.Forms.Label();
        this._lblSourceLabel = new System.Windows.Forms.Label();
        this._lblSource = new System.Windows.Forms.Label();
        this._lblCommunicatedLabel = new System.Windows.Forms.Label();
        this._lblCommunicated = new System.Windows.Forms.Label();
        this._lblNoteLabel = new System.Windows.Forms.Label();
        this._rtbNote = new System.Windows.Forms.RichTextBox();
        this._btnRow = new System.Windows.Forms.Panel();
        this._btnClose = new System.Windows.Forms.Button();
        this._pnlBanner.SuspendLayout();
        this._layout.SuspendLayout();
        this._btnRow.SuspendLayout();
        this.SuspendLayout();

        // _pnlBanner
        this._pnlBanner.Controls.Add(this._lblType);
        this._pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
        this._pnlBanner.Height = 54;

        // _lblType
        this._lblType.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblType.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
        this._lblType.ForeColor = System.Drawing.Color.White;
        this._lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // _layout
        this._layout.ColumnCount = 2;
        this._layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195));
        this._layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));
        this._layout.Controls.Add(this._lblPersonLabel, 0, 0);
        this._layout.Controls.Add(this._lblPerson, 1, 0);
        this._layout.Controls.Add(this._lblRecordedLabel, 0, 1);
        this._layout.Controls.Add(this._lblRecorded, 1, 1);
        this._layout.Controls.Add(this._lblSourceLabel, 0, 2);
        this._layout.Controls.Add(this._lblSource, 1, 2);
        this._layout.Controls.Add(this._lblCommunicatedLabel, 0, 3);
        this._layout.Controls.Add(this._lblCommunicated, 1, 3);
        this._layout.Controls.Add(this._lblNoteLabel, 0, 4);
        this._layout.Controls.Add(this._rtbNote, 1, 4);
        this._layout.Controls.Add(this._btnRow, 0, 5);
        this._layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this._layout.Padding = new System.Windows.Forms.Padding(16);
        this._layout.RowCount = 6;
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100));
        this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60));
        this._layout.SetColumnSpan(this._btnRow, 2);

        // _lblPersonLabel
        this._lblPersonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblPersonLabel.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        this._lblPersonLabel.Text = "Person:";
        this._lblPersonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // _lblPerson
        this._lblPerson.AutoEllipsis = true;
        this._lblPerson.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // _lblRecordedLabel
        this._lblRecordedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblRecordedLabel.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        this._lblRecordedLabel.Text = "Recorded:";
        this._lblRecordedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // _lblRecorded
        this._lblRecorded.AutoEllipsis = true;
        this._lblRecorded.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblRecorded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // _lblSourceLabel
        this._lblSourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblSourceLabel.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        this._lblSourceLabel.Text = "Source:";
        this._lblSourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // _lblSource
        this._lblSource.AutoEllipsis = true;
        this._lblSource.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // _lblCommunicatedLabel
        this._lblCommunicatedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblCommunicatedLabel.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
        this._lblCommunicatedLabel.Text = "Communicated:";
        this._lblCommunicatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // _lblCommunicated
        this._lblCommunicated.AutoEllipsis = true;
        this._lblCommunicated.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblCommunicated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // _lblNoteLabel
        this._lblNoteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblNoteLabel.Padding = new System.Windows.Forms.Padding(0, 4, 4, 0);
        this._lblNoteLabel.Text = "Note:";
        this._lblNoteLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;

        // _rtbNote
        this._rtbNote.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
        this._rtbNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this._rtbNote.Dock = System.Windows.Forms.DockStyle.Fill;
        this._rtbNote.Font = new System.Drawing.Font("Segoe UI", 14f);
        this._rtbNote.ReadOnly = true;
        this._rtbNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

        // _btnRow
        this._btnRow.Controls.Add(this._btnClose);
        this._btnRow.Dock = System.Windows.Forms.DockStyle.Fill;

        // _btnClose
        this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
        this._btnClose.Dock = System.Windows.Forms.DockStyle.Right;
        this._btnClose.Text = "Close";
        this._btnClose.Width = 120;

        // GlowGrowDetailForm
        this.AcceptButton = this._btnClose;
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this._layout);
        this.Controls.Add(this._pnlBanner);
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(620, 450);
        this.Size = new System.Drawing.Size(760, 570);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Glow/Grow Detail";

        this._pnlBanner.ResumeLayout(false);
        this._layout.ResumeLayout(false);
        this._layout.PerformLayout();
        this._btnRow.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Panel _pnlBanner;
    private System.Windows.Forms.Label _lblType;
    private System.Windows.Forms.TableLayoutPanel _layout;
    private System.Windows.Forms.Label _lblPersonLabel;
    private System.Windows.Forms.Label _lblPerson;
    private System.Windows.Forms.Label _lblRecordedLabel;
    private System.Windows.Forms.Label _lblRecorded;
    private System.Windows.Forms.Label _lblSourceLabel;
    private System.Windows.Forms.Label _lblSource;
    private System.Windows.Forms.Label _lblCommunicatedLabel;
    private System.Windows.Forms.Label _lblCommunicated;
    private System.Windows.Forms.Label _lblNoteLabel;
    private System.Windows.Forms.RichTextBox _rtbNote;
    private System.Windows.Forms.Panel _btnRow;
    private System.Windows.Forms.Button _btnClose;
}
