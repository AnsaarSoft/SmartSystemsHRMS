namespace Server.Repository.Interface.Administration
{
    public interface ICfgRole
    {
        Task<CfgRole> GetRole(int id);
        Task<List<CfgRole>> GetRoleList();
        Task<bool> AddRole(CfgRole oRecord);
        Task<bool> UpdateRole(CfgRole oRecord);
        Task<bool> DeleteRole(int id);
    }
}
