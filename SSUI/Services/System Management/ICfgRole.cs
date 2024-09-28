namespace SSUI.Services.System_Management
{
    public interface ICfgRole
    {
        public Task<vmMasterDataDD?> ModifyCfgRole(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListCfgRoles();
        public Task<bool?> RemoveCfgRole(string Id);
        public Task<vmMasterDataDD?> EditCfgRole(string Id);
    }
}
