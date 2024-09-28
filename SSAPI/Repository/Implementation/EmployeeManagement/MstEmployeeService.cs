namespace SSAPI.Repository.Implementation.EmployeeManagement
{
    public class MstEmployeeService : IMstEmployee
    {
        private readonly AppDBContext odb;
        public MstEmployeeService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddEmployee(MstEmployee oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }

                odb.MstEmployees.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }

                var oRecord = await (from a in odb.MstEmployees
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

        public async Task<MstEmployee> GetEmployee(Guid id)
        {
            MstEmployee? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await odb.MstEmployees
                           .FirstOrDefaultAsync(a => a.Id == id);

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstEmployee>> GetEmployeeList()
        {
            List<MstEmployee> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstEmployees
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateEmployee(MstEmployee oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstEmployees.Update(oRecord);
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
