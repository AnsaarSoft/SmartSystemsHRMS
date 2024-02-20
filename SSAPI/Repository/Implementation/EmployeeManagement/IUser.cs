namespace SSAPI.Repository.Implementation.EmployeeManagement
{
    public interface IUser
    {
        Task<MstUser?> GetUser(Guid id);
        Task<MstUser?> GetUser(string usercode);
        Task<List<MstUser>> GetUserList();
        Task<bool> AddUser(MstUser oRecord);
        Task<bool> UpdateUser(MstUser oRecord);
        Task<bool> DeleteUser(Guid id);
    }
}
