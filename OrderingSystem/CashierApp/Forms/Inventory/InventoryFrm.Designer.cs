namespace OrderingSystem.CashierApp.Forms
{
    partial class InventoryFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb = new System.Windows.Forms.ComboBox();
            this.fromto = new Guna.UI2.WinForms.Guna2Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.fromto.SuspendLayout();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.Location = new System.Drawing.Point(57, 177);
            this.dataGrid.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 25;
            this.dataGrid.Size = new System.Drawing.Size(1000, 450);
            this.dataGrid.TabIndex = 0;
            // 
            // txt
            // 
            this.txt.AutoRoundedCorners = true;
            this.txt.BackColor = System.Drawing.Color.Transparent;
            this.txt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt.DefaultText = "";
            this.txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt.IconLeft = global::OrderingSystem.Properties.Resources.ss;
            this.txt.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txt.Location = new System.Drawing.Point(57, 41);
            this.txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt.MaxLength = 255;
            this.txt.Name = "txt";
            this.txt.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(156)))), ((int)(((byte)(162)))));
            this.txt.PlaceholderText = "Search Ingredients, Staff";
            this.txt.SelectedText = "";
            this.txt.Size = new System.Drawing.Size(469, 44);
            this.txt.TabIndex = 11;
            this.txt.TextOffset = new System.Drawing.Point(10, 0);
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.BackColor = System.Drawing.Color.Transparent;
            this.dtFrom.BorderRadius = 5;
            this.dtFrom.BorderThickness = 1;
            this.dtFrom.Checked = true;
            this.dtFrom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dtFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(55, 3);
            this.dtFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(129, 34);
            this.dtFrom.TabIndex = 12;
            this.dtFrom.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // dtTo
            // 
            this.dtTo.BackColor = System.Drawing.Color.Transparent;
            this.dtTo.BorderRadius = 5;
            this.dtTo.BorderThickness = 1;
            this.dtTo.Checked = true;
            this.dtTo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dtTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(234, 3);
            this.dtTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(129, 34);
            this.dtTo.TabIndex = 13;
            this.dtTo.Value = new System.DateTime(2025, 10, 24, 21, 13, 10, 0);
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "To:";
            // 
            // cb
            // 
            this.cb.AutoCompleteCustomSource.AddRange(new string[] {
            "Track Quantity In/Out",
            "Expiry Tracking",
            "Inventory Reports",
            "Ingredient Usage",
            "Menu Popular\'s",
            "Menu Performance"});
            this.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb.FormattingEnabled = true;
            this.cb.Items.AddRange(new object[] {
            "Track Quantity In/Out",
            "Expiry Tracking",
            "Inventory Reports",
            "Ingredient Usage",
            "Menu Popular\'s",
            "Menu Performance"});
            this.cb.Location = new System.Drawing.Point(57, 142);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(233, 29);
            this.cb.TabIndex = 21;
            this.cb.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // fromto
            // 
            this.fromto.Controls.Add(this.dtTo);
            this.fromto.Controls.Add(this.dtFrom);
            this.fromto.Controls.Add(this.label2);
            this.fromto.Controls.Add(this.label1);
            this.fromto.Location = new System.Drawing.Point(57, 94);
            this.fromto.Name = "fromto";
            this.fromto.Size = new System.Drawing.Size(385, 42);
            this.fromto.TabIndex = 22;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Track Quantity In/Out",
            "Expiry Tracking",
            "Inventory Reports",
            "Ingredient Usage",
            "Menu Popular\'s",
            "Menu Performance"});
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(445, 142);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(233, 29);
            this.comboBox1.TabIndex = 23;
            // 
            // InventoryFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1121, 660);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.fromto);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1121, 660);
            this.Name = "InventoryFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "InventoryFrm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.fromto.ResumeLayout(false);
            this.fromto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private Guna.UI2.WinForms.Guna2TextBox txt;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtFrom;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb;
        private Guna.UI2.WinForms.Guna2Panel fromto;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}