namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface ICountry
    {
        public Task<vmMasterData?> ModifyCountry(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListCountries();
        public Task<bool?> RemoveCountry(string Id);
        public Task<vmMasterData?> EditCountry(string Id);
    }
}
