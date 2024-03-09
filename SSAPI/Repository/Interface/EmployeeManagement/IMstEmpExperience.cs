namespace Server.Repository.Interface.Employee
{
    public interface IMstEmpExperience
    {
        Task<MstEmpExperience> GetEmpExperience(Guid id);
        Task<List<MstEmpExperience>> GetEmpExperienceList();
        Task<bool> AddEmpExperience(MstEmpExperience oRecord);
        Task<bool> UpdateEmpExperience(MstEmpExperience oRecord);
        Task<bool> DeleteEmpExperience(Guid id);
    }
}
