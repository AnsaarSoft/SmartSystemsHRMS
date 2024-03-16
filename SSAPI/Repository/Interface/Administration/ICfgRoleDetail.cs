namespace SSAPI.Repository.Interface.Administration
{
    public interface ICfgRoleDetail
    {
        Task<CfgRoleDetail> GetRoleDetail(Guid id);
        Task<List<CfgRoleDetail>> GetRoleDetailList();
        Task<bool> AddRoleDetail(CfgRoleDetail oRecord);
        Task<bool> UpdateRoleDetail(CfgRoleDetail oRecord);
        Task<bool> DeleteRoleDetail(Guid id);
    }
}
