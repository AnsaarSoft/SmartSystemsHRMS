namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IBranch
    {
        public Task<vmMasterDataDD?> ModifyBranch(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListBranches();
        public Task<bool?> RemoveBranch(string Id);
        public Task<vmMasterDataDD?> EditBranch(string Id);
    }
}
