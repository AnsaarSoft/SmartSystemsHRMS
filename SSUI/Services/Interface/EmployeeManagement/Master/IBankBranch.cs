namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IBankBranch
    {
        public Task<vmMasterData?> ModifyBankBranch(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListBankBranches();
        public Task<bool?> RemoveBankBranch(string Id);
        public Task<vmMasterData?> EditBankBranch(string Id);
    }
}
