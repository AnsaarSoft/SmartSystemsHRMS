namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IBranch
    {
        public Task<vmMasterData?> ModifyBranch(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListBranches();
        public Task<bool?> RemoveBranch(string Id);
        public Task<vmMasterData?> EditBranch(string Id);
    }
}
