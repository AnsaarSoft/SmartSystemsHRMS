namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstLocation
    {
        Task<MstLocation> GetLocation(int id);
        Task<List<MstLocation>> GetLocationList();
        Task<bool> AddLocation(MstLocation oRecord);
        Task<bool> UpdateLocation(MstLocation oRecord);
        Task<bool> DeleteLocation(int id);
    }
}
