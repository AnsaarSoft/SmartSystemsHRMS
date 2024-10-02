namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IGrade
    {
        public Task<vmMasterDataDD?> ModifyGrade(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListGrades();
        public Task<bool?> RemoveGrade(string Id);
        public Task<vmMasterDataDD?> EditGrade(string Id);
    }
}
