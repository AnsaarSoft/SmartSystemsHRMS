namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IDepartment
    {
        public Task<vmMasterData?> AddDepartment(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListDepartments();

    }
}
