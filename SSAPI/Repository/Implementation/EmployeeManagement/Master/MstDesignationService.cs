﻿namespace SSAPI.Repository.Implementation.EmployeeManagement.Master
{
    public class MstDesignationService : IMstDesignation
    {
        private readonly AppDBContext odb;
        public MstDesignationService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddDesignation(MstDesignation oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.Attach(oRecord.Company);
                odb.Attach(oRecord.Unit);
                odb.MstDesignations.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDesignation(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstDesignations
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

        public async Task<MstDesignation> GetDesignation(Guid id)
        {
            MstDesignation? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await odb.MstDesignations
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

        public async Task<List<MstDesignation>> GetDesignationList()
        {
            List<MstDesignation> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstDesignations
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateDesignation(MstDesignation oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstDesignations.Update(oRecord);
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
