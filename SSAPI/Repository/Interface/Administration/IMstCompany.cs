namespace Server.Repository.Interface.Administration
{
    public interface IMstCompany
    {
        Task<MstCompany> GetCompany(int id);
        Task<List<MstCompany>> GetCompanyList();
        Task<bool> AddCompany(MstCompany oRecord);
        Task<bool> UpdateCompany(MstCompany oRecord);
        Task<bool> DeleteCompany(int id);
    }
}
