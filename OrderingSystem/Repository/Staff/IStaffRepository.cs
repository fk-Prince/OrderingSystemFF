using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Staff
{
    public interface IStaffRepository
    {
        List<StaffModel> getStaff();
        StaffModel successfullyLogin(StaffModel staff);
        bool updateStaff(StaffModel staff);
        bool fireStaff(int staffId);
        bool addStaff(StaffModel staff);
        bool usernameExists(StaffModel staff);
    }
}
