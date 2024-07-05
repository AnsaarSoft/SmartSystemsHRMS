namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface ICity
    {
        public Task<vmMasterData?> ModifyCity(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListCities();
        public Task<bool?> RemoveCity(string Id);
        public Task<vmMasterData?> EditCity(string Id);
    }
}
