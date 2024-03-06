namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstDepartment
    {
        Task<MstDepartment> GetDepartment(Guid id);
        Task<List<MstDepartment>> GetDepartmentList();
        Task<bool> AddDepartment(MstDepartment oRecord);
        Task<bool> UpdateDepartment(MstDepartment oRecord);
        Task<bool> DeleteDepartment(Guid id);
    }
}
