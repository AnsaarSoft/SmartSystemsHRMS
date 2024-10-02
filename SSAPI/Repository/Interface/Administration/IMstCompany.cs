namespace SSAPI.Repository.Interface.Administration
{
    public interface IMstCompany
    {
        Task<MstCompany> GetCompany(Guid id);
        Task<List<MstCompany>> GetCompanyList();
        Task<bool> AddCompany(MstCompany oRecord);
        Task<bool> UpdateCompany(MstCompany oRecord);
        Task<bool> DeleteCompany(Guid id);
    }
}
