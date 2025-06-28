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

        public class OutfitSelectedEventArgs : EventArgs
        {
            public OutfitModel SelectedOutfit { get; }

            public OutfitSelectedEventArgs(OutfitModel outfit)
            {
                SelectedOutfit = outfit;
            }
        }

        public UcViewAllStyles(OutfitService outfitService)
        {
            InitializeComponent();
            _outfitService = outfitService;

            dgvOutfits.AutoGenerateColumns = false; 
            InitializeDataGridViewColumns(); 
            LoadOutfits(); 

            dgvOutfits.CellDoubleClick += dgvOutfits_CellDoubleClick; 
        }

        private void InitializeDataGridViewColumns()
        {
            dgvOutfits.Columns.Clear(); 

            dgvOutfits.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", ReadOnly = true, Visible = false }); 
            dgvOutfits.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Name", HeaderText = "Style Name", DataPropertyName = "Name", ReadOnly = true }); 
            dgvOutfits.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Recommendation", HeaderText = "Recommendation", DataPropertyName = "Recommendation", ReadOnly = true }); 
            dgvOutfits.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "IsAvailable", HeaderText = "Available", DataPropertyName = "IsAvailable", ReadOnly = true }); 

            foreach (DataGridViewColumn column in dgvOutfits.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                var outfits = _outfitService.GetAllOutfits();
                dgvOutfits.DataSource = outfits; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading outfits: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOutfits_CellDoubleClick(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.RowIndex >= 0) 
            {
                
                OutfitModel selectedOutfit = dgvOutfits.Rows[e.RowIndex].DataBoundItem as OutfitModel;

                if (selectedOutfit != null)
                {

                    OutfitSelected?.Invoke(this, new OutfitSelectedEventArgs(selectedOutfit));
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}