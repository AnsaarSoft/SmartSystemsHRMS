namespace SSAPI.Repository.Interface.Administration
{
    public interface ICfgRole
    {
        Task<CfgRole> GetRole(Guid id);
        Task<List<CfgRole>> GetRoleList();
        Task<bool> AddRole(CfgRole oRecord);
        Task<bool> UpdateRole(CfgRole oRecord);
        Task<bool> DeleteRole(Guid id);
    }
}
