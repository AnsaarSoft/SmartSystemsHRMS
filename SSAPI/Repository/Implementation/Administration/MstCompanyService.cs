namespace SSAPI.Repository.Implementation.Administration
{
    public class MstCompanyService : IMstCompany
    {
        private readonly AppDBContext odb;
        public MstCompanyService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddCompany(MstCompany oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstCompanies.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCompany(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstCompanies
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

        public async Task<MstCompany> GetCompany(Guid id)
        {
            MstCompany? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstCompanies
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstCompany>> GetCompanyList()
        {
            List<MstCompany> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstCompanies
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateCompany(MstCompany oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstCompanies.Update(oRecord);
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
