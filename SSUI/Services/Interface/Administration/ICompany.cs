namespace SSUI.Services.Interface.Administration
{
    public interface ICompany
    {
        public Task<vmMasterData?> ModifyCompany(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListCompanies();
        public Task<bool?> RemoveCompany(string Id);
        public Task<vmMasterData?> EditCompany(string Id);
    }
}
