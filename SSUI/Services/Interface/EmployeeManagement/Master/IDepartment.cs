namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IDepartment
    {
        public Task<vmMasterData?> ModifyDepartment(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListDepartments();
        public Task<bool?> RemoveDepartment(string Id);
        public Task<vmMasterData?> EditDepartment(string Id);

    }
}
