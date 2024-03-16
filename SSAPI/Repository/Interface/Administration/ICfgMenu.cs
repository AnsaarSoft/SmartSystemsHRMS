namespace SSAPI.Repository.Interface.Administration
{
    public interface ICfgMenu
    {
        Task<CfgMenu> GetMenu(Guid id);
        Task<List<CfgMenu>> GetMenuList();
        Task<bool> AddMenu(CfgMenu oRecord);
        Task<bool> UpdateMenu(CfgMenu oRecord);
        Task<bool> DeleteMenu(Guid id);
    }
}
