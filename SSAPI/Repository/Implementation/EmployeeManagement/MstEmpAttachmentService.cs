
namespace Server.Repository.Service.Employee
{
    public class MstEmpAttachmentService : IMstEmpAttachment
    {
        private readonly AppDBContext odb;
        public MstEmpAttachmentService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddEmpAttachment(MstEmpAttachment oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstEmpAttachments.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmpAttachment(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstEmpAttachments
                                     where a.Id == id
                                     select a).FirstOrDefaultAsync();
                if (oRecord is null) { return false; }
                oRecord.flgDelete = true;
                oRecord.flgActive = false;
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<MstEmpAttachment> GetEmpAttachment(Guid id)
        {
            MstEmpAttachment? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstEmpAttachments
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstEmpAttachment>> GetEmpAttachmentList()
        {
            List<MstEmpAttachment> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstEmpAttachments
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateEmpAttachment(MstEmpAttachment oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstEmpAttachments.Update(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
