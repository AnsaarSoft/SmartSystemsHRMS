using SharedLibrary.Model.OrganizationManagement;

namespace SSUI.Services.Interface
{
    public interface IDropdownCompany
    {
        public Task<List<MstCompany?>> ListCompanies();
    }
}
