namespace SSUI.Services.Interface.EmployeeManagement
{
    public interface IUser
    {
        public Task<vmLogin> ValidateUser(vmLogin user);
    }
}
