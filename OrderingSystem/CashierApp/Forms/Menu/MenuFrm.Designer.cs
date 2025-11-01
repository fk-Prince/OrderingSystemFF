namespace OrderingSystem.CashierApp.Forms
{
    partial class MenuFrm
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
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.debouncing = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // flowMenu
            // 
            this.flowMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowMenu.AutoScroll = true;
            this.flowMenu.BackColor = System.Drawing.Color.Transparent;
            this.flowMenu.Location = new System.Drawing.Point(0, 79);
            this.flowMenu.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.flowMenu.MinimumSize = new System.Drawing.Size(776, 581);
            this.flowMenu.Name = "flowMenu";
            this.flowMenu.Size = new System.Drawing.Size(1121, 581);
            this.flowMenu.TabIndex = 0;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txt.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txt.Location = new System.Drawing.Point(12, 30);
            this.txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt.MaximumSize = new System.Drawing.Size(469, 42);
            this.txt.MaxLength = 255;
            this.txt.MinimumSize = new System.Drawing.Size(469, 42);
            this.txt.Name = "txt";
            this.txt.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(156)))), ((int)(((byte)(162)))));
            this.txt.PlaceholderText = "Search Menu\'s";
            this.txt.SelectedText = "";
            this.txt.Size = new System.Drawing.Size(469, 42);
            this.txt.TabIndex = 10;
            this.txt.TextOffset = new System.Drawing.Point(10, 0);
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // debouncing
            // 
            this.debouncing.Interval = 500;
            this.debouncing.Tick += new System.EventHandler(this.debouncing_Tick);
            // 
            // MenuFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1121, 660);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.flowMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1121, 660);
            this.Name = "MenuFrm";
            this.Text = "MenuFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private System.Windows.Forms.OpenFileDialog ofd;
        private Guna.UI2.WinForms.Guna2TextBox txt;
        private System.Windows.Forms.Timer debouncing;
    }
}