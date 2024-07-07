namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IBank
    {
        public Task<vmMasterDataDD?> ModifyBank(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListBanks();
        public Task<bool?> RemoveBank(string Id);
        public Task<vmMasterDataDD?> EditBank(string Id);


    }
}
