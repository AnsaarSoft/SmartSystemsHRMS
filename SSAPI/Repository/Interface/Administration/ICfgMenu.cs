namespace Server.Repository.Interface.Administration
{
    public interface ICfgMenu
    {
        Task<CfgMenu> GetMenu(int id);
        Task<List<CfgMenu>> GetMenuList();
        Task<bool> AddMenu(CfgMenu oRecord);
        Task<bool> UpdateMenu(CfgMenu oRecord);
        Task<bool> DeleteMenu(int id);
    }
}
