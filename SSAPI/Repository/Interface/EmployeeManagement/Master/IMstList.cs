namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstList
    {
        Task<MstList> GetList(Guid id);
        Task<List<MstList>> GetListList();
        Task<bool> AddList(MstList oRecord);
        Task<bool> UpdateList(MstList oRecord);
        Task<bool> DeleteList(Guid id);
    }
}
