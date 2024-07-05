namespace SSAPI.Repository.Implementation.EmployeeManagement.Master
{
    public class MstGradeService : IMstGrade
    {
        private readonly AppDBContext odb;
        public MstGradeService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddGrade(MstGrade oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstGrades.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteGrade(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstGrades
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

        public async Task<MstGrade> GetGrade(Guid id)
        {
            MstGrade? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstGrades
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstGrade>> GetGradeList()
        {
            List<MstGrade> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstGrades
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateGrade(MstGrade oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstGrades.Update(oRecord);
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
