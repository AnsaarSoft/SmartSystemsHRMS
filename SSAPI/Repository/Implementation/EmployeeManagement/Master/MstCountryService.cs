namespace Server.Repository.Service.Employee.Master
{
    public class MstCountryService : IMstCountry
    {
        private readonly AppDBContext odb;
        public MstCountryService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddCountry(MstCountry oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstCountries.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCountry(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstCountries
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

        public async Task<MstCountry> GetCountry(Guid id)
        {
            MstCountry? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstCountries
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstCountry>> GetCountryList()
        {
            List<MstCountry> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstCountries
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateCountry(MstCountry oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstCountries.Update(oRecord);
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
