namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IDesignation
    {
        public Task<vmMasterDataDD?> ModifyDesignation(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListDesignations();
        public Task<bool?> RemoveDesignation(string Id);
        public Task<vmMasterDataDD?> EditDesignation(string Id);
    }
}
