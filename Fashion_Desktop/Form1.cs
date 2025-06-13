using System;
using System.Windows.Forms;
using FashionApp_Business_Logic;
using FashionApp_Data_Logic;

namespace FashionApp
{
    public partial class frmMain : Form
    {
        private readonly OutfitService _outfitService;
        private readonly DataService _dataService;

        public frmMain()
        {
            InitializeComponent();
            _dataService = new DataService();
            _outfitService = _dataService.GetOutfitService();
            LoadOutfits();
            SetupDataBindings();
        }

        private void SetupDataBindings()
        {
            // Set up combo box for outfit selection
            cmbOutfits.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadOutfits()
        {
            cmbOutfits.Items.Clear();
            var outfits = _dataService.GetAvailableOutfits();
            foreach (var outfit in outfits)
            {
                cmbOutfits.Items.Add(outfit);
            }
            if (cmbOutfits.Items.Count > 0)
            {
                cmbOutfits.SelectedIndex = 0;
            }
        }

        private void btnGetRecommendation_Click(object sender, EventArgs e)
        {
            if (cmbOutfits.SelectedItem == null)
            {
                MessageBox.Show("Please select an outfit first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedStyle = cmbOutfits.SelectedItem.ToString();
            string recommendation = _outfitService.GetRecommendation(selectedStyle);

            txtRecommendation.Text = recommendation;
            lblSelectedStyle.Text = $"Selected Style: {selectedStyle}";
        }

        private void btnAddStyle_Click(object sender, EventArgs e)
        {
            using (var form = new frmAddEditOutfit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool success = _outfitService.AddNewOutfit(form.OutfitName, form.Recommendation);
                    if (success)
                    {
                        MessageBox.Show("Style added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOutfits();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add style. The name may already exist.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnManageStyles_Click(object sender, EventArgs e)
        {
            using (var form = new frmManageOutfits(_outfitService))
            {
                form.ShowDialog();
                LoadOutfits(); // Refresh the list after management
            }
        }
    }
}