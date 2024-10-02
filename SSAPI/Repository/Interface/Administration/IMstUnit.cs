namespace SSAPI.Repository.Interface.Administration
{
    public interface IMstUnit
    {
        Task<MstUnit> GetUnit(Guid id);
        Task<List<MstUnit>> GetUnitList();
        Task<bool> AddUnit(MstUnit oRecord);
        Task<bool> UpdateUnit(MstUnit oRecord);
        Task<bool> DeleteUnit(Guid id);
    }
}
