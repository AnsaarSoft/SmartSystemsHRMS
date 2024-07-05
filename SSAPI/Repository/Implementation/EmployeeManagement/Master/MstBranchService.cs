namespace SSAPI.Repository.Implementation.EmployeeManagement.Master
{
    public class MstBranchService : IMstBranch
    {
        private readonly AppDBContext odb;
        public MstBranchService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddBranch(MstBranch oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstBranches.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBranch(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstBranches
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

        public async Task<MstBranch> GetBranch(Guid id)
        {
            MstBranch? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstBranches
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstBranch>> GetBranchList()
        {
            List<MstBranch> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstBranches
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateBranch(MstBranch oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstBranches.Update(oRecord);
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
