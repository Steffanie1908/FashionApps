namespace FashionApp_Desktop
{
    partial class UcAddNewStyle
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            tblPanelInputs = new TableLayoutPanel();
            label3 = new Label();
            label1 = new Label();
            txtRecommendation = new TextBox();
            label2 = new Label();
            chkIsAvailable = new CheckBox();
            txtName = new TextBox();
            btnSave = new Button();
            tblPanelInputs.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(321, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Fashion Style";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += label1_Click;
            // 
            // tblPanelInputs
            // 
            tblPanelInputs.ColumnCount = 3;
            tblPanelInputs.ColumnStyles.Add(new ColumnStyle());
            tblPanelInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPanelInputs.ColumnStyles.Add(new ColumnStyle());
            tblPanelInputs.Controls.Add(label3, 0, 2);
            tblPanelInputs.Controls.Add(label1, 0, 0);
            tblPanelInputs.Controls.Add(txtRecommendation, 1, 1);
            tblPanelInputs.Controls.Add(label2, 0, 1);
            tblPanelInputs.Controls.Add(chkIsAvailable, 1, 2);
            tblPanelInputs.Controls.Add(txtName, 1, 0);
            tblPanelInputs.Dock = DockStyle.Top;
            tblPanelInputs.Location = new Point(0, 41);
            tblPanelInputs.Name = "tblPanelInputs";
            tblPanelInputs.RowCount = 3;
            tblPanelInputs.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblPanelInputs.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblPanelInputs.RowStyles.Add(new RowStyle());
            tblPanelInputs.Size = new Size(800, 197);
            tblPanelInputs.TabIndex = 1;
            tblPanelInputs.Paint += tblPanelInputs_Paint;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(59, 171);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 2;
            label3.Text = "Available:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 31);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 0;
            label1.Text = "Style Name:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRecommendation
            // 
            txtRecommendation.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtRecommendation.Location = new Point(139, 86);
            txtRecommendation.Multiline = true;
            txtRecommendation.Name = "txtRecommendation";
            txtRecommendation.ScrollBars = ScrollBars.Vertical;
            txtRecommendation.Size = new Size(658, 77);
            txtRecommendation.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 83);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 2;
            label2.Text = "Recommendation:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.Click += label2_Click;
            // 
            // chkIsAvailable
            // 
            chkIsAvailable.AutoSize = true;
            chkIsAvailable.Checked = true;
            chkIsAvailable.CheckState = CheckState.Checked;
            chkIsAvailable.Location = new Point(139, 169);
            chkIsAvailable.Name = "chkIsAvailable";
            chkIsAvailable.Size = new Size(101, 24);
            chkIsAvailable.TabIndex = 4;
            chkIsAvailable.Text = "checkBox1";
            chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(139, 28);
            txtName.Name = "txtName";
            txtName.Size = new Size(658, 27);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(0, 244);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(800, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save New Style";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // UcAddNewStyle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            Controls.Add(tblPanelInputs);
            Controls.Add(lblTitle);
            Controls.Add(btnSave);
            Margin = new Padding(3, 15, 3, 3);
            Name = "UcAddNewStyle";
            Size = new Size(800, 600);
            Load += UcAddNewStyle_Load;
            tblPanelInputs.ResumeLayout(false);
            tblPanelInputs.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TableLayoutPanel tblPanelInputs;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtRecommendation;
        private Button btnSave;
        private Label label3;
        private CheckBox chkIsAvailable;
    }
}
