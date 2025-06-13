namespace FashionApp
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbOutfits = new System.Windows.Forms.ComboBox();
            this.btnGetRecommendation = new System.Windows.Forms.Button();
            this.txtRecommendation = new System.Windows.Forms.TextBox();
            this.lblSelectedStyle = new System.Windows.Forms.Label();
            this.btnAddStyle = new System.Windows.Forms.Button();
            this.btnManageStyles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Style Selector";
            // 
            // cmbOutfits
            // 
            this.cmbOutfits.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbOutfits.FormattingEnabled = true;
            this.cmbOutfits.Location = new System.Drawing.Point(12, 60);
            this.cmbOutfits.Name = "cmbOutfits";
            this.cmbOutfits.Size = new System.Drawing.Size(300, 31);
            this.cmbOutfits.TabIndex = 1;
            // 
            // btnGetRecommendation
            // 
            this.btnGetRecommendation.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGetRecommendation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetRecommendation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGetRecommendation.ForeColor = System.Drawing.Color.White;
            this.btnGetRecommendation.Location = new System.Drawing.Point(318, 60);
            this.btnGetRecommendation.Name = "btnGetRecommendation";
            this.btnGetRecommendation.Size = new System.Drawing.Size(150, 31);
            this.btnGetRecommendation.TabIndex = 2;
            this.btnGetRecommendation.Text = "Get Recommendation";
            this.btnGetRecommendation.UseVisualStyleBackColor = false;
            this.btnGetRecommendation.Click += new System.EventHandler(this.btnGetRecommendation_Click);
            // 
            // txtRecommendation
            // 
            this.txtRecommendation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRecommendation.Location = new System.Drawing.Point(12, 130);
            this.txtRecommendation.Multiline = true;
            this.txtRecommendation.Name = "txtRecommendation";
            this.txtRecommendation.ReadOnly = true;
            this.txtRecommendation.Size = new System.Drawing.Size(456, 100);
            this.txtRecommendation.TabIndex = 3;
            // 
            // lblSelectedStyle
            // 
            this.lblSelectedStyle.AutoSize = true;
            this.lblSelectedStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelectedStyle.Location = new System.Drawing.Point(12, 100);
            this.lblSelectedStyle.Name = "lblSelectedStyle";
            this.lblSelectedStyle.Size = new System.Drawing.Size(109, 20);
            this.lblSelectedStyle.TabIndex = 4;
            this.lblSelectedStyle.Text = "Selected Style:";
            // 
            // btnAddStyle
            // 
            this.btnAddStyle.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddStyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddStyle.ForeColor = System.Drawing.Color.White;
            this.btnAddStyle.Location = new System.Drawing.Point(12, 250);
            this.btnAddStyle.Name = "btnAddStyle";
            this.btnAddStyle.Size = new System.Drawing.Size(150, 35);
            this.btnAddStyle.TabIndex = 5;
            this.btnAddStyle.Text = "Add New Style";
            this.btnAddStyle.UseVisualStyleBackColor = false;
            this.btnAddStyle.Click += new System.EventHandler(this.btnAddStyle_Click);
            // 
            // btnManageStyles
            // 
            this.btnManageStyles.BackColor = System.Drawing.Color.MediumPurple;
            this.btnManageStyles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStyles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnManageStyles.ForeColor = System.Drawing.Color.White;
            this.btnManageStyles.Location = new System.Drawing.Point(168, 250);
            this.btnManageStyles.Name = "btnManageStyles";
            this.btnManageStyles.Size = new System.Drawing.Size(150, 35);
            this.btnManageStyles.TabIndex = 6;
            this.btnManageStyles.Text = "Manage Styles";
            this.btnManageStyles.UseVisualStyleBackColor = false;
            this.btnManageStyles.Click += new System.EventHandler(this.btnManageStyles_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(482, 303);
            this.Controls.Add(this.btnManageStyles);
            this.Controls.Add(this.btnAddStyle);
            this.Controls.Add(this.lblSelectedStyle);
            this.Controls.Add(this.txtRecommendation);
            this.Controls.Add(this.btnGetRecommendation);
            this.Controls.Add(this.cmbOutfits);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fashion Style Selector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbOutfits;
        private System.Windows.Forms.Button btnGetRecommendation;
        private System.Windows.Forms.TextBox txtRecommendation;
        private System.Windows.Forms.Label lblSelectedStyle;
        private System.Windows.Forms.Button btnAddStyle;
        private System.Windows.Forms.Button btnManageStyles;
    }
}