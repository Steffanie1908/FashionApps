using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FashionApp_Business_Logic;
using FashionApp_Data_Logic;

namespace FashionApp_Desktop
{
    public partial class UcSearchStyle : UserControl
    {
        private OutfitService _outfitService;

        public UcSearchStyle(OutfitService outfitService)
        {
            InitializeComponent();
            _outfitService = outfitService;
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridViewResults.AutoGenerateColumns = false;
            dataGridViewResults.Columns.Clear();

            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Style Name", DataPropertyName = "Name", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "Recommendation", HeaderText = "Recommendation", DataPropertyName = "Recommendation", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewResults.Columns.Add(new DataGridViewCheckBoxColumn { Name = "IsAvailable", HeaderText = "Available", DataPropertyName = "IsAvailable", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchTerm.Text.Trim();

            if (_outfitService == null)
            {
                MessageBox.Show("OutfitService is not initialized. Cannot perform search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<OutfitModel> results = _outfitService.SearchOutfits(searchTerm);

                if (results != null && results.Any())
                {
                    dataGridViewResults.DataSource = results;
                }
                else
                {
                    dataGridViewResults.DataSource = null;
                    MessageBox.Show("No outfits found matching your search.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during search: {ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewResults.DataSource = null;
            }
        }

        private void UcSearchStyle_Load(object sender, EventArgs e)
        {

        }
    }
}