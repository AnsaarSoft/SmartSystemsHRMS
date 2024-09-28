using SharedLibrary.Model.EmployeeManagement.Master;

namespace SSUI.Services.Interface
{
    public interface IListsDropdown
    {
        public Task<List<MstList>?> ListLists();
    }
}
