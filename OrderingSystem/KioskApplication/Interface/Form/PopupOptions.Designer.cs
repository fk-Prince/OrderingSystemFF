using System.Windows.Forms;

namespace OrderingSystem.KioskApplication
{
    partial class PopupOptions
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
        /// 

      
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupOptions));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.description = new System.Windows.Forms.Label();
            this.menuName = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.bb = new Guna.UI2.WinForms.Guna2Button();
            this.outofstock = new System.Windows.Forms.Label();
            this.flowPanel.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Controls.Add(this.guna2Panel1);
            this.flowPanel.Controls.Add(this.guna2Panel2);
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(689, 654);
            this.flowPanel.TabIndex = 1;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2Panel1.Controls.Add(this.outofstock);
            this.guna2Panel1.Controls.Add(this.image);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(672, 228);
            this.guna2Panel1.TabIndex = 3;
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.image.BorderRadius = 20;
            this.image.CustomizableEdges.BottomLeft = false;
            this.image.CustomizableEdges.BottomRight = false;
            this.image.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.image.Image = global::OrderingSystem.Properties.Resources.placeholder;
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(-6, 0);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(688, 228);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.guna2Panel2.Controls.Add(this.description);
            this.guna2Panel2.Controls.Add(this.menuName);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 228);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(672, 92);
            this.guna2Panel2.TabIndex = 4;
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(47, 35);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(598, 36);
            this.description.TabIndex = 1;
            this.description.Text = "label1";
            // 
            // menuName
            // 
            this.menuName.AutoSize = true;
            this.menuName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuName.Location = new System.Drawing.Point(24, 5);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(65, 25);
            this.menuName.TabIndex = 0;
            this.menuName.Text = "label1";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2Button2.Location = new System.Drawing.Point(620, 10);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.PressedColor = System.Drawing.Color.Transparent;
            this.guna2Button2.Size = new System.Drawing.Size(36, 36);
            this.guna2Button2.TabIndex = 4;
            this.guna2Button2.UseTransparentBackground = true;
            this.guna2Button2.Click += new System.EventHandler(this.closePopup);
            // 
            // bb
            // 
            this.bb.BackColor = System.Drawing.Color.Transparent;
            this.bb.BorderRadius = 8;
            this.bb.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bb.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bb.FillColor = System.Drawing.Color.DarkRed;
            this.bb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bb.ForeColor = System.Drawing.Color.White;
            this.bb.Location = new System.Drawing.Point(499, 687);
            this.bb.Name = "bb";
            this.bb.Size = new System.Drawing.Size(180, 35);
            this.bb.TabIndex = 2;
            this.bb.Text = "Add Order";
            this.bb.Click += new System.EventHandler(this.confirmOrder);
            // 
            // outofstock
            // 
            this.outofstock.BackColor = System.Drawing.Color.Transparent;
            this.outofstock.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outofstock.ForeColor = System.Drawing.Color.IndianRed;
            this.outofstock.Location = new System.Drawing.Point(188, 67);
            this.outofstock.Name = "outofstock";
            this.outofstock.Size = new System.Drawing.Size(319, 76);
            this.outofstock.TabIndex = 2;
            this.outofstock.Text = "OUT OF ORDER";
            this.outofstock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.outofstock.Visible = false;
            // 
            // PopupOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(687, 730);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.bb);
            this.Controls.Add(this.flowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopupOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopupOptions";
            this.flowPanel.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private FlowLayoutPanel flowPanel;
        private Guna.UI2.WinForms.Guna2Button bb;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2PictureBox image;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Label menuName;
        private Label description;
        private Label outofstock;
    }
}