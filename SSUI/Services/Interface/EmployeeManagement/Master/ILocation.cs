namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface ILocation
    {
        public Task<vmMasterDataDD?> ModifyLocation(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListLocations();
        public Task<bool?> RemoveLocation(string Id);
        public Task<vmMasterDataDD?> EditLocation(string Id);
    }
}
