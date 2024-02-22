namespace Server.Repository.Interface.Employee
{
    public interface IMstUser
    {
        Task<MstUser> GetUser(Guid id);
        Task<List<MstUser>> GetUserList();
        Task<bool> AddUser(MstUser oRecord);
        Task<bool> UpdateUser(MstUser oRecord);
        Task<bool> DeleteUser(Guid id);

    }
}
