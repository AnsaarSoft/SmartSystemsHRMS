namespace SSAPI.Repository.Interface.EmployeeManagement
{
    public interface IMstEmpDependent
    {
        Task<MstEmpDependent> GetEmpDependent(Guid id);
        Task<List<MstEmpDependent>> GetEmpDependentList();
        Task<bool> AddEmpDependent(MstEmpDependent oRecord);
        Task<bool> UpdateEmpDependent(MstEmpDependent oRecord);
        Task<bool> DeleteEmpDependent(Guid id);
    }
}
