namespace SSAPI.Repository.Interface.EmployeeManagement.Master
{
    public interface IMstDesignation
    {
        Task<MstDesignation> GetDesignation(Guid id);
        Task<List<MstDesignation>> GetDesignationList();
        Task<bool> AddDesignation(MstDesignation oRecord);
        Task<bool> UpdateDesignation(MstDesignation oRecord);
        Task<bool> DeleteDesignation(Guid id);
    }
}
