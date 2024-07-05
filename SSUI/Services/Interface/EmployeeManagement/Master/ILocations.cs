namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface ILocations
    {
        public Task<vmMasterData?> ModifyLocation(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListLocations();
        public Task<bool?> RemoveLocation(string Id);
        public Task<vmMasterData?> EditLocation(string Id);
    }
}
