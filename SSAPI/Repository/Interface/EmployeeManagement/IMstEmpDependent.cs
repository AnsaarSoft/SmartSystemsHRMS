namespace Server.Repository.Interface.Employee
{
    public interface IMstEmpDependent
    {
        Task<MstEmpDependent> GetEmpDependent(int id);
        Task<List<MstEmpDependent>> GetEmpDependentList();
        Task<bool> AddEmpDependent(MstEmpDependent oRecord);
        Task<bool> UpdateEmpDependent(MstEmpDependent oRecord);
        Task<bool> DeleteEmpDependent(int id);
    }
}
