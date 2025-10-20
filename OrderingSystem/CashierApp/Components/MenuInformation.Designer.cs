namespace OrderingSystem.CashierApp.Components
{
    partial class MenuInformation
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
            this.components = new System.ComponentModel.Container();
            this.b2 = new Guna.UI2.WinForms.Guna2Button();
            this.menuName = new Guna.UI2.WinForms.Guna2TextBox();
            this.description = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.category = new System.Windows.Forms.ComboBox();
            this.catTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.mm = new Guna.UI2.WinForms.Guna2Panel();
            this.b1 = new Guna.UI2.WinForms.Guna2Button();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.closeButton = new Guna.UI2.WinForms.Guna2PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.b3 = new Guna.UI2.WinForms.Guna2Button();
            this.b4 = new Guna.UI2.WinForms.Guna2Button();
            this.lPrice = new System.Windows.Forms.Label();
            this.price = new Guna.UI2.WinForms.Guna2TextBox();
            this.toggle = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b2
            // 
            this.b2.AutoRoundedCorners = true;
            this.b2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.b2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.b2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.b2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.b2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(119)))), ((int)(((byte)(206)))));
            this.b2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.b2.ForeColor = System.Drawing.Color.White;
            this.b2.Location = new System.Drawing.Point(3, 42);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(214, 33);
            this.b2.TabIndex = 2;
            this.b2.Text = "Add Another Variant";
            this.b2.Click += new System.EventHandler(this.newVariantButton);
            // 
            // menuName
            // 
            this.menuName.BackColor = System.Drawing.Color.Transparent;
            this.menuName.BorderRadius = 5;
            this.menuName.BorderThickness = 0;
            this.menuName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.menuName.DefaultText = "";
            this.menuName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.menuName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.menuName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.menuName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.menuName.Enabled = false;
            this.menuName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.menuName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.menuName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.menuName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.menuName.Location = new System.Drawing.Point(26, 69);
            this.menuName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.menuName.Name = "menuName";
            this.menuName.PlaceholderText = "";
            this.menuName.SelectedText = "";
            this.menuName.Size = new System.Drawing.Size(544, 36);
            this.menuName.TabIndex = 3;
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.BorderRadius = 5;
            this.description.BorderThickness = 0;
            this.description.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.description.DefaultText = "";
            this.description.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.description.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.description.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.description.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.description.Enabled = false;
            this.description.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.description.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.description.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.description.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.description.Location = new System.Drawing.Point(26, 209);
            this.description.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.PlaceholderText = "";
            this.description.SelectedText = "";
            this.description.Size = new System.Drawing.Size(544, 77);
            this.description.TabIndex = 4;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Menu Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(13, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(13, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Description";
            // 
            // category
            // 
            this.category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.category.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.category.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category.FormattingEnabled = true;
            this.category.Location = new System.Drawing.Point(26, 144);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(385, 25);
            this.category.TabIndex = 11;
            this.category.Visible = false;
            // 
            // catTxt
            // 
            this.catTxt.BackColor = System.Drawing.Color.Transparent;
            this.catTxt.BorderRadius = 5;
            this.catTxt.BorderThickness = 0;
            this.catTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.catTxt.DefaultText = "";
            this.catTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.catTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.catTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.catTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.catTxt.Enabled = false;
            this.catTxt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.catTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.catTxt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.catTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.catTxt.Location = new System.Drawing.Point(26, 141);
            this.catTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.catTxt.Name = "catTxt";
            this.catTxt.PlaceholderText = "";
            this.catTxt.SelectedText = "";
            this.catTxt.Size = new System.Drawing.Size(385, 36);
            this.catTxt.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(13, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Menu Details";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // mm
            // 
            this.mm.Location = new System.Drawing.Point(16, 327);
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(661, 245);
            this.mm.TabIndex = 15;
            // 
            // b1
            // 
            this.b1.AutoRoundedCorners = true;
            this.b1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.b1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.b1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.b1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.b1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(119)))), ((int)(((byte)(206)))));
            this.b1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.b1.ForeColor = System.Drawing.Color.White;
            this.b1.ImageOffset = new System.Drawing.Point(-5, 0);
            this.b1.ImageSize = new System.Drawing.Size(15, 15);
            this.b1.Location = new System.Drawing.Point(3, 3);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(214, 33);
            this.b1.TabIndex = 1;
            this.b1.Text = "Edit";
            this.b1.TextOffset = new System.Drawing.Point(-5, 0);
            this.b1.Click += new System.EventHandler(this.changeMode);
            // 
            // image
            // 
            this.image.BorderRadius = 10;
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(750, 21);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(229, 200);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            this.image.Click += new System.EventHandler(this.ImageButton);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Image = global::OrderingSystem.Properties.Resources.exit;
            this.closeButton.ImageRotate = 0F;
            this.closeButton.Location = new System.Drawing.Point(985, 1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(26, 25);
            this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeButton.TabIndex = 9;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.b1);
            this.flowLayoutPanel1.Controls.Add(this.b2);
            this.flowLayoutPanel1.Controls.Add(this.b3);
            this.flowLayoutPanel1.Controls.Add(this.b4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(756, 230);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(223, 355);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // b3
            // 
            this.b3.AutoRoundedCorners = true;
            this.b3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.b3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.b3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.b3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.b3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(119)))), ((int)(((byte)(206)))));
            this.b3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.b3.ForeColor = System.Drawing.Color.White;
            this.b3.Location = new System.Drawing.Point(3, 81);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(214, 33);
            this.b3.TabIndex = 3;
            this.b3.Text = "Update Bundle";
            this.b3.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // b4
            // 
            this.b4.AutoRoundedCorners = true;
            this.b4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.b4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.b4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.b4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.b4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(119)))), ((int)(((byte)(206)))));
            this.b4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.b4.ForeColor = System.Drawing.Color.White;
            this.b4.Location = new System.Drawing.Point(3, 120);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(214, 33);
            this.b4.TabIndex = 4;
            this.b4.Text = "Additional Ingredients";
            this.b4.Visible = false;
            this.b4.Click += new System.EventHandler(this.b4_Click);
            // 
            // lPrice
            // 
            this.lPrice.AutoSize = true;
            this.lPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lPrice.ForeColor = System.Drawing.Color.Gray;
            this.lPrice.Location = new System.Drawing.Point(425, 120);
            this.lPrice.Name = "lPrice";
            this.lPrice.Size = new System.Drawing.Size(36, 17);
            this.lPrice.TabIndex = 18;
            this.lPrice.Text = "Price";
            this.lPrice.Visible = false;
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.BorderRadius = 5;
            this.price.BorderThickness = 0;
            this.price.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.price.DefaultText = "";
            this.price.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.price.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.price.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.price.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.price.Enabled = false;
            this.price.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.price.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.price.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.price.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.price.Location = new System.Drawing.Point(429, 141);
            this.price.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.price.Name = "price";
            this.price.PlaceholderText = "";
            this.price.SelectedText = "";
            this.price.Size = new System.Drawing.Size(141, 36);
            this.price.TabIndex = 17;
            this.price.Visible = false;
            // 
            // toggle
            // 
            this.toggle.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggle.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggle.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.toggle.CheckedState.InnerColor = System.Drawing.Color.White;
            this.toggle.Enabled = false;
            this.toggle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toggle.Location = new System.Drawing.Point(82, 6);
            this.toggle.Name = "toggle";
            this.toggle.Size = new System.Drawing.Size(35, 20);
            this.toggle.TabIndex = 20;
            this.toggle.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.toggle.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.toggle.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.toggle.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.toggle.CheckedChanged += new System.EventHandler(this.guna2ToggleSwitch1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(16, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Available";
            // 
            // MenuInformation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1012, 600);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toggle);
            this.Controls.Add(this.lPrice);
            this.Controls.Add(this.price);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.catTxt);
            this.Controls.Add(this.category);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.description);
            this.Controls.Add(this.menuName);
            this.Controls.Add(this.image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuInformation";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox image;
        private Guna.UI2.WinForms.Guna2Button b1;
        private Guna.UI2.WinForms.Guna2Button b2;
        private Guna.UI2.WinForms.Guna2TextBox menuName;
        private Guna.UI2.WinForms.Guna2TextBox description;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox category;
        private Guna.UI2.WinForms.Guna2TextBox catTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog ofd;
        private Guna.UI2.WinForms.Guna2Panel mm;
        public Guna.UI2.WinForms.Guna2PictureBox closeButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button b3;
        private System.Windows.Forms.Label lPrice;
        private Guna.UI2.WinForms.Guna2TextBox price;
        private Guna.UI2.WinForms.Guna2Button b4;
        private Guna.UI2.WinForms.Guna2ToggleSwitch toggle;
        private System.Windows.Forms.Label label5;
    }
}