namespace FashionApp_Desktop
{
    partial class UcViewAllStyles
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
            dgvOutfits = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvOutfits).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(244, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "All Fashion Styles";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvOutfits
            // 
            dgvOutfits.AllowUserToAddRows = false;
            dgvOutfits.AllowUserToDeleteRows = false;
            dgvOutfits.AllowUserToOrderColumns = true;
            dgvOutfits.AllowUserToResizeColumns = false;
            dgvOutfits.BackgroundColor = Color.LightSlateGray;
            dgvOutfits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutfits.Dock = DockStyle.Fill;
            dgvOutfits.Location = new Point(0, 41);
            dgvOutfits.MultiSelect = false;
            dgvOutfits.Name = "dgvOutfits";
            dgvOutfits.ReadOnly = true;
            dgvOutfits.RowHeadersWidth = 51;
            dgvOutfits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOutfits.Size = new Size(800, 559);
            dgvOutfits.TabIndex = 1;
            dgvOutfits.CellContentClick += dataGridView1_CellContentClick;
            // 
            // UcViewAllStyles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvOutfits);
            Controls.Add(lblTitle);
            Name = "UcViewAllStyles";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)dgvOutfits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvOutfits;
    }
}
