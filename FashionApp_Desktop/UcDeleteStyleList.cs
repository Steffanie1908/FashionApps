using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FashionApp_Business_Logic; 
using FashionApp_Data_Logic;     

namespace FashionApp_Desktop
{
    public partial class UcDeleteStyleList : UserControl
    {
        private OutfitService _outfitService;


        public event EventHandler BackToViewAllStyles;
        public event EventHandler OutfitDeleted;



        public UcDeleteStyleList(OutfitService outfitService)
        {
            InitializeComponent();
            _outfitService = outfitService;
            SetupEventHandlers();

            LoadOutfits();
        }

        private void SetupEventHandlers()
        {
            btnBack.Click += BtnBack_Click;
            dgvOutfitsForDelete.CellContentClick += DgvOutfitsForDelete_CellContentClick;

            if (dgvOutfitsForDelete.Columns.Contains("Action"))
            {
                dgvOutfitsForDelete.Columns["Action"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            dgvOutfitsForDelete.AutoGenerateColumns = false;
            dgvOutfitsForDelete.ReadOnly = true;
            dgvOutfitsForDelete.AllowUserToAddRows = false;
            dgvOutfitsForDelete.AllowUserToDeleteRows = false;
            dgvOutfitsForDelete.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOutfitsForDelete.MultiSelect = false;

            if (!dgvOutfitsForDelete.Columns.Contains("IdColumn"))
            {
                var idCol = new DataGridViewTextBoxColumn
                {
                    Name = "IdColumn",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Visible = false
                };
                dgvOutfitsForDelete.Columns.Add(idCol);
            }

            if (!dgvOutfitsForDelete.Columns.Contains("NameColumn"))
            {
                var nameCol = new DataGridViewTextBoxColumn
                {
                    Name = "NameColumn",
                    HeaderText = "Outfit Name",
                    DataPropertyName = "Name",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                dgvOutfitsForDelete.Columns.Add(nameCol);
            }

            if (!dgvOutfitsForDelete.Columns.Contains("Action"))
            {
                var deleteButtonCol = new DataGridViewButtonColumn
                {
                    Name = "Action",
                    HeaderText = "Action",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dgvOutfitsForDelete.Columns.Add(deleteButtonCol);
            }
        }

        public void LoadOutfits()
        {
            try
            {
                List<OutfitModel> outfits = _outfitService.GetAllOutfits();
                dgvOutfitsForDelete.DataSource = outfits;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading outfits for deletion: {ex.Message}", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvOutfitsForDelete.DataSource = null;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            BackToViewAllStyles?.Invoke(this, EventArgs.Empty);
        }

        private void DgvOutfitsForDelete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dgvOutfitsForDelete.Columns[e.ColumnIndex].Name == "Action")
            {

                OutfitModel outfitToDelete = dgvOutfitsForDelete.Rows[e.RowIndex].DataBoundItem as OutfitModel;

                if (outfitToDelete != null)
                {
                    DialogResult confirmResult = MessageBox.Show(
                        $"Are you sure you want to delete '{outfitToDelete.Name}'?\n\nThis action cannot be undone.",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            _outfitService.DeleteOutfit(outfitToDelete.Id);

                            MessageBox.Show($"Outfit '{outfitToDelete.Name}' deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOutfits();
                            OutfitDeleted?.Invoke(this, EventArgs.Empty);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to delete outfit: {ex.Message}\n\nPlease check for database constraints or if the outfit is referenced elsewhere.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void dgvOutfitsForDelete_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}