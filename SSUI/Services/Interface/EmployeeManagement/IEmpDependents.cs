namespace SSUI.Services.Interface.EmployeeManagement
{
    public interface IEmpDependents
    {
        public Task<vmEmpData?> ModifyEmpDependent(vmEmpData UserInput);
        public Task<List<vmEmpData>?> ListEmpDependents();
        public Task<bool?> RemoveEmpDependent(string Id);
        public Task<vmEmpData?> EditEmpDependent(string Id);
    }
}
