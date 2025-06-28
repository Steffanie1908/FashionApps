using System.Windows.Forms;
using FashionApp_Data_Logic;
using System;
using FashionApp_Business_Logic;

namespace FashionApp_Desktop
{
    public partial class UcViewStyleDetails : UserControl
    {
        private OutfitService _outfitService;

        public event EventHandler BackToViewAllStyles;

        public UcViewStyleDetails()
        {
            InitializeComponent();
            SetFieldsReadOnly(true);
        }

        public UcViewStyleDetails(OutfitService outfitService)
        {
            InitializeComponent();
            _outfitService = outfitService;
            SetFieldsReadOnly(true);
        }

        public void LoadOutfitDetails(OutfitModel outfit)
        {
            if (outfit == null)
            {
                MessageBox.Show("No outfit data provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
                return;
            }

            txtStyleNameDetails.Text = outfit.Name;
            txtRecommendationDetails.Text = outfit.Recommendation;
            chkIsAvailableDetails.Checked = outfit.IsAvailable;
        }

        internal void LoadOutfitDetails(int outfitId)
        {
            if (_outfitService == null)
            {
                MessageBox.Show("OutfitService is not initialized. Cannot load outfit details by ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
                return;
            }

            OutfitModel outfit = _outfitService.GetOutfitById(outfitId);

            if (outfit != null)
            {
                LoadOutfitDetails(outfit);
            }
            else
            {
                MessageBox.Show($"Outfit with ID {outfitId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtStyleNameDetails.Clear();
            txtRecommendationDetails.Clear();
            chkIsAvailableDetails.Checked = false;
        }

        private void SetFieldsReadOnly(bool readOnly)
        {
            txtStyleNameDetails.ReadOnly = readOnly;
            txtRecommendationDetails.ReadOnly = readOnly;
            chkIsAvailableDetails.AutoCheck = !readOnly;
            chkIsAvailableDetails.Enabled = !readOnly;
        }

        private void btnBackToAllStyles_Click(object sender, EventArgs e)
        {
            ClearFields();
            BackToViewAllStyles?.Invoke(this, EventArgs.Empty);
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }
        private void UcViewStyleDetails_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}