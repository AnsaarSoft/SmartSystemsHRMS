namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstBankBranch
    {
        Task<MstBankBranch> GetBankBranch(Guid id);
        Task<List<MstBankBranch>> GetBankBranchList();
        Task<bool> AddBankBranch(MstBankBranch oRecord);
        Task<bool> UpdateBankBranch(MstBankBranch oRecord);
        Task<bool> DeleteBankBranch(Guid id);
    }
}
