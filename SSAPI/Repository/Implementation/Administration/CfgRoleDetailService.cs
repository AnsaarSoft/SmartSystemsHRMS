
namespace Server.Repository.Service.Administration
{

    public class CfgRoleDetailService : ICfgRoleDetail
    {
        private readonly AppDBContext odb;
        public CfgRoleDetailService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddRoleDetail(CfgRoleDetail oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.CfgRoleDetails.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRoleDetail(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.CfgRoleDetails
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

        public async Task<CfgRoleDetail> GetRoleDetail(Guid id)
        {
            CfgRoleDetail? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.CfgRoleDetails
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<CfgRoleDetail>> GetRoleDetailList()
        {
            List<CfgRoleDetail> oRecords = new();
            try
            {
                oRecords = await (from a in odb.CfgRoleDetails
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateRoleDetail(CfgRoleDetail oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.CfgRoleDetails.Update(oRecord);
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
