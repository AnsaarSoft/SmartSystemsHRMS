namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IBank
    {
        public Task<vmMasterData?> ModifyBank(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListBanks();
        public Task<bool?> RemoveBank(string Id);
        public Task<vmMasterData?> EditBank(string Id);
    }
}
