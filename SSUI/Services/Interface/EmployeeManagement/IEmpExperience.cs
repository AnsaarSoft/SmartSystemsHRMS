namespace SSUI.Services.Interface.EmployeeManagement
{
    public interface IEmpExperience
    {
        public Task<vmEmpData?> ModifyEmpExperience(vmEmpData UserInput);
        public Task<List<vmEmpData>?> ListEmpExperiences();
        public Task<bool?> RemoveEmpExperience(string Id);
        public Task<vmEmpData?> EditEmpExperience(string Id);
    }
}
