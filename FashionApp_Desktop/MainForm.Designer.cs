namespace FashionApp_Desktop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            btnExit = new Button();
            btnDeleteStyle = new Button();
            btnUpdateStyle = new Button();
            btnSearchStyles = new Button();
            btnAddNewStyle = new Button();
            btnSelectOutfit = new Button();
            btnViewAllStyles = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.LightSteelBlue;
            splitContainer1.Panel1.Controls.Add(btnExit);
            splitContainer1.Panel1.Controls.Add(btnDeleteStyle);
            splitContainer1.Panel1.Controls.Add(btnUpdateStyle);
            splitContainer1.Panel1.Controls.Add(btnSearchStyles);
            splitContainer1.Panel1.Controls.Add(btnAddNewStyle);
            splitContainer1.Panel1.Controls.Add(btnSelectOutfit);
            splitContainer1.Panel1.Controls.Add(btnViewAllStyles);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.LightSlateGray;
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(982, 553);
            splitContainer1.SplitterDistance = 251;
            splitContainer1.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.ForeColor = Color.Black;
            btnExit.Location = new Point(79, 403);
            btnExit.Margin = new Padding(10, 5, 10, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnAddNewStyle_Click;
            // 
            // btnDeleteStyle
            // 
            btnDeleteStyle.Location = new Point(79, 217);
            btnDeleteStyle.Margin = new Padding(10, 5, 10, 5);
            btnDeleteStyle.Name = "btnDeleteStyle";
            btnDeleteStyle.Size = new Size(94, 29);
            btnDeleteStyle.TabIndex = 5;
            btnDeleteStyle.Text = "Delete Style";
            btnDeleteStyle.UseVisualStyleBackColor = true;
            btnDeleteStyle.Click += btnAddNewStyle_Click;
            // 
            // btnUpdateStyle
            // 
            btnUpdateStyle.Location = new Point(79, 182);
            btnUpdateStyle.Margin = new Padding(10, 5, 10, 5);
            btnUpdateStyle.Name = "btnUpdateStyle";
            btnUpdateStyle.Size = new Size(94, 29);
            btnUpdateStyle.TabIndex = 4;
            btnUpdateStyle.Text = "Update Style";
            btnUpdateStyle.UseVisualStyleBackColor = true;
            btnUpdateStyle.Click += btnAddNewStyle_Click;
            // 
            // btnSearchStyles
            // 
            btnSearchStyles.Location = new Point(79, 147);
            btnSearchStyles.Margin = new Padding(10, 5, 10, 5);
            btnSearchStyles.Name = "btnSearchStyles";
            btnSearchStyles.Size = new Size(94, 29);
            btnSearchStyles.TabIndex = 3;
            btnSearchStyles.Text = "Search Styles";
            btnSearchStyles.UseVisualStyleBackColor = true;
            btnSearchStyles.Click += btnAddNewStyle_Click;
            // 
            // btnAddNewStyle
            // 
            btnAddNewStyle.Location = new Point(79, 112);
            btnAddNewStyle.Margin = new Padding(10, 5, 10, 5);
            btnAddNewStyle.Name = "btnAddNewStyle";
            btnAddNewStyle.Size = new Size(94, 29);
            btnAddNewStyle.TabIndex = 2;
            btnAddNewStyle.Text = "Add New Style";
            btnAddNewStyle.UseVisualStyleBackColor = true;
            btnAddNewStyle.Click += btnAddNewStyle_Click;
            // 
            // btnSelectOutfit
            // 
            btnSelectOutfit.Location = new Point(79, 77);
            btnSelectOutfit.Margin = new Padding(10, 5, 10, 5);
            btnSelectOutfit.Name = "btnSelectOutfit";
            btnSelectOutfit.Size = new Size(94, 29);
            btnSelectOutfit.TabIndex = 1;
            btnSelectOutfit.Text = "Select Outfit";
            btnSelectOutfit.UseVisualStyleBackColor = true;
            btnSelectOutfit.Click += btnAddNewStyle_Click;
            // 
            // btnViewAllStyles
            // 
            btnViewAllStyles.Location = new Point(79, 42);
            btnViewAllStyles.Margin = new Padding(10, 5, 10, 5);
            btnViewAllStyles.Name = "btnViewAllStyles";
            btnViewAllStyles.Size = new Size(94, 29);
            btnViewAllStyles.TabIndex = 0;
            btnViewAllStyles.Text = "View All Styles\n\n";
            btnViewAllStyles.UseVisualStyleBackColor = true;
            btnViewAllStyles.Click += btnAddNewStyle_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(982, 553);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            Text = "FashionApp - Style Selector";
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnViewAllStyles;
        private Button btnAddNewStyle;
        private Button btnSelectOutfit;
        private Button btnExit;
        private Button btnDeleteStyle;
        private Button btnUpdateStyle;
        private Button btnSearchStyles;
    }
}
