namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstCity
    {
        Task<MstCity> GetCity(Guid id);
        Task<List<MstCity>> GetCityList();
        Task<bool> AddCity(MstCity oRecord);
        Task<bool> UpdateCity(MstCity oRecord);
        Task<bool> DeleteCity(Guid id);
    }
}
