namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstBankBranch
    {
        Task<MstBankBranch> GetBankBranch(int id);
        Task<List<MstBankBranch>> GetBankBranchList();
        Task<bool> AddBankBranch(MstBankBranch oRecord);
        Task<bool> UpdateBankBranch(MstBankBranch oRecord);
        Task<bool> DeleteBankBranch(int id);
    }
}
