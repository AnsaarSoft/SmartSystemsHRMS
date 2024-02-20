namespace SSUI.Services.Interface.EmployeeManagement
{
    public interface IUser
    {
        public Task<MstUser> ValidateUser(vmLogin user);
    }
}
