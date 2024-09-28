namespace SSUI.Services.System_Management
{
    public interface ICfgRoleDetail
    {
        public Task<vmMasterDataDD?> ModifyCfgRoleDetail(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListCfgRoleDetails();
        public Task<bool?> RemoveCfgRoleDetail(string Id);
        public Task<vmMasterDataDD?> EditCfgRoleDetail(string Id);
    }
}
