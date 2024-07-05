
namespace SSAPI.Repository.Implementation.EmployeeManagement.Master
{
    public class MstBankService : IMstBank
    {
        private readonly AppDBContext odb;
        public MstBankService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddBank(MstBank oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstBanks.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBank(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstBanks
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

        public async Task<MstBank> GetBank(Guid id)
        {
            MstBank? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstBanks
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstBank>> GetBankList()
        {
            List<MstBank> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstBanks
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateBank(MstBank oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstBanks.Update(oRecord);
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
