namespace SSAPI.Repository.Implementation.EmployeeManagement
{
    public class MstUserService : IMstUser
    {
        private readonly AppDBContext odb;
        public MstUserService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }

        public async Task<bool> AddUser(MstUser oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstUsers.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateUser(MstUser oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }
                odb.MstUsers.Update(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstUsers
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

        public async Task<MstUser?> GetUser(Guid id)
        {
            MstUser? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await (from a in odb.MstUsers
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<MstUser?> GetUser(string usercode)
        {
            MstUser? oRecord = new();
            try
            {
                if (string.IsNullOrEmpty(usercode)) { return oRecord; }
                oRecord = await (from a in odb.MstUsers
                                 where a.UserCode == usercode
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstUser>> GetUserList()
        {
            List<MstUser> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstUsers
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }


    }
}
