﻿
namespace SSAPI.Repository.Implementation.EmployeeManagement.Master
{
    public class MstLocationService : IMstLocation
    {
        private readonly AppDBContext odb;
        public MstLocationService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddLocation(MstLocation oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.Attach(oRecord.Company);
                odb.Attach(oRecord.Unit);
                odb.MstLocations.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteLocation(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstLocations
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

        public async Task<MstLocation> GetLocation(Guid id)
        {
            MstLocation? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await odb.MstLocations
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

        public async Task<List<MstLocation>> GetLocationList()
        {
            List<MstLocation> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstLocations
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateLocation(MstLocation oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstLocations.Update(oRecord);
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
