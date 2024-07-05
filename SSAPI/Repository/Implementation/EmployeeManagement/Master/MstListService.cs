namespace SSAPI.Repository.Implementation.EmployeeManagement.Master
{
    public class MstListService : IMstList
    {
        private readonly AppDBContext odb;
        public MstListService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddList(MstList oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstLists.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteList(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstLists
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

        public async Task<MstList> GetList(Guid id)
        {
            MstList? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstLists
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstList>> GetListList()
        {
            List<MstList> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstLists
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateList(MstList oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstLists.Update(oRecord);
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
