using System;
using System.Windows.Forms;
using FashionApp_Business_Logic;
using FashionApp_Data_Logic;

namespace FashionApp
{
    public partial class frmManageOutfits : Form
    {
        private readonly OutfitService _outfitService;
        private List<OutfitModel> _outfits;

        public frmManageOutfits(OutfitService outfitService)
        {
            InitializeComponent();
            _outfitService = outfitService;
            LoadOutfits();
        }

        private void LoadOutfits()
        {
            _outfits = _outfitService.GetAllOutfits();
            lstOutfits.Items.Clear();
            foreach (var outfit in _outfits)
            {
                lstOutfits.Items.Add($"{outfit.Id}: {outfit.Name} - {(outfit.IsAvailable ? "Available" : "Not Available")}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstOutfits.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an outfit to edit.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedOutfit = _outfits[lstOutfits.SelectedIndex];
            using (var form = new frmAddEditOutfit(selectedOutfit.Name, selectedOutfit.Recommendation))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool success = _outfitService.UpdateOutfit(
                        selectedOutfit.Id,
                        form.OutfitName,
                        form.Recommendation,
                        selectedOutfit.IsAvailable);

                    if (success)
                    {
                        MessageBox.Show("Outfit updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOutfits();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update outfit. The name may already exist.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstOutfits.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an outfit to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedOutfit = _outfits[lstOutfits.SelectedIndex];
            var result = MessageBox.Show(
                $"Are you sure you want to delete '{selectedOutfit.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool success = _outfitService.DeleteOutfit(selectedOutfit.Id);
                if (success)
                {
                    MessageBox.Show("Outfit deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOutfits();
                }
                else
                {
                    MessageBox.Show("Failed to delete outfit.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnToggleAvailability_Click(object sender, EventArgs e)
        {
            if (lstOutfits.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an outfit to toggle availability.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedOutfit = _outfits[lstOutfits.SelectedIndex];
            bool newAvailability = !selectedOutfit.IsAvailable;

            bool success = _outfitService.UpdateOutfit(
                selectedOutfit.Id,
                selectedOutfit.Name,
                selectedOutfit.Recommendation,
                newAvailability);

            if (success)
            {
                MessageBox.Show($"Outfit is now {(newAvailability ? "Available" : "Not Available")}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOutfits();
            }
            else
            {
                MessageBox.Show("Failed to update outfit availability.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var results = _outfitService.SearchOutfits(txtSearch.Text);
            lstOutfits.Items.Clear();
            foreach (var outfit in results)
            {
                lstOutfits.Items.Add($"{outfit.Id}: {outfit.Name} - {(outfit.IsAvailable ? "Available" : "Not Available")}");
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadOutfits();
        }
    }
}