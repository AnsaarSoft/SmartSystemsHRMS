namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstBranch
    {
        Task<MstBranch> GetBranch(Guid id);
        Task<List<MstBranch>> GetBranchList();
        Task<bool> AddBranch(MstBranch oRecord);
        Task<bool> UpdateBranch(MstBranch oRecord);
        Task<bool> DeleteBranch(Guid id);
    }
}
