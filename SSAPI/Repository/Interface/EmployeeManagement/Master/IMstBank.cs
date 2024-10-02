namespace SSAPI.Repository.Interface.EmployeeManagement.Master
{
    public interface IMstBank
    {
        Task<MstBank> GetBank(Guid id);
        Task<List<MstBank>> GetBankList();
        Task<bool> AddBank(MstBank oRecord);
        Task<bool> UpdateBank(MstBank oRecord);
        Task<bool> DeleteBank(Guid id);
    }
}
