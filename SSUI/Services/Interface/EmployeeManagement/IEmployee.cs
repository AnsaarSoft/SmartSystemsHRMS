namespace SSUI.Services.Interface.EmployeeManagement
{
    public interface IEmployee
    {
        public Task<vmEmployee?> ModifyEmployee(vmEmployee UserInput);
        public Task<List<vmEmployee>?> ListEmployees();
        public Task<bool?> RemoveEmployee(string Id);
        public Task<vmEmployee?> EditEmployee(string Id);
    }
}
