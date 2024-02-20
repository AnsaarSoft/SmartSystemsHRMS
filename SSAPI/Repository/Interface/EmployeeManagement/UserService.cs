namespace SSAPI.Repository.Interface.EmployeeManagement
{
    public class UserService : IUser
    {
        private readonly AppDBContext odb;
        private readonly ILogger<UserService> log;

        public UserService(AppDBContext db, ILogger<UserService> logger)
        {
            log = logger;
            odb = db;
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
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
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
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);   
                return false;
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var oRecord = await (from a in odb.MstUsers
                                     where a.Id == id
                                     select a).FirstOrDefaultAsync();
                if (oRecord is null) { log.LogInformation($"user not found in db {id}"); return false; }
                oRecord.flgDelete = true;
                oRecord.flgActive = false;
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<MstUser?> GetUser(Guid id)
        {
            MstUser? oRecord = new();
            try
            {
                oRecord = await (from a in odb.MstUsers
                                 where a.Id == id
                                 select a).FirstOrDefaultAsync();

                return oRecord;
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
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
            catch (Exception ex)
            {
                log.LogError(ex, "getuser error on database");
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
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
            }
            return oRecords;
        }

    }
}
