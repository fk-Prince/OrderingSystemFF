using OrderingSystem.Model;

namespace OrderingSystem.Repository.Staff
{
    public interface IStaffRepository
    {

        StaffModel successfullyLogin(StaffModel staff);
    }
}
