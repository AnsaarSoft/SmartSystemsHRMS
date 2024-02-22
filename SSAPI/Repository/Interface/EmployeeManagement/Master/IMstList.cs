namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstList
    {
        Task<MstList> GetList(int id);
        Task<List<MstList>> GetListList();
        Task<bool> AddList(MstList oRecord);
        Task<bool> UpdateList(MstList oRecord);
        Task<bool> DeleteList(int id);
    }
}
