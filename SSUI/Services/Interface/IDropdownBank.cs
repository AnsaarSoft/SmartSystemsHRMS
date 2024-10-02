using SharedLibrary.Model.EmployeeManagement.Master;

namespace SSUI.Services.Interface
{
    public interface IDropdownBank
    {
        public Task<List<MstBank>?> ListBanks();
    }
}
