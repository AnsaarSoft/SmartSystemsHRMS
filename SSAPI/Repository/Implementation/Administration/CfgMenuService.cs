 namespace SSAPI.Repository.Implementation.Administration
{

    public class CfgMenuService : ICfgMenu
    {
        private readonly AppDBContext odb;
        public CfgMenuService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddMenu(CfgMenu oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.CfgMenus.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMenu(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.CfgMenus
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

        public async Task<CfgMenu> GetMenu(Guid id)
        {
            CfgMenu? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.CfgMenus
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<CfgMenu>> GetMenuList()
        {
            List<CfgMenu> oRecords = new();
            try
            {
                oRecords = await (from a in odb.CfgMenus
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateMenu(CfgMenu oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.CfgMenus.Update(oRecord);
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
