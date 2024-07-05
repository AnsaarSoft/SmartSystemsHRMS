namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IList
    {
        public Task<vmMasterData?> ModifyList(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListLists();
        public Task<bool?> RemoveList(string Id);
        public Task<vmMasterData?> EditList(string Id);
    }
}
