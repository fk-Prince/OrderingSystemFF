namespace OrderingSystem.CashierApp.Components
{
    partial class IngredientPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bb = new Guna.UI2.WinForms.Guna2Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.search = new Guna.UI2.WinForms.Guna2TextBox();
            this.closeButton = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // bb
            // 
            this.bb.BackColor = System.Drawing.Color.Transparent;
            this.bb.BorderRadius = 10;
            this.bb.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bb.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bb.ForeColor = System.Drawing.Color.White;
            this.bb.Location = new System.Drawing.Point(320, 27);
            this.bb.Name = "bb";
            this.bb.Size = new System.Drawing.Size(201, 36);
            this.bb.TabIndex = 6;
            this.bb.Text = "Add Variant";
            this.bb.Click += new System.EventHandler(this.bb_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeight = 35;
            this.dataGrid.Location = new System.Drawing.Point(14, 70);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(507, 368);
            this.dataGrid.TabIndex = 5;
            this.dataGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGrid_CellValidating);
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.AutoRoundedCorners = true;
            this.search.BackColor = System.Drawing.Color.Transparent;
            this.search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search.DefaultText = "";
            this.search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.FocusedState.BorderColor = System.Drawing.Color.IndianRed;
            this.search.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.IconLeft = global::OrderingSystem.Properties.Resources.ss;
            this.search.IconLeftSize = new System.Drawing.Size(25, 25);
            this.search.Location = new System.Drawing.Point(12, 27);
            this.search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.search.MaximumSize = new System.Drawing.Size(266, 36);
            this.search.MaxLength = 255;
            this.search.MinimumSize = new System.Drawing.Size(266, 36);
            this.search.Name = "search";
            this.search.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(196)))), ((int)(((byte)(202)))));
            this.search.PlaceholderText = "Search Ingredients";
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(266, 36);
            this.search.TabIndex = 7;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Image = global::OrderingSystem.Properties.Resources.exit;
            this.closeButton.ImageRotate = 0F;
            this.closeButton.Location = new System.Drawing.Point(509, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 21);
            this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeButton.TabIndex = 8;
            this.closeButton.TabStop = false;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // IngredientPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(533, 450);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.search);
            this.Controls.Add(this.bb);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IngredientPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngredientPopup";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox search;
        private Guna.UI2.WinForms.Guna2Button bb;
        private System.Windows.Forms.DataGridView dataGrid;
        public Guna.UI2.WinForms.Guna2PictureBox closeButton;
    }
}