using System;
using System.Linq; 
using System.Windows.Forms;
using FashionApp_Business_Logic;
using FashionApp_Data_Logic;

namespace FashionApp_Desktop
{
    public partial class UcUpdateStyle : UserControl
    {
        private OutfitService _outfitService;
        private int _currentOutfitId = -1; 

        
        public event EventHandler OutfitUpdated;
        public event EventHandler UpdateCancelled; 

        public UcUpdateStyle(OutfitService outfitService)
        {
            InitializeComponent();
            _outfitService = outfitService;
            LoadOutfitNamesToComboBox(); 
        }

        private void LoadOutfitNamesToComboBox()
        {
            if (_outfitService == null)
            {
                MessageBox.Show("Outfit service not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var outfitNames = _outfitService.GetAllOutfitNames();
                cmbSelectOutfit.Items.Clear();
                cmbSelectOutfit.Items.AddRange(outfitNames);
                cmbSelectOutfit.SelectedIndex = -1; 
                cmbSelectOutfit.Text = "Select an outfit..."; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading outfit names: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadOutfit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbSelectOutfit.Text) || cmbSelectOutfit.SelectedItem == null)
            {
                MessageBox.Show("Please select an outfit to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedName = cmbSelectOutfit.SelectedItem.ToString();
            try
            {
                var allOutfits = _outfitService.GetAllOutfits();
                var selectedOutfit = allOutfits.FirstOrDefault(o => o.Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

                if (selectedOutfit != null)
                {
                    _currentOutfitId = selectedOutfit.Id; 
                    txtStyleNameUpdate.Text = selectedOutfit.Name;
                    txtRecommendationUpdate.Text = selectedOutfit.Recommendation;
                    chkIsAvailableUpdate.Checked = selectedOutfit.IsAvailable;

                    txtStyleNameUpdate.Enabled = true;
                    txtRecommendationUpdate.Enabled = true;
                    chkIsAvailableUpdate.Enabled = true;
                    btnSaveChanges.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Selected outfit not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading outfit details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (_currentOutfitId == -1)
            {
                MessageBox.Show("No outfit loaded for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string styleName = txtStyleNameUpdate.Text.Trim();
            string recommendation = txtRecommendationUpdate.Text.Trim();
            bool isAvailable = chkIsAvailableUpdate.Checked;

            if (string.IsNullOrWhiteSpace(styleName))
            {
                MessageBox.Show("Style Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStyleNameUpdate.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(recommendation))
            {
                MessageBox.Show("Recommendation cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRecommendationUpdate.Focus();
                return;
            }

            try
            {
                bool success = _outfitService.UpdateOutfit(_currentOutfitId, styleName, recommendation, isAvailable);

                if (success)
                {
                    MessageBox.Show($"Style '{styleName}' updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadOutfitNamesToComboBox();
                    OutfitUpdated?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Failed to update style. It might not exist or a database error occurred.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadOutfitNamesToComboBox(); 
            UpdateCancelled?.Invoke(this, EventArgs.Empty); 
        }

        private void ClearFields()
        {
            _currentOutfitId = -1;
            txtStyleNameUpdate.Clear();
            txtRecommendationUpdate.Clear();
            chkIsAvailableUpdate.Checked = false; 
            cmbSelectOutfit.SelectedIndex = -1;
            cmbSelectOutfit.Text = "Select an outfit...";

            txtStyleNameUpdate.Enabled = false;
            txtRecommendationUpdate.Enabled = false;
            chkIsAvailableUpdate.Enabled = false;
            btnSaveChanges.Enabled = false;
        }
        private void UcUpdateStyle_Load(object sender, EventArgs e)
        {
            txtStyleNameUpdate.Enabled = false;
            txtRecommendationUpdate.Enabled = false;
            chkIsAvailableUpdate.Enabled = false;
            btnSaveChanges.Enabled = false;
            LoadOutfitNamesToComboBox();
        }


    }
}