namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IBankBranch
    {
        public Task<vmBankBranch?> ModifyBankBranch(vmBankBranch UserInput);
        public Task<List<vmBankBranch>?> ListBankBranches();
        public Task<bool?> RemoveBankBranch(string Id);
        public Task<vmBankBranch?> EditBankBranch(string Id);
    }
}
