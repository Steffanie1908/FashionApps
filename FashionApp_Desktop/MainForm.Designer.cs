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
            label1 = new Label();
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
            splitContainer1.Panel1.Controls.Add(label1);
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
            splitContainer1.Size = new Size(982, 553);
            splitContainer1.SplitterDistance = 251;
            splitContainer1.TabIndex = 0;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Yu Mincho Demibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(56, 9);
            label1.Name = "label1";
            label1.Size = new Size(150, 38);
            label1.TabIndex = 7;
            label1.Text = "Welcome!";
            //
            // btnExit
            //
            btnExit.BackColor = Color.Transparent;
            btnExit.ForeColor = Color.Black;
            btnExit.Location = new Point(65, 502);
            btnExit.Margin = new Padding(10, 5, 10, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(120, 26);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            //
            // btnDeleteStyle
            //
            btnDeleteStyle.Location = new Point(65, 253);
            btnDeleteStyle.Margin = new Padding(10, 5, 10, 5);
            btnDeleteStyle.Name = "btnDeleteStyle";
            btnDeleteStyle.Size = new Size(120, 30);
            btnDeleteStyle.TabIndex = 5;
            btnDeleteStyle.Text = "Delete Style";
            btnDeleteStyle.UseVisualStyleBackColor = true;
            this.btnDeleteStyle.Click += new System.EventHandler(this.btnDeleteStyle_Click);
            //
            // btnUpdateStyle
            //
            btnUpdateStyle.Location = new Point(65, 218);
            btnUpdateStyle.Margin = new Padding(10, 5, 10, 5);
            btnUpdateStyle.Name = "btnUpdateStyle";
            btnUpdateStyle.Size = new Size(120, 30);
            btnUpdateStyle.TabIndex = 4;
            btnUpdateStyle.Text = "Update Style";
            btnUpdateStyle.UseVisualStyleBackColor = true;
            this.btnUpdateStyle.Click += new System.EventHandler(this.btnUpdateStyle_Click);
            //
            // btnSearchStyles
            //
            btnSearchStyles.Location = new Point(65, 183);
            btnSearchStyles.Margin = new Padding(10, 5, 10, 5);
            btnSearchStyles.Name = "btnSearchStyles";
            btnSearchStyles.Size = new Size(120, 30);
            btnSearchStyles.TabIndex = 3;
            btnSearchStyles.Text = "Search Styles";
            btnSearchStyles.UseVisualStyleBackColor = true;
            this.btnSearchStyles.Click += new System.EventHandler(this.btnSearchStyles_Click); 
            //
            // btnAddNewStyle
            //
            btnAddNewStyle.Location = new Point(65, 148);
            btnAddNewStyle.Margin = new Padding(10, 5, 10, 5);
            btnAddNewStyle.Name = "btnAddNewStyle";
            btnAddNewStyle.Size = new Size(120, 30);
            btnAddNewStyle.TabIndex = 2;
            btnAddNewStyle.Text = "Add New Style";
            btnAddNewStyle.UseVisualStyleBackColor = true;
            this.btnAddNewStyle.Click += new System.EventHandler(this.btnAddNewStyle_Click); 
            //
            // btnSelectOutfit
            //
            btnSelectOutfit.Location = new Point(65, 113);
            btnSelectOutfit.Margin = new Padding(10, 5, 10, 5);
            btnSelectOutfit.Name = "btnSelectOutfit";
            btnSelectOutfit.Size = new Size(120, 30);
            btnSelectOutfit.TabIndex = 1;
            btnSelectOutfit.Text = "Select Outfit";
            btnSelectOutfit.UseVisualStyleBackColor = true;
            this.btnSelectOutfit.Click += new System.EventHandler(this.btnSelectOutfit_Click); 
            //
            // btnViewAllStyles
            //
            btnViewAllStyles.Location = new Point(65, 78);
            btnViewAllStyles.Margin = new Padding(10, 5, 10, 5);
            btnViewAllStyles.Name = "btnViewAllStyles";
            btnViewAllStyles.Size = new Size(120, 30);
            btnViewAllStyles.TabIndex = 0;
            btnViewAllStyles.Text = "View All Styles\n\n";
            btnViewAllStyles.UseVisualStyleBackColor = true;
            this.btnViewAllStyles.Click += new System.EventHandler(this.btnViewAllStyles_Click); 
            //
            // MainForm
            //
            this.ClientSize = new Size(982, 553);
            this.Controls.Add(splitContainer1);
            this.Name = "MainForm";
            this.Text = "FashionApp - Style Selector";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Label label1;
    }
}