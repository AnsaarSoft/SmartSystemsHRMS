namespace SSAPI.Repository.Implementation.EmployeeManagement.Master
{
    public class MstBankBranchService : IMstBankBranch
    {
        private readonly AppDBContext odb;
        public MstBankBranchService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddBankBranch(MstBankBranch oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstBankBranches.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBankBranch(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstBankBranches
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

        public async Task<MstBankBranch> GetBankBranch(Guid id)
        {
            MstBankBranch? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstBankBranches
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstBankBranch>> GetBankBranchList()
        {
            List<MstBankBranch> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstBankBranches
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateBankBranch(MstBankBranch oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstBankBranches.Update(oRecord);
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
