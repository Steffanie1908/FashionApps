using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FashionApp_Business_Logic;
using FashionApp_Data_Logic; 

namespace FashionApp_Desktop 
{
    public partial class UcViewAllStyles : UserControl
    {
        private OutfitService _outfitService;
        public event EventHandler<OutfitSelectedEventArgs> OutfitSelected;

        public UcViewAllStyles(OutfitService outfitService)
        {
            InitializeComponent();
            _outfitService = outfitService;
            dataGridViewOutfits.AutoGenerateColumns = false; 
            InitializeDataGridViewColumns(); 
            LoadOutfits();
        }

        private void InitializeDataGridViewColumns()
        {
            dataGridViewOutfits.Columns.Clear(); 

            dataGridViewOutfits.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", ReadOnly = true, Visible = false }); // Hidden but available
            dataGridViewOutfits.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Name", HeaderText = "Style Name", DataPropertyName = "Name", ReadOnly = true });
            dataGridViewOutfits.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Recommendation", HeaderText = "Recommendation", DataPropertyName = "Recommendation", ReadOnly = true });
            dataGridViewOutfits.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "IsAvailable", HeaderText = "Available", DataPropertyName = "IsAvailable", ReadOnly = true });
            dataGridViewOutfits.Columns.Add(new DataGridViewTextBoxColumn() { Name = "CreatedDate", HeaderText = "Created Date", DataPropertyName = "CreatedDate", ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" } });
            dataGridViewOutfits.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ModifiedDate", HeaderText = "Modified Date", DataPropertyName = "ModifiedDate", ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" } });

          
            foreach (DataGridViewColumn column in dataGridViewOutfits.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void LoadOutfits()
        {
            try
            {
                var outfits = _outfitService.GetAllOutfits(); 
                dataGridViewOutfits.DataSource = outfits;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading outfits: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewOutfits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {  
                OutfitModel selectedOutfit = dataGridViewOutfits.Rows[e.RowIndex].DataBoundItem as OutfitModel;

                if (selectedOutfit != null)
                {
                    OutfitSelected?.Invoke(this, new OutfitSelectedEventArgs(selectedOutfit));
                }
            }
        }


        public class OutfitSelectedEventArgs : EventArgs
        {
            public OutfitModel SelectedOutfit { get; }

            public OutfitSelectedEventArgs(OutfitModel outfit)
            {
                SelectedOutfit = outfit;
            }
        }
        

        public void LoadOutfits()
        {
            if (_outfitService == null)
            {
                MessageBox.Show("OutfitService is not initialized. Cannot load outfits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<OutfitModel> outfits = _outfitService.GetAllOutfits();
                dgvOutfits.DataSource = outfits;

                // Customize DataGridView columns
                if (dgvOutfits.Columns.Contains("Id"))
                {
                    dgvOutfits.Columns["Id"].Visible = false;
                }
                if (dgvOutfits.Columns.Contains("Name"))
                {
                    dgvOutfits.Columns["Name"].HeaderText = "Style Name";
                    dgvOutfits.Columns["Name"].FillWeight = 30;
                }
                if (dgvOutfits.Columns.Contains("Recommendation"))
                {
                    dgvOutfits.Columns["Recommendation"].HeaderText = "Recommendation";
                    dgvOutfits.Columns["Recommendation"].FillWeight = 60;
                }
                if (dgvOutfits.Columns.Contains("IsAvailable"))
                {
                    dgvOutfits.Columns["IsAvailable"].HeaderText = "Available";
                    dgvOutfits.Columns["IsAvailable"].FillWeight = 10;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading outfits: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOutfits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}