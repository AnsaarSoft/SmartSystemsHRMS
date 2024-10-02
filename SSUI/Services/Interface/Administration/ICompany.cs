namespace SSUI.Services.Interface.Administration
{
    public interface ICompany
    {
        public Task<vmCompany?> ModifyCompany(vmCompany UserInput);
        public Task<List<vmCompany>?> ListCompanies();
        public Task<bool?> RemoveCompany(string Id);
        public Task<vmCompany?> EditCompany(string Id);
    }
}
