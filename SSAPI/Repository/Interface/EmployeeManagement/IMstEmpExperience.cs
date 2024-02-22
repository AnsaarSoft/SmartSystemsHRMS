namespace Server.Repository.Interface.Employee
{
    public interface IMstEmpExperience
    {
        Task<MstEmpExperience> GetEmpExperience(int id);
        Task<List<MstEmpExperience>> GetEmpExperienceList();
        Task<bool> AddEmpExperience(MstEmpExperience oRecord);
        Task<bool> UpdateEmpExperience(MstEmpExperience oRecord);
        Task<bool> DeleteEmpExperience(int id);
    }
}
