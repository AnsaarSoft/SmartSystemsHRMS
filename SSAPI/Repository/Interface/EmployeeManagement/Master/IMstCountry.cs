namespace SSAPI.Repository.Interface.EmployeeManagement.Master
{
    public interface IMstCountry
    {
        Task<MstCountry> GetCountry(Guid id);
        Task<List<MstCountry>> GetCountryList();
        Task<bool> AddCountry(MstCountry oRecord);
        Task<bool> UpdateCountry(MstCountry oRecord);
        Task<bool> DeleteCountry(Guid id);
    }
}
