﻿namespace SSAPI.Repository.Implementation.EmployeeManagement.Master
{
    public class MstDepartmentService : IMstDepartment
    {
        private readonly AppDBContext odb;
        public MstDepartmentService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddDepartment(MstDepartment oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }


                odb.Attach(oRecord.Company);
                odb.Attach(oRecord.Unit);

                odb.MstDepartments.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDepartment(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstDepartments
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

        public async Task<MstDepartment> GetDepartment(Guid id)
        {
            MstDepartment? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await odb.MstDepartments
                           .Include(b => b.Company)
                           .Include(b => b.Unit)
                           .FirstOrDefaultAsync(a => a.Id == id);

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstDepartment>> GetDepartmentList()
        {
            List<MstDepartment> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstDepartments
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateDepartment(MstDepartment oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstDepartments.Update(oRecord);
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
