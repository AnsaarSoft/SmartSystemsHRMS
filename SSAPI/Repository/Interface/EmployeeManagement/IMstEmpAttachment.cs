namespace Server.Repository.Interface.Employee
{
    public interface IMstEmpAttachment
    {
        Task<MstEmpAttachment> GetEmpAttachment(int id);
        Task<List<MstEmpAttachment>> GetEmpAttachmentList();
        Task<bool> AddEmpAttachment(MstEmpAttachment oRecord);
        Task<bool> UpdateEmpAttachment(MstEmpAttachment oRecord);
        Task<bool> DeleteEmpAttachment(int id);
    }
}
