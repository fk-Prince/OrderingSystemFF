namespace OrderingSystem.CashierApp.Forms.Menu
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
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.menuName = new System.Windows.Forms.Label();
            this.menuDescription = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.Transparent;
            this.image.BorderRadius = 10;
            this.image.CustomizableEdges.BottomLeft = false;
            this.image.CustomizableEdges.BottomRight = false;
            this.image.Image = global::OrderingSystem.Properties.Resources.placeholder;
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(-1, -2);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(258, 107);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // menuName
            // 
            this.menuName.AutoEllipsis = true;
            this.menuName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuName.Location = new System.Drawing.Point(10, 108);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(212, 57);
            this.menuName.TabIndex = 1;
            this.menuName.Text = "label1";
            // 
            // menuDescription
            // 
            this.menuDescription.AutoEllipsis = true;
            this.menuDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDescription.Location = new System.Drawing.Point(28, 167);
            this.menuDescription.Name = "menuDescription";
            this.menuDescription.Size = new System.Drawing.Size(192, 71);
            this.menuDescription.TabIndex = 2;
            this.menuDescription.Text = "label1";
            this.menuDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 8;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.No;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageOffset = new System.Drawing.Point(0, 15);
            this.guna2Button1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button1.Location = new System.Drawing.Point(232, 113);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(18, 52);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "guna2Button1";
            // 
            // MenuCard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(256, 249);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.menuDescription);
            this.Controls.Add(this.menuName);
            this.Controls.Add(this.image);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.Name = "MenuCard";
            this.Text = "MenuCard";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox image;
        private System.Windows.Forms.Label menuName;
        private System.Windows.Forms.Label menuDescription;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}