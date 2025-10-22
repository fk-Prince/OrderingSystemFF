using System.Text.RegularExpressions;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repository.Staff;

namespace OrderingSystem.Services
{
    public class StaffServices
    {
        private readonly IStaffRepository staffRepository;
        public StaffServices()
        {
            staffRepository = new StaffRepository();
        }

        public bool isInputValidated(StaffModel staff)
        {
            string numberRegex = @"^09\d{9}$";
            string letterRegex = @"^[A-Za-z]+$";
            string numberLetterRegex = @"^[A-Za-z0-9]+$";
            if (!string.IsNullOrWhiteSpace(staff.PhoneNumber) && !Regex.IsMatch(staff.PhoneNumber, numberRegex))
            {
                MessageBox.Show("Invalid Phone number.");
                return false;
            }
            if (!Regex.IsMatch(staff.FirstName, letterRegex) || !Regex.IsMatch(staff.LastName, letterRegex))
            {
                MessageBox.Show("Invalid Name.");
                return false;
            }
            if (!string.IsNullOrWhiteSpace(staff.Password) && !Regex.IsMatch(staff.Password, numberLetterRegex))
            {
                MessageBox.Show("Password should not contain Special Characters.");
                return false;
            }

            if (isUsernameExists(staff))
            {
                MessageBox.Show("Username exists, Try another one");
                return false;
            }
            return true;
        }

        public bool updateStaff(StaffModel model)
        {
            return staffRepository.updateStaff(model);
        }
        public bool fireStaff(StaffModel model, int staffId)
        {
            if (model.StaffId == staffId)
            {
                MessageBox.Show("You are unable to fire yourself");
                return false;
            }
            return staffRepository.fireStaff(staffId);
        }

        public bool isUsernameExists(StaffModel staff)
        {
            return staffRepository.usernameExists(staff);
        }

        public bool addStaff(StaffModel staff)
        {
            if (!isInputValidated(staff)) return false;
            if (isUsernameExists(staff))
            {
                MessageBox.Show("Username exists, Try another one");
                return false;
            }

            return staffRepository.addStaff(staff);
        }
    }
}
