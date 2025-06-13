using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FashionApp
{
    public partial class frmAddEditOutfit : Form
    {
        public string OutfitName { get; private set; }
        public string Recommendation { get; private set; }

        public frmAddEditOutfit(string existingName = "", string existingRecommendation = "")
        {
            InitializeComponent();
            txtName.Text = existingName;
            txtRecommendation.Text = existingRecommendation;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a style name.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OutfitName = txtName.Text;
            Recommendation = txtRecommendation.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}