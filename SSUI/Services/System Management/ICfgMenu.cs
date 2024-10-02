namespace SSUI.Services.System_Management
{
    public interface ICfgMenu
    {
        public Task<vmMasterDataDD?> ModifyCfgMenu(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListCfgMenus();
        public Task<bool?> RemoveCfgMenu(string Id);
        public Task<vmMasterDataDD?> EditCfgMenu(string Id);
    }
}
