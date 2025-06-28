namespace FashionApp_Desktop
{
    partial class UcUpdateStyle
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
            label2 = new Label();
            cmbSelectOutfit = new ComboBox();
            btnLoadOutfit = new Button();
            label3 = new Label();
            txtStyleNameUpdate = new TextBox();
            label4 = new Label();
            txtRecommendationUpdate = new TextBox();
            chkIsAvailableUpdate = new CheckBox();
            btnSaveChanges = new Button();
            btnCancelUpdate = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(405, 41);
            label1.TabIndex = 0;
            label1.Text = "Update Existing Fashion Style";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 62);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 1;
            label2.Text = "Select Style:";
            // 
            // cmbSelectOutfit
            // 
            cmbSelectOutfit.FormattingEnabled = true;
            cmbSelectOutfit.Location = new Point(110, 59);
            cmbSelectOutfit.Name = "cmbSelectOutfit";
            cmbSelectOutfit.Size = new Size(167, 28);
            cmbSelectOutfit.TabIndex = 2;
            // 
            // btnLoadOutfit
            // 
            btnLoadOutfit.Location = new Point(283, 57);
            btnLoadOutfit.Name = "btnLoadOutfit";
            btnLoadOutfit.Size = new Size(60, 30);
            btnLoadOutfit.TabIndex = 3;
            btnLoadOutfit.Text = "Load";
            btnLoadOutfit.UseVisualStyleBackColor = true;
            btnLoadOutfit.Click += btnLoadOutfit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 104);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 4;
            label3.Text = "Style Name:";
            // 
            // txtStyleNameUpdate
            // 
            txtStyleNameUpdate.BorderStyle = BorderStyle.FixedSingle;
            txtStyleNameUpdate.Location = new Point(110, 97);
            txtStyleNameUpdate.Name = "txtStyleNameUpdate";
            txtStyleNameUpdate.Size = new Size(167, 27);
            txtStyleNameUpdate.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 148);
            label4.Name = "label4";
            label4.Size = new Size(130, 20);
            label4.TabIndex = 6;
            label4.Text = "Recommendation:";
            // 
            // txtRecommendationUpdate
            // 
            txtRecommendationUpdate.BorderStyle = BorderStyle.FixedSingle;
            txtRecommendationUpdate.Location = new Point(152, 148);
            txtRecommendationUpdate.Multiline = true;
            txtRecommendationUpdate.Name = "txtRecommendationUpdate";
            txtRecommendationUpdate.Size = new Size(318, 50);
            txtRecommendationUpdate.TabIndex = 7;
            // 
            // chkIsAvailableUpdate
            // 
            chkIsAvailableUpdate.AutoSize = true;
            chkIsAvailableUpdate.Location = new Point(110, 224);
            chkIsAvailableUpdate.Name = "chkIsAvailableUpdate";
            chkIsAvailableUpdate.Size = new Size(18, 17);
            chkIsAvailableUpdate.TabIndex = 8;
            chkIsAvailableUpdate.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(16, 320);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(94, 29);
            btnSaveChanges.TabIndex = 9;
            btnSaveChanges.Text = "Save changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnCancelUpdate
            // 
            btnCancelUpdate.Location = new Point(183, 320);
            btnCancelUpdate.Name = "btnCancelUpdate";
            btnCancelUpdate.Size = new Size(94, 29);
            btnCancelUpdate.TabIndex = 10;
            btnCancelUpdate.Text = "Cancel";
            btnCancelUpdate.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 221);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 11;
            label5.Text = "Available:";
            // 
            // UcUpdateStyle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            Controls.Add(label5);
            Controls.Add(btnCancelUpdate);
            Controls.Add(btnSaveChanges);
            Controls.Add(chkIsAvailableUpdate);
            Controls.Add(txtRecommendationUpdate);
            Controls.Add(label4);
            Controls.Add(txtStyleNameUpdate);
            Controls.Add(label3);
            Controls.Add(btnLoadOutfit);
            Controls.Add(cmbSelectOutfit);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UcUpdateStyle";
            Size = new Size(529, 394);
            Load += UcUpdateStyle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbSelectOutfit;
        private Button btnLoadOutfit;
        private Label label3;
        private TextBox txtStyleNameUpdate;
        private Label label4;
        private TextBox txtRecommendationUpdate;
        private CheckBox chkIsAvailableUpdate;
        private Button btnSaveChanges;
        private Button btnCancelUpdate;
        private Label label5;
    }
}
