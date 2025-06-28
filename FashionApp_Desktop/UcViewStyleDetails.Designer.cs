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
            lblStyleNameTitle.Location = new Point(41, 99);
            lblStyleNameTitle.Name = "lblStyleNameTitle";
            lblStyleNameTitle.Size = new Size(88, 20);
            lblStyleNameTitle.TabIndex = 1;
            lblStyleNameTitle.Text = "Style Name:";
            lblStyleNameTitle.Click += label2_Click;
            // 
            // txtStyleNameDetails
            // 
            txtStyleNameDetails.BackColor = Color.WhiteSmoke;
            txtStyleNameDetails.Location = new Point(190, 88);
            txtStyleNameDetails.Name = "txtStyleNameDetails";
            txtStyleNameDetails.ReadOnly = true;
            txtStyleNameDetails.Size = new Size(125, 27);
            txtStyleNameDetails.TabIndex = 2;
            txtStyleNameDetails.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 134);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 3;
            label2.Text = "Recommendation:";
            label2.Click += label2_Click_1;
            // 
            // txtRecommendationDetails
            // 
            txtRecommendationDetails.Location = new Point(190, 131);
            txtRecommendationDetails.Multiline = true;
            txtRecommendationDetails.Name = "txtRecommendationDetails";
            txtRecommendationDetails.ReadOnly = true;
            txtRecommendationDetails.ScrollBars = ScrollBars.Vertical;
            txtRecommendationDetails.Size = new Size(300, 70);
            txtRecommendationDetails.TabIndex = 4;
            txtRecommendationDetails.TextChanged += textBox1_TextChanged_1;
            // 
            // UcViewStyleDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtRecommendationDetails);
            Controls.Add(label2);
            Controls.Add(txtStyleNameDetails);
            Controls.Add(lblStyleNameTitle);
            Controls.Add(label1);
            Name = "UcViewStyleDetails";
            Size = new Size(530, 400);
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
    }
}
