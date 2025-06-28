namespace FashionApp_Desktop
{
    partial class UcDeleteStyleList
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
            dgvOutfitsForDelete = new DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            DeleteButtonColumn = new DataGridViewButtonColumn();
            OutfitModel = new DataGridViewTextBoxColumn();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOutfitsForDelete).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Yu Mincho", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(15, 300);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(234, 44);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Delete Outfits";
            lblTitle.Click += lblTitle_Click;
            // 
            // dgvOutfitsForDelete
            // 
            dgvOutfitsForDelete.AllowUserToAddRows = false;
            dgvOutfitsForDelete.AllowUserToDeleteRows = false;
            dgvOutfitsForDelete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutfitsForDelete.Columns.AddRange(new DataGridViewColumn[] { IdColumn, DeleteButtonColumn, OutfitModel });
            dgvOutfitsForDelete.Dock = DockStyle.Top;
            dgvOutfitsForDelete.Location = new Point(0, 0);
            dgvOutfitsForDelete.Name = "dgvOutfitsForDelete";
            dgvOutfitsForDelete.ReadOnly = true;
            dgvOutfitsForDelete.RowHeadersWidth = 51;
            dgvOutfitsForDelete.Size = new Size(500, 400);
            dgvOutfitsForDelete.TabIndex = 1;
            dgvOutfitsForDelete.CellContentClick += dgvOutfitsForDelete_CellContentClick_1;
            // 
            // IdColumn
            // 
            IdColumn.DataPropertyName = "Id";
            IdColumn.HeaderText = "ID";
            IdColumn.MinimumWidth = 6;
            IdColumn.Name = "IdColumn";
            IdColumn.ReadOnly = true;
            IdColumn.Visible = false;
            IdColumn.Width = 125;
            // 
            // DeleteButtonColumn
            // 
            DeleteButtonColumn.HeaderText = "Action ";
            DeleteButtonColumn.MinimumWidth = 6;
            DeleteButtonColumn.Name = "DeleteButtonColumn";
            DeleteButtonColumn.ReadOnly = true;
            DeleteButtonColumn.Text = "Delete";
            DeleteButtonColumn.UseColumnTextForButtonValue = true;
            DeleteButtonColumn.Width = 125;
            // 
            // OutfitModel
            // 
            OutfitModel.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            OutfitModel.DataPropertyName = "Name";
            OutfitModel.HeaderText = "Outfit Name";
            OutfitModel.MinimumWidth = 6;
            OutfitModel.Name = "OutfitModel";
            OutfitModel.ReadOnly = true;
            OutfitModel.Visible = false;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(15, 354);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // UcDeleteStyleList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBack);
            Controls.Add(lblTitle);
            Controls.Add(dgvOutfitsForDelete);
            Name = "UcDeleteStyleList";
            Size = new Size(500, 400);
            ((System.ComponentModel.ISupportInitialize)dgvOutfitsForDelete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvOutfitsForDelete;
        private Button btnBack;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewButtonColumn DeleteButtonColumn;
        private DataGridViewTextBoxColumn OutfitModel;
    }
}
