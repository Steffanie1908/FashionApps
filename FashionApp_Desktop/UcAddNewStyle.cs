using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FashionApp_Business_Logic; 
using FashionApp_Data_Logic;

namespace FashionApp_Desktop
{
    public partial class UcAddNewStyle : UserControl
    {
        private OutfitService _outfitService;

        public delegate void StyleAddedEventHandler(object sender, EventArgs e);
        public event StyleAddedEventHandler StyleAdded;

        public UcAddNewStyle(OutfitService outfitService)
        {
            InitializeComponent();

            _outfitService = outfitService;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void tblPanelInputs_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UcAddNewStyle_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_outfitService == null)
            {
                MessageBox.Show("OutfitService is not initialized. Cannot save outfit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a Style Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtRecommendation.Text))
            {
                MessageBox.Show("Please enter a Recommendation.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRecommendation.Focus();
                return;
            }

            OutfitModel newOutfit = new OutfitModel
            {
                Name = txtName.Text.Trim(),
                Recommendation = txtRecommendation.Text.Trim(),
                IsAvailable = chkIsAvailable.Checked
            };

            try
            {
                bool success = _outfitService.AddOutfit(newOutfit);

                if (success)
                {
                    MessageBox.Show("Style added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();

                    StyleAdded?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Failed to add style. Check logs or database for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            txtName.Clear();
            txtRecommendation.Clear();
            chkIsAvailable.Checked = true;
            txtName.Focus();
        }
    }
}
