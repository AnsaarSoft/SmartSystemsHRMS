namespace SSUI.Services.Interface.EmployeeManagement
{
    public interface IEmpEducation
    {
        public Task<vmEmpData?> ModifyEmpEducation(vmEmpData UserInput);
        public Task<List<vmEmpData>?> ListEmpEducations();
        public Task<bool?> RemoveEmpEducation(string Id);
        public Task<vmEmpData?> EditEmpEducation(string Id);
    }
}
