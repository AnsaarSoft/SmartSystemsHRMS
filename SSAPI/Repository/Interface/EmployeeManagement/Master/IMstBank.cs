namespace Server.Repository.Interface.Employee.Master
{
    public interface IMstBank
    {
        Task<MstBank> GetBank(int id);
        Task<List<MstBank>> GetBankList();
        Task<bool> AddBank(MstBank oRecord);
        Task<bool> UpdateBank(MstBank oRecord);
        Task<bool> DeleteBank(int id);
    }
}
