using SharedLibrary.Model.OrganizationManagement;

namespace SSUI.Services.Interface
{
    public interface IDropdownUnit
    {
        public Task<List<MstUnit>?> ListUnits();

    }
}
