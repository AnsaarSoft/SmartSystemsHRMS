namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface ICity
    {
        public Task<vmCity?> ModifyCity(vmCity UserInput);
        public Task<List<vmCity>?> ListCities();
        public Task<bool?> RemoveCity(string Id);
        public Task<vmCity?> EditCity(string Id);
    }
}
