namespace Server.Repository.Interface.Employee
{
    public interface IMstEmpAttachment
    {
        Task<MstEmpAttachment> GetEmpAttachment(Guid id);
        Task<List<MstEmpAttachment>> GetEmpAttachmentList();
        Task<bool> AddEmpAttachment(MstEmpAttachment oRecord);
        Task<bool> UpdateEmpAttachment(MstEmpAttachment oRecord);
        Task<bool> DeleteEmpAttachment(Guid id);
    }
}
