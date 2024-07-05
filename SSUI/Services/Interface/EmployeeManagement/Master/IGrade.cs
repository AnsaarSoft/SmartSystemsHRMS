namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IGrade
    {
        public Task<vmMasterData?> ModifyGrade(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListGrades();
        public Task<bool?> RemoveGrade(string Id);
        public Task<vmMasterData?> EditGrade(string Id);
    }
}
