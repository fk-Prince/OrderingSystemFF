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
            this.description = new System.Windows.Forms.Label();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.price = new System.Windows.Forms.Label();
            this.ooo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.dPrice = new System.Windows.Forms.Label();
            this.v1 = new Guna.UI2.WinForms.Guna2Separator();
            this.v2 = new Guna.UI2.WinForms.Guna2Separator();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ooo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuName
            // 
            this.menuName.AutoEllipsis = true;
            this.menuName.BackColor = System.Drawing.Color.Transparent;
            this.menuName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuName.Location = new System.Drawing.Point(12, 68);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(226, 25);
            this.menuName.TabIndex = 0;
            this.menuName.Text = "Menu Name";
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(24, 124);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(202, 57);
            this.description.TabIndex = 2;
            this.description.Text = "Descirption";
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.Transparent;
            this.image.FillColor = System.Drawing.Color.Transparent;
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(1, 4);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(249, 61);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 3;
            this.image.TabStop = false;
            this.image.UseTransparentBackground = true;
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(13, 95);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(78, 21);
            this.price.TabIndex = 1;
            this.price.Text = "Price";
            this.price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ooo
            // 
            this.ooo.AutoRoundedCorners = true;
            this.ooo.BackColor = System.Drawing.Color.Transparent;
            this.ooo.Image = ((System.Drawing.Image)(resources.GetObject("ooo.Image")));
            this.ooo.ImageRotate = 0F;
            this.ooo.Location = new System.Drawing.Point(-23, 132);
            this.ooo.Name = "ooo";
            this.ooo.Size = new System.Drawing.Size(114, 59);
            this.ooo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ooo.TabIndex = 4;
            this.ooo.TabStop = false;
            this.ooo.UseTransparentBackground = true;
            this.ooo.Visible = false;
            // 
            // dPrice
            // 
            this.dPrice.BackColor = System.Drawing.Color.Transparent;
            this.dPrice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPrice.ForeColor = System.Drawing.Color.IndianRed;
            this.dPrice.Location = new System.Drawing.Point(97, 95);
            this.dPrice.Name = "dPrice";
            this.dPrice.Size = new System.Drawing.Size(78, 21);
            this.dPrice.TabIndex = 5;
            this.dPrice.Text = "Price";
            this.dPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1
            // 
            this.v1.BackColor = System.Drawing.Color.Transparent;
            this.v1.FillColor = System.Drawing.Color.IndianRed;
            this.v1.Location = new System.Drawing.Point(10, 98);
            this.v1.Name = "v1";
            this.v1.Size = new System.Drawing.Size(81, 10);
            this.v1.TabIndex = 6;
            this.v1.UseTransparentBackground = true;
            this.v1.Visible = false;
            // 
            // v2
            // 
            this.v2.BackColor = System.Drawing.Color.Transparent;
            this.v2.FillColor = System.Drawing.Color.IndianRed;
            this.v2.Location = new System.Drawing.Point(10, 103);
            this.v2.Name = "v2";
            this.v2.Size = new System.Drawing.Size(81, 10);
            this.v2.TabIndex = 7;
            this.v2.UseTransparentBackground = true;
            this.v2.Visible = false;
            // 
            // MenuCard
            // 
            this.ClientSize = new System.Drawing.Size(250, 189);
            this.Controls.Add(this.v2);
            this.Controls.Add(this.v1);
            this.Controls.Add(this.dPrice);
            this.Controls.Add(this.ooo);
            this.Controls.Add(this.image);
            this.Controls.Add(this.description);
            this.Controls.Add(this.menuName);
            this.Controls.Add(this.price);
            this.Name = "MenuCard";
            this.Text = "MenuCard";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ooo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label menuName;
        private System.Windows.Forms.Label description;
        private Guna.UI2.WinForms.Guna2PictureBox image;
        private System.Windows.Forms.Label price;
        private Guna.UI2.WinForms.Guna2PictureBox ooo;
        private System.Windows.Forms.Label dPrice;
        private Guna.UI2.WinForms.Guna2Separator v1;
        private Guna.UI2.WinForms.Guna2Separator v2;
    }
}