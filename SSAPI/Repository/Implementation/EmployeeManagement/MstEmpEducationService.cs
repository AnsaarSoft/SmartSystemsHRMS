
namespace SSAPI.Repository.Implementation.EmployeeManagement
{
    public class MstEmpEducationService : IMstEmpEducation
    {
        private readonly AppDBContext odb;
        public MstEmpEducationService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddEmpEducation(MstEmpEducation oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.Attach(oRecord.Employee);
                odb.MstEmpEducations.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmpEducation(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstEmpEducations
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

        public async Task<MstEmpEducation> GetEmpEducation(Guid id)
        {
            MstEmpEducation? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstEmpEducations
                                 where a.Id == id
                                 select a)
                                 .Include(e => e.Employee)
                                 .Where(x => x.flgDelete == false).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstEmpEducation>> GetEmpEducationList()
        {
            List<MstEmpEducation> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstEmpEducations
                                  select a)
                                  .Include(e => e.Employee)
                                   .Where(x => x.flgDelete == false).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateEmpEducation(MstEmpEducation oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstEmpEducations.Update(oRecord);
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
