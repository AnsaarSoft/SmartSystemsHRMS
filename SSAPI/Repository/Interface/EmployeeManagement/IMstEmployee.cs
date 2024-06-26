﻿namespace SSAPI.Repository.Interface.EmployeeManagement
{
    public interface IMstEmployee
    {
        Task<MstEmployee> GetEmployee(Guid id);
        Task<List<MstEmployee>> GetEmployeeList();
        Task<bool> AddEmployee(MstEmployee oRecord);
        Task<bool> UpdateEmployee(MstEmployee oRecord);
        Task<bool> DeleteEmployee(Guid id);
    }
}
