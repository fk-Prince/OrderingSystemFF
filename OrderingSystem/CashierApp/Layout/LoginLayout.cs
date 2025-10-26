﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.CashierApp.Forms;
using OrderingSystem.CashierApp.SessionData;
using OrderingSystem.Exceptions;
using OrderingSystem.Model;
using OrderingSystem.Repository.Staff;

namespace OrderingSystem.CashierApp.Layout
{
    public partial class LoginLayout : Form
    {
        private bool isShowing;
        public bool isPopup = false;
        public bool isLogin = false;
        public LoginLayout()
        {
            InitializeComponent();
        }



        private void exit(object sender, EventArgs e)
        {
            if (!isPopup)
            {
                Environment.Exit(0);
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void pass_MouseDown(object sender, MouseEventArgs e)
        {
            var txt = sender as Guna2TextBox;
            Rectangle iconBounds = new Rectangle(pass.Width - 25 - pass.Padding.Right, (pass.Height - 20) / 2, 20, 20);

            if (iconBounds.Contains(e.Location))
            {
                if (!isShowing) pass.IconRight = Properties.Resources.eyeclosed;
                else pass.IconRight = Properties.Resources.eye;
                pass.UseSystemPasswordChar = !pass.UseSystemPasswordChar;
                isShowing = !isShowing;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Text) || string.IsNullOrWhiteSpace(pass.Text))
                {
                    throw new IncorrectCredentials("Incorrect Username or Password.");
                }

                StaffModel staff = StaffModel.Builder()
                    .WithUsername(user.Text.Trim())
                    .WithPassword(pass.Text.Trim())
                    .Build();
                IStaffRepository staffRepository = new StaffRepository();
                StaffModel loginStaff = staffRepository.successfullyLogin(staff);

                if (loginStaff != null)
                {
                    SessionStaffData.StaffData = loginStaff;
                    SessionStaffData.StaffId = loginStaff.StaffId;
                    SessionStaffData.FirstName = loginStaff.FirstName;
                    SessionStaffData.LastName = loginStaff.FirstName;
                    SessionStaffData.Role = loginStaff.Role;
                    SessionStaffData.Image = loginStaff.Image;

                    MessageBox.Show("Successfully Login", "Authorized", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    isLogin = true;
                    CashierLayout ca = new CashierLayout();
                    Hide();
                    ca.Show();
                }
                else
                    throw new IncorrectCredentials("Incorrect Username or Password.");
            }
            catch (IncorrectCredentials ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            KioskLayout k = new KioskLayout();
            k.Show();
        }

        private void LoginLayout_Load(object sender, EventArgs e)
        {

        }
    }
}
