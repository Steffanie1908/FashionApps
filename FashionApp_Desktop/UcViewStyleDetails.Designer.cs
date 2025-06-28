namespace FashionApp_Desktop
{
    partial class UcViewStyleDetails
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
            label1 = new Label();
            lblStyleNameTitle = new Label();
            txtStyleNameDetails = new TextBox();
            label2 = new Label();
            txtRecommendationDetails = new TextBox();
            chkIsAvailableDetails = new CheckBox();
            label3 = new Label();
            btnBackToAllStyles = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(287, 41);
            label1.TabIndex = 0;
            label1.Text = "Fashion Style Details";
            label1.Click += label1_Click;
            // 
            // lblStyleNameTitle
            // 
            lblStyleNameTitle.AutoSize = true;
            lblStyleNameTitle.Location = new Point(47, 67);
            lblStyleNameTitle.Name = "lblStyleNameTitle";
            lblStyleNameTitle.Size = new Size(88, 20);
            lblStyleNameTitle.TabIndex = 1;
            lblStyleNameTitle.Text = "Style Name:";
            lblStyleNameTitle.Click += label2_Click;
            // 
            // txtStyleNameDetails
            // 
            txtStyleNameDetails.BackColor = Color.WhiteSmoke;
            txtStyleNameDetails.Location = new Point(141, 64);
            txtStyleNameDetails.Name = "txtStyleNameDetails";
            txtStyleNameDetails.ReadOnly = true;
            txtStyleNameDetails.Size = new Size(125, 27);
            txtStyleNameDetails.TabIndex = 2;
            txtStyleNameDetails.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 106);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 3;
            label2.Text = "Recommendation:";
            label2.Click += label2_Click_1;
            // 
            // txtRecommendationDetails
            // 
            txtRecommendationDetails.Location = new Point(141, 106);
            txtRecommendationDetails.Multiline = true;
            txtRecommendationDetails.Name = "txtRecommendationDetails";
            txtRecommendationDetails.ReadOnly = true;
            txtRecommendationDetails.Size = new Size(300, 70);
            txtRecommendationDetails.TabIndex = 4;
            txtRecommendationDetails.TextChanged += textBox1_TextChanged_1;
            // 
            // chkIsAvailableDetails
            // 
            chkIsAvailableDetails.AutoCheck = false;
            chkIsAvailableDetails.AutoSize = true;
            chkIsAvailableDetails.Enabled = false;
            chkIsAvailableDetails.Location = new Point(141, 191);
            chkIsAvailableDetails.Name = "chkIsAvailableDetails";
            chkIsAvailableDetails.Size = new Size(18, 17);
            chkIsAvailableDetails.TabIndex = 5;
            chkIsAvailableDetails.UseVisualStyleBackColor = true;
            chkIsAvailableDetails.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 188);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 6;
            label3.Text = "Available: ";
            label3.Click += label3_Click;
            // 
            // btnBackToAllStyles
            // 
            btnBackToAllStyles.Location = new Point(371, 261);
            btnBackToAllStyles.Name = "btnBackToAllStyles";
            btnBackToAllStyles.Size = new Size(70, 30);
            btnBackToAllStyles.TabIndex = 7;
            btnBackToAllStyles.Text = "Back";
            btnBackToAllStyles.UseVisualStyleBackColor = true;
            btnBackToAllStyles.Click += btnBackToAllStyles_Click;
            // 
            // UcViewStyleDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBackToAllStyles);
            Controls.Add(label3);
            Controls.Add(chkIsAvailableDetails);
            Controls.Add(txtRecommendationDetails);
            Controls.Add(label2);
            Controls.Add(txtStyleNameDetails);
            Controls.Add(lblStyleNameTitle);
            Controls.Add(label1);
            Name = "UcViewStyleDetails";
            Size = new Size(458, 314);
            Load += UcViewStyleDetails_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblStyleNameTitle;
        private TextBox txtStyleNameDetails;
        private Label label2;
        private TextBox txtRecommendationDetails;
        private CheckBox chkIsAvailableDetails;
        private Label label3;
        private Button btnBackToAllStyles;
    }
}
