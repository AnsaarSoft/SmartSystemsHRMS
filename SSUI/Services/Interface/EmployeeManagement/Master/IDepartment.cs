namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IDepartment
    {
        public Task<vmMasterDataDD?> ModifyDepartment(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListDepartments();
        public Task<bool?> RemoveDepartment(string Id);
        public Task<vmMasterDataDD?> EditDepartment(string Id);

    }
}
