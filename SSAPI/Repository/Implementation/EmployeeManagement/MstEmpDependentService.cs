
namespace SSAPI.Repository.Implementation.EmployeeManagement
{
    public class MstEmpDependentService : IMstEmpDependent
    {
        private readonly AppDBContext odb;
        public MstEmpDependentService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddEmpDependent(MstEmpDependent oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstEmpDependents.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmpDependent(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstEmpDependents
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

        public async Task<MstEmpDependent> GetEmpDependent(Guid id)
        {
            MstEmpDependent? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstEmpDependents
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstEmpDependent>> GetEmpDependentList()
        {
            List<MstEmpDependent> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstEmpDependents
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateEmpDependent(MstEmpDependent oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstEmpDependents.Update(oRecord);
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
