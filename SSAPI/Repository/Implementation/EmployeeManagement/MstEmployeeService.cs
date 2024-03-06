namespace Server.Repository.Service.Employee
{
    public class MstEmployeeService : IMstEmployee
    {
        private readonly AppDBContext odb;
        public MstEmployeeService(AppDBContext _dbcontext)
        {
            odb = _dbcontext;
        }
        public Task<bool> AddEmployee(MstEmployee oRecord)
        {
            throw new NotImplementedException();

        }

        public Task<bool> DeleteEmployee(Guid id)
        {
            throw new NotImplementedException();

        }

        public Task<MstEmployee> GetEmployee(Guid id)
        {
            throw new NotImplementedException();

        }

        public Task<List<MstEmployee>> GetEmployeeList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployee(MstEmployee oRecord)
        {
            throw new NotImplementedException();
        }
    }
}
