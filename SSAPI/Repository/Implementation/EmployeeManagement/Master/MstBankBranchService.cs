namespace SSAPI.Repository.Implementation.EmployeeManagement.Master
{
    public class MstBankBranchService : IMstBankBranch
    {
        private readonly AppDBContext odb;
        public MstBankBranchService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public async Task<bool> AddBankBranch(MstBankBranch oRecord)
        {
            try
            {
                if (oRecord is null) { return false; }

                odb.Attach(oRecord.Company);
                odb.Attach(oRecord.Unit);
                odb.Attach(oRecord.Bank);

                odb.MstBankBranches.Add(oRecord);
                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBankBranch(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                var oRecord = await (from a in odb.MstBankBranches
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

        public async Task<MstBankBranch> GetBankBranch(Guid id)
        {
            MstBankBranch? oRecord = new();
            try
            {
                if (id == Guid.Empty) { return oRecord; }
                oRecord = await odb.MstBankBranches
                           .Include(b => b.Company)
                           .Include(b => b.Unit)
                           .Include(b => b.Bank)
                           .FirstOrDefaultAsync(a => a.Id == id);

                return oRecord;
            }
            catch (Exception)
            {
                return oRecord;
            }
        }

        public async Task<List<MstBankBranch>> GetBankBranchList()
        {
            List<MstBankBranch> oRecords = new();
            try
            {
                oRecords = await (from a in odb.MstBankBranches
                                  where a.flgDelete == false
                                  select a).ToListAsync();
            }
            catch (Exception)
            {

            }
            return oRecords;
        }

        public async Task<bool> UpdateBankBranch(MstBankBranch oRecord)
        {
            try
            {
                if (oRecord == null) return false;

                // Fetch the existing entity with no tracking
                var existingBankBranch = await odb.MstBankBranches
                    .Include(b => b.Company)
                    .Include(b => b.Unit)
                    .AsNoTracking() // Ensure no tracking
                    .FirstOrDefaultAsync(b => b.Id == oRecord.Id);

                if (existingBankBranch == null) return false;

                // Attach the main entity
                odb.MstBankBranches.Attach(oRecord);
                odb.Entry(oRecord).State = EntityState.Modified;

                // Attach the Company if it exists in the database
                if (oRecord.Company != null)
                {
                    var existingCompany = await odb.MstCompanies
                        .AsNoTracking() // Ensure no tracking
                        .FirstOrDefaultAsync(c => c.Id == oRecord.Company.Id);

                    if (existingCompany != null)
                    {
                        odb.Entry(oRecord.Company).State = EntityState.Detached;
                        odb.Attach(oRecord.Company);
                    }
                }

                // Attach the Unit if it exists in the database
                if (oRecord.Unit != null)
                {
                    var existingUnit = await odb.MstUnits
                        .AsNoTracking() // Ensure no tracking
                        .FirstOrDefaultAsync(u => u.Id == oRecord.Unit.Id);

                    if (existingUnit != null)
                    {
                        odb.Entry(oRecord.Unit).State = EntityState.Detached;
                        odb.Attach(oRecord.Unit);
                    }
                }

                await odb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    }
}
