
namespace Server.Repository.Service.Employee
{
    public class MstEmpExperienceService : IMstEmpExperience
    {
        private readonly AppDBContext odb;
        public MstEmpExperienceService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddEmpExperience(MstEmpExperience oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstEmpExperiences.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmpExperience(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstEmpExperiences
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

        public async Task<MstEmpExperience> GetEmpExperience(Guid id)
        {
            MstEmpExperience? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstEmpExperiences
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstEmpExperience>> GetEmpExperienceList()
        {
            List<MstEmpExperience> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstEmpExperiences
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateEmpExperience(MstEmpExperience oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstEmpExperiences.Update(oRecord);
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
