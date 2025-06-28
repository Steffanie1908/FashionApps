using System;
using System.Windows.Forms;
using System.Configuration; 
using FashionApp_Business_Logic; 

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
            ShowPanel(CreateSelectOutfitPanel());
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
                MessageBox.Show("OutfitService is not available in MainForm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new UserControl();
            }

            UcViewAllStyles uc = new UcViewAllStyles(_outfitService);
            return uc;
        }

        // Placeholder methods for other functionalities - these will be replaced with actual UserControls later
        private UserControl CreateSelectOutfitPanel()
        {
            UserControl uc = new UserControl();
            Label lbl = new Label { Text = "Select Outfit (Coming Soon)", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
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

        // Inside MainForm.cs

        private UserControl CreateUpdateStylePanel()
        {
            if (_outfitService == null)
            {
                MessageBox.Show("OutfitService is not available in MainForm. Cannot create Update Style panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new UserControl();
            }
            UcUpdateStyle ucUpdate = new UcUpdateStyle(_outfitService);
            // Subscribe to events from UcUpdateStyle to handle UI flow
            ucUpdate.OutfitUpdated += UcUpdateStyle_OutfitUpdated;
            ucUpdate.UpdateCancelled += UcUpdateStyle_UpdateCancelled; // Optional
            return ucUpdate;
        }

        // Add event handlers for UcUpdateStyle events
        private void UcUpdateStyle_OutfitUpdated(object sender, EventArgs e)
        {
            // After an update, perhaps navigate back to View All Styles
            // Ensure to unsubscribe to prevent memory leaks, especially if creating new instances
            if (splitContainer1.Panel2.Controls.Count > 0 && splitContainer1.Panel2.Controls[0] is UcUpdateStyle currentUpdatePanel)
            {
                currentUpdatePanel.OutfitUpdated -= UcUpdateStyle_OutfitUpdated;
                currentUpdatePanel.UpdateCancelled -= UcUpdateStyle_UpdateCancelled;
                currentUpdatePanel.Dispose();
            }
            ShowPanel(CreateViewAllStylesPanel()); // Go back to view all after update
        }

        private void UcUpdateStyle_UpdateCancelled(object sender, EventArgs e)
        {
            // If cancelled, perhaps also go back to View All Styles
            if (splitContainer1.Panel2.Controls.Count > 0 && splitContainer1.Panel2.Controls[0] is UcUpdateStyle currentUpdatePanel)
            {
                currentUpdatePanel.OutfitUpdated -= UcUpdateStyle_OutfitUpdated;
                currentUpdatePanel.UpdateCancelled -= UcUpdateStyle_UpdateCancelled;
                currentUpdatePanel.Dispose();
            }
            ShowPanel(CreateViewAllStylesPanel()); // Go back to view all after cancel
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