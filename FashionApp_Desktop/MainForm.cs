using System;
using System.Windows.Forms;
using FashionApp_Business_Logic;
using FashionApp_Data_Logic;

namespace FashionApp_Desktop
{
    public partial class MainForm : Form
    {
        private OutfitService _outfitService;
        private UcSearchStyle _ucSearchStyle;
        private UcViewAllStyles _ucViewAllStyles;
        private UcAddNewStyle _ucAddNewStyle;
        private UcUpdateStyle _ucUpdateStyle;
        private UcDeleteStyleList _ucDeleteStyleList;
        private UcViewStyleDetails _ucViewStyleDetails;

        public MainForm()
        {
            InitializeComponent();
            InitializeApplicationServices();
            ShowViewAllStylesControl();
        }

        private void InitializeApplicationServices()
        {
            IOutfitRepository outfitRepository = new InMemoryOutfitRepository();
            _outfitService = new OutfitService(outfitRepository);
        }

        private void ShowUserControl(UserControl userControl)
        {
            splitContainer1.Panel2.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void ShowViewAllStylesControl()
        {
            if (_ucViewAllStyles == null)
            {
                _ucViewAllStyles = new UcViewAllStyles(_outfitService);
                _ucViewAllStyles.OutfitSelected += UcViewAllStyles_OutfitSelected;
            }
            ShowUserControl(_ucViewAllStyles);
            _ucViewAllStyles.LoadOutfits();
        }

        private void ShowSelectOutfitControl()
        {
            MessageBox.Show("To view the details of an outfit, please double click an outfit in the View all styles panel.",
                            "Functionality Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowAddNewStyleControl()
        {
            if (_ucAddNewStyle == null)
            {
                _ucAddNewStyle = new UcAddNewStyle(_outfitService);
                _ucAddNewStyle.StyleAdded += UcAddNewStyle_StyleAdded;
            }
            ShowUserControl(_ucAddNewStyle);
            _ucAddNewStyle.ClearFields();
        }

        private void ShowSearchStylesControl()
        {
            if (_ucSearchStyle == null)
            {
                _ucSearchStyle = new UcSearchStyle(_outfitService);
            }
            ShowUserControl(_ucSearchStyle);
        }

        private void ShowUpdateStyleControl()
        {
            if (_ucUpdateStyle == null)
            {
                _ucUpdateStyle = new UcUpdateStyle(_outfitService);
                _ucUpdateStyle.OutfitUpdated += UcUpdateStyle_OutfitUpdated;
                _ucUpdateStyle.UpdateCancelled += UcUpdateStyle_UpdateCancelled;
            }
            ShowUserControl(_ucUpdateStyle);
            _ucUpdateStyle.LoadOutfitsForSelection();
        }

        private void ShowDeleteStyleControl()
        {
            if (_ucDeleteStyleList == null)
            {
                _ucDeleteStyleList = new UcDeleteStyleList(_outfitService);
                _ucDeleteStyleList.BackToViewAllStyles += UcDeleteStyleList_BackToViewAllStyles;
                _ucDeleteStyleList.OutfitDeleted += UcDeleteStyleList_OutfitDeleted;
            }
            ShowUserControl(_ucDeleteStyleList);
            _ucDeleteStyleList.LoadOutfits();
        }

        public void ShowViewStyleDetailsControl(int outfitId)
        {
            OutfitModel outfit = _outfitService.GetOutfitById(outfitId);

            if (outfit == null)
            {
                MessageBox.Show("Outfit not found for details view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_ucViewStyleDetails == null)
            {
                _ucViewStyleDetails = new UcViewStyleDetails(_outfitService);
                _ucViewStyleDetails.BackToViewAllStyles += UcViewStyleDetails_BackToViewAllStyles;
            }
            ShowUserControl(_ucViewStyleDetails);
            _ucViewStyleDetails.LoadOutfitDetails(outfit);
        }

        private void btnViewAllStyles_Click(object sender, EventArgs e)
        {
            ShowViewAllStylesControl();
        }

        private void btnSelectOutfit_Click(object sender, EventArgs e)
        {
            ShowSelectOutfitControl(); // This will now show the adjusted message
        }

        private void btnAddNewStyle_Click(object sender, EventArgs e)
        {
            ShowAddNewStyleControl();
        }

        private void btnSearchStyles_Click(object sender, EventArgs e)
        {
            ShowSearchStylesControl();
        }

        private void btnUpdateStyle_Click(object sender, EventArgs e)
        {
            ShowUpdateStyleControl();
        }

        private void btnDeleteStyle_Click(object sender, EventArgs e)
        {
            ShowDeleteStyleControl();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UcViewAllStyles_OutfitSelected(object sender, UcViewAllStyles.OutfitSelectedEventArgs e)
        {
            ShowViewStyleDetailsControl(e.SelectedOutfit.Id);
        }

        private void UcAddNewStyle_StyleAdded(object sender, EventArgs e)
        {
            ShowViewAllStylesControl();
        }

        private void UcUpdateStyle_OutfitUpdated(object sender, EventArgs e)
        {
            ShowViewAllStylesControl();
        }

        private void UcUpdateStyle_UpdateCancelled(object sender, EventArgs e)
        {
            ShowViewAllStylesControl();
        }

        private void UcDeleteStyleList_BackToViewAllStyles(object sender, EventArgs e)
        {
            ShowViewAllStylesControl();
        }

        private void UcDeleteStyleList_OutfitDeleted(object sender, EventArgs e)
        {
            ShowViewAllStylesControl();
        }

        private void UcViewStyleDetails_BackToViewAllStyles(object sender, EventArgs e)
        {
            ShowViewAllStylesControl();
        }
    }
}