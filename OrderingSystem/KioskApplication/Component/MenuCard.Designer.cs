namespace OrderingSystem.KioskApplication.Cards
{
    partial class MenuCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCard));
            this.menuName = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.stick = new Guna.UI2.WinForms.Guna2Panel();
            this.newPrice = new System.Windows.Forms.Label();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.off = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // menuName
            // 
            this.menuName.AutoSize = true;
            this.menuName.BackColor = System.Drawing.Color.Transparent;
            this.menuName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuName.Location = new System.Drawing.Point(12, 9);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(121, 25);
            this.menuName.TabIndex = 0;
            this.menuName.Text = "Menu Name";
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(13, 77);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(78, 21);
            this.price.TabIndex = 1;
            this.price.Text = "Price";
            this.price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(34, 149);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(228, 59);
            this.description.TabIndex = 2;
            this.description.Text = "Descirption";
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stick
            // 
            this.stick.FillColor = System.Drawing.Color.IndianRed;
            this.stick.Location = new System.Drawing.Point(18, 87);
            this.stick.Name = "stick";
            this.stick.Size = new System.Drawing.Size(70, 2);
            this.stick.TabIndex = 5;
            // 
            // newPrice
            // 
            this.newPrice.AutoSize = true;
            this.newPrice.BackColor = System.Drawing.Color.Transparent;
            this.newPrice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPrice.ForeColor = System.Drawing.Color.IndianRed;
            this.newPrice.Location = new System.Drawing.Point(33, 101);
            this.newPrice.Name = "newPrice";
            this.newPrice.Size = new System.Drawing.Size(41, 20);
            this.newPrice.TabIndex = 6;
            this.newPrice.Text = "Price";
            this.newPrice.Visible = false;
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.Transparent;
            this.image.FillColor = System.Drawing.Color.Transparent;
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(172, 9);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(122, 100);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 3;
            this.image.TabStop = false;
            this.image.UseTransparentBackground = true;
            // 
            // off
            // 
            this.off.BackColor = System.Drawing.Color.Transparent;
            this.off.Cursor = System.Windows.Forms.Cursors.Default;
            this.off.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.off.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.off.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.off.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.off.FillColor = System.Drawing.Color.Transparent;
            this.off.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.off.ForeColor = System.Drawing.Color.IndianRed;
            this.off.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.off.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.off.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.off.HoverState.ForeColor = System.Drawing.Color.IndianRed;
            this.off.Image = global::OrderingSystem.Properties.Resources.down;
            this.off.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.off.ImageOffset = new System.Drawing.Point(-10, 0);
            this.off.Location = new System.Drawing.Point(68, 100);
            this.off.Name = "off";
            this.off.PressedColor = System.Drawing.Color.Transparent;
            this.off.PressedDepth = 0;
            this.off.Size = new System.Drawing.Size(68, 25);
            this.off.TabIndex = 7;
            this.off.Text = "Price";
            // 
            // MenuCard
            // 
            this.ClientSize = new System.Drawing.Size(301, 230);
            this.Controls.Add(this.newPrice);
            this.Controls.Add(this.stick);
            this.Controls.Add(this.image);
            this.Controls.Add(this.description);
            this.Controls.Add(this.price);
            this.Controls.Add(this.menuName);
            this.Controls.Add(this.off);
            this.Name = "MenuCard";
            this.Text = "MenuCard";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menuName;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label description;
        private Guna.UI2.WinForms.Guna2PictureBox image;
        private Guna.UI2.WinForms.Guna2Panel stick;
        private System.Windows.Forms.Label newPrice;
        private Guna.UI2.WinForms.Guna2Button off;
    }
}