namespace OrderingSystem.CashierApp.Forms.FactoryForm
{
    partial class TableLayout
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cb = new Guna.UI2.WinForms.Guna2CheckBox();
            this.search = new Guna.UI2.WinForms.Guna2TextBox();
            this.b1 = new Guna.UI2.WinForms.Guna2Button();
            this.title = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cb
            // 
            this.cb.AccessibleDescription = "c";
            this.cb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb.AutoSize = true;
            this.cb.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb.CheckedState.BorderRadius = 2;
            this.cb.CheckedState.BorderThickness = 0;
            this.cb.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cb.Location = new System.Drawing.Point(889, 140);
            this.cb.MaximumSize = new System.Drawing.Size(116, 17);
            this.cb.MinimumSize = new System.Drawing.Size(116, 17);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(116, 17);
            this.cb.TabIndex = 5;
            this.cb.Text = "Expired Ingredients";
            this.cb.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cb.UncheckedState.BorderRadius = 2;
            this.cb.UncheckedState.BorderThickness = 0;
            this.cb.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cb.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // search
            // 
            this.search.AutoRoundedCorners = true;
            this.search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search.DefaultText = "";
            this.search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.Location = new System.Drawing.Point(98, 121);
            this.search.MaximumSize = new System.Drawing.Size(300, 36);
            this.search.MinimumSize = new System.Drawing.Size(300, 36);
            this.search.Name = "search";
            this.search.PlaceholderText = "";
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(300, 36);
            this.search.TabIndex = 4;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // b1
            // 
            this.b1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b1.BorderRadius = 5;
            this.b1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.b1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.b1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.b1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.b1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.b1.ForeColor = System.Drawing.Color.White;
            this.b1.Location = new System.Drawing.Point(805, 603);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(200, 35);
            this.b1.TabIndex = 6;
            this.b1.Text = "guna2Button1";
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Font = new System.Drawing.Font("Segoe UI Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(-1, 9);
            this.title.MaximumSize = new System.Drawing.Size(1920, 81);
            this.title.MinimumSize = new System.Drawing.Size(1121, 81);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(1121, 81);
            this.title.TabIndex = 7;
            this.title.Text = "Coupons";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.title.Click += new System.EventHandler(this.title_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeight = 35;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGrid.Location = new System.Drawing.Point(98, 163);
            this.dataGrid.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 25;
            this.dataGrid.Size = new System.Drawing.Size(907, 434);
            this.dataGrid.TabIndex = 8;
            // 
            // TableLayout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1121, 660);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.title);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1121, 660);
            this.Name = "TableLayout";
            this.Text = "TableLayout";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Button b1;
        public Guna.UI2.WinForms.Guna2CheckBox cb;
        public Guna.UI2.WinForms.Guna2TextBox search;
        public System.Windows.Forms.Label title;
        public System.Windows.Forms.DataGridView dataGrid;
    }
}