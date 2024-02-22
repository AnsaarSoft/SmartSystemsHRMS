namespace Server.Repository.Interface.Employee
{
    public interface IMstEmpEducation
    {
        Task<MstEmpEducation> GetEmpEducation(int id);
        Task<List<MstEmpEducation>> GetEmpEducationList();
        Task<bool> AddEmpEducation(MstEmpEducation oRecord);
        Task<bool> UpdateEmpEducation(MstEmpEducation oRecord);
        Task<bool> DeleteEmpEducation(int id);
    }
}
