namespace SSUI.Services.Interface.EmployeeManagement.Master
{
    public interface IList
    {
        public Task<vmList?> ModifyList(vmList UserInput);
        public Task<List<vmList>?> ListLists();
        public Task<bool?> RemoveList(string Id);
        public Task<vmList?> EditList(string Id);
    }
}
