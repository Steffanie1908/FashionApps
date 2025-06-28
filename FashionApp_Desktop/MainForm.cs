using System;
using System.Windows.Forms;
using System.Configuration;
using FashionApp_Business_Logic;
using FashionApp_Data_Logic; 

namespace FashionApp_Desktop
{
    public partial class MainForm : Form
    {
        private DataService _dataService;
        private OutfitService _outfitService;

        public MainForm()
        {
            InitializeComponent();
            InitializeFashionAppServices();
            SetupMenuButtonEvents();
            DisplayInitialScreen(); 
        }

        private void InitializeFashionAppServices()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FashionAppDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error: Database connection string 'FashionAppDB' not found in App.config.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            try
            {
                _dataService = new DataService("sqlserver", connectionString);
                _outfitService = _dataService.GetOutfitService();

                try
                {

                    _outfitService.GetAllOutfits();
                    Console.WriteLine("Successfully connected to database and loaded outfit service.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"DATABASE CONNECTION ERROR: {ex.Message}\nPlease check your SQL Server configuration and App.config.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize FashionApp services: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void SetupMenuButtonEvents()
        {
            btnViewAllStyles.Click += btnViewAllStyles_Click;
            btnSelectOutfit.Click += btnSelectOutfit_Click;
            btnAddNewStyle.Click += btnAddNewStyle_Click;
            btnSearchStyles.Click += btnSearchStyles_Click;
            btnUpdateStyle.Click += btnUpdateStyle_Click;
            btnDeleteStyle.Click += btnDeleteStyle_Click;
            btnExit.Click += btnExit_Click;
        }

        private void DisplayInitialScreen()
        {
            ShowPanel(CreateViewAllStylesPanel());
        }

        
        private void ShowPanel(UserControl userControlToShow)
        {
            splitContainer1.Panel2.Controls.Clear(); 
            userControlToShow.Dock = DockStyle.Fill; 
            splitContainer1.Panel2.Controls.Add(userControlToShow); 
        }

        private void btnViewAllStyles_Click(object sender, EventArgs e)
        {
            ShowPanel(CreateViewAllStylesPanel());
        }

        private void btnSelectOutfit_Click(object sender, EventArgs e)
        {
            ShowPanel(CreateViewAllStylesPanel());
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ShowPanel(CreateViewAllStylesPanel());
        }

        private void btnAddNewStyle_Click(object sender, EventArgs e)
        {
            ShowPanel(CreateAddNewStylePanel());
        }

        private void btnSearchStyles_Click(object sender, EventArgs e)
        {
            ShowPanel(CreateSearchStylesPanel());
        }

        private void btnUpdateStyle_Click(object sender, EventArgs e)
        {
            ShowPanel(CreateUpdateStylePanel());
        }

        private void btnDeleteStyle_Click(object sender, EventArgs e)
        {
            ShowPanel(CreateDeleteStylePanel());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private UserControl CreateViewAllStylesPanel()
        {
            if (_outfitService == null)
            {
                MessageBox.Show("OutfitService is not available in MainForm. Cannot create View All Styles panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new UserControl();
            }

            UcViewAllStyles uc = new UcViewAllStyles(_outfitService);
            uc.OutfitSelected += UcViewAll_OutfitSelected;
            return uc;
        }

        private void UcViewAll_OutfitSelected(object sender, UcViewAllStyles.OutfitSelectedEventArgs e)
        {
           
            if (splitContainer1.Panel2.Controls.Count > 0 && splitContainer1.Panel2.Controls[0] is UcViewAllStyles currentViewAllPanel)
            {
                currentViewAllPanel.OutfitSelected -= UcViewAll_OutfitSelected; 
                currentViewAllPanel.Dispose(); 
            }

          
            UcViewStyleDetails ucDetails = new UcViewStyleDetails();
            ucDetails.LoadOutfitDetails(e.SelectedOutfit); 
            ucDetails.BackToViewAllStyles += UcViewDetails_BackToViewAllStyles;

            ShowPanel(ucDetails);
        }

        private void UcViewDetails_BackToViewAllStyles(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Controls.Count > 0 && splitContainer1.Panel2.Controls[0] is UcViewStyleDetails currentDetailsPanel)
            {
                currentDetailsPanel.BackToViewAllStyles -= UcViewDetails_BackToViewAllStyles; 
                currentDetailsPanel.Dispose(); 
            }

            UcViewAllStyles ucViewAll = (UcViewAllStyles)CreateViewAllStylesPanel();
            ShowPanel(ucViewAll);
            ucViewAll.LoadOutfits(); 
        }
        private UserControl CreateSelectOutfitPanel()
        {
            UserControl uc = new UserControl();
            Label lbl = new Label { Text = "Select Outfit (Handled via View All Styles List)", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            uc.Controls.Add(lbl);
            return uc;
        }

        private UserControl CreateAddNewStylePanel()
        {
            if (_outfitService == null)
            {
                MessageBox.Show("OutfitService is not available in MainForm. Cannot create Add New Style panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new UserControl();
            }
            UcAddNewStyle uc = new UcAddNewStyle(_outfitService);
            uc.StyleAdded += UcAddNewStyle_StyleAdded;
            return uc;
        }

        private void UcAddNewStyle_StyleAdded(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Controls.Count > 0 && splitContainer1.Panel2.Controls[0] is UcAddNewStyle currentAddPanel)
            {
                currentAddPanel.StyleAdded -= UcAddNewStyle_StyleAdded;
                currentAddPanel.Dispose();
            }
            ShowPanel(CreateViewAllStylesPanel());
        }

        private UserControl CreateSearchStylesPanel()
        {
            UserControl uc = new UserControl();
            Label lbl = new Label { Text = "Search Styles (Coming Soon)", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            uc.Controls.Add(lbl);
            return uc;
        }

        private UserControl CreateUpdateStylePanel()
        {
            if (_outfitService == null)
            {
                MessageBox.Show("OutfitService is not available in MainForm. Cannot create Update Style panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new UserControl();
            }
            UcUpdateStyle ucUpdate = new UcUpdateStyle(_outfitService);
            ucUpdate.OutfitUpdated += UcUpdateStyle_OutfitUpdated;
            ucUpdate.UpdateCancelled += UcUpdateStyle_UpdateCancelled;
            return ucUpdate;
        }

        private void UcUpdateStyle_OutfitUpdated(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Controls.Count > 0 && splitContainer1.Panel2.Controls[0] is UcUpdateStyle currentUpdatePanel)
            {
                currentUpdatePanel.OutfitUpdated -= UcUpdateStyle_OutfitUpdated;
                currentUpdatePanel.UpdateCancelled -= UcUpdateStyle_UpdateCancelled;
                currentUpdatePanel.Dispose();
            }
            ShowPanel(CreateViewAllStylesPanel());
        }

        private void UcUpdateStyle_UpdateCancelled(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Controls.Count > 0 && splitContainer1.Panel2.Controls[0] is UcUpdateStyle currentUpdatePanel)
            {
                currentUpdatePanel.OutfitUpdated -= UcUpdateStyle_OutfitUpdated;
                currentUpdatePanel.UpdateCancelled -= UcUpdateStyle_UpdateCancelled;
                currentUpdatePanel.Dispose();
            }
            ShowPanel(CreateViewAllStylesPanel());
        }

        private UserControl CreateDeleteStylePanel()
        {
            UserControl uc = new UserControl();
            Label lbl = new Label { Text = "Delete Style (Coming Soon)", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            uc.Controls.Add(lbl);
            return uc;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}