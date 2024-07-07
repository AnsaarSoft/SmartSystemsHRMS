namespace SSAPI.Repository.Implementation.Administration
{
    public class MstUnitService : IMstUnit
    {
        private readonly AppDBContext odb;
        public MstUnitService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddUnit(MstUnit oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.Attach(oRecord.Company);

                odb.MstUnits.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUnit(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }

                var hasBanks = await odb.MstBanks.AnyAsync(x => x.Unit.Id == id);
                var hasBankBranches = await odb.MstBankBranches.AnyAsync(x => x.Unit.Id == id);
                var hasBranches = await odb.MstBranches.AnyAsync(x => x.Unit.Id == id);
                var hasDepartments = await odb.MstDepartments.AnyAsync(x => x.Unit.Id == id);
                var hasDesignations = await odb.MstDesignations.AnyAsync(x => x.Unit.Id == id);
                var hasGrades = await odb.MstGrades.AnyAsync(x => x.Unit.Id == id);
                var hasLocations = await odb.MstLocations.AnyAsync(x => x.Unit.Id == id);

                if (hasBanks || hasBankBranches || hasBranches || hasDepartments || hasDesignations || hasGrades || hasLocations)
                {
                    return false;
                }

                var oRecord = await (from a in odb.MstUnits
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

        public async Task<MstUnit> GetUnit(Guid id)
        {
            MstUnit? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await odb.MstUnits
                          .Include(b => b.Company)
                          .FirstOrDefaultAsync(a => a.Id == id);

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstUnit>> GetUnitList()
        {
            List<MstUnit> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstUnits
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateUnit(MstUnit oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstUnits.Update(oRecord);
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
