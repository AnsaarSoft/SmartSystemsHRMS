namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstBranch
    {
        Task<MstBranch> GetBranch(int id);
        Task<List<MstBranch>> GetBranchList();
        Task<bool> AddBranch(MstBranch oRecord);
        Task<bool> UpdateBranch(MstBranch oRecord);
        Task<bool> DeleteBranch(int id);
    }
}
