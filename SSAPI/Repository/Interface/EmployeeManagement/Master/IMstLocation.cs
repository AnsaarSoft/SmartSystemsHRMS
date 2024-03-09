namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstLocation
    {
        Task<MstLocation> GetLocation(Guid id);
        Task<List<MstLocation>> GetLocationList();
        Task<bool> AddLocation(MstLocation oRecord);
        Task<bool> UpdateLocation(MstLocation oRecord);
        Task<bool> DeleteLocation(Guid id);
    }
}
