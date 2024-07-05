namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IDesignation
    {
        public Task<vmMasterData?> ModifyDesignation(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListDesignations();
        public Task<bool?> RemoveDesignation(string Id);
        public Task<vmMasterData?> EditDesignation(string Id);
    }
}
