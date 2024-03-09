
namespace Server.Repository.Service.Administration
{
    public class CfgRoleService : ICfgRole
    {
        private readonly AppDBContext odb;
        public CfgRoleService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddRole(CfgRole oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.CfgRoles.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.CfgRoles
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

        public async Task<CfgRole> GetRole(Guid id)
        {
            CfgRole? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.CfgRoles
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<CfgRole>> GetRoleList()
        {
            List<CfgRole> oRecords = new();
            try
            {
                oRecords = await (from a in odb.CfgRoles
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateRole(CfgRole oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.CfgRoles.Update(oRecord);
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
