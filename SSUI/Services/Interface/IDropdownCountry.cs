using SharedLibrary.Model.EmployeeManagement.Master;

namespace SSUI.Services.Interface
{
    public interface IDropdownCountry
    {
        public Task<List<MstCountry>?> ListCountries();
    }
}
