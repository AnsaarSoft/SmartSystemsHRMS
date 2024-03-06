namespace Server.Repository.Service.Administration
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
                oRecord = await (from a in odb.MstUnits
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

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
