namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstCountry
    {
        Task<MstCountry> GetCountry(int id);
        Task<List<MstCountry>> GetCountryList();
        Task<bool> AddCountry(MstCountry oRecord);
        Task<bool> UpdateCountry(MstCountry oRecord);
        Task<bool> DeleteCountry(int id);
    }
}
