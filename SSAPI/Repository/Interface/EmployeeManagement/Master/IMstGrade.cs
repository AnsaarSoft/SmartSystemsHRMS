﻿namespace SSAPI.Repository.Interface.EmployeeManagement.Master
{
    public interface IMstGrade
    {
        Task<MstGrade> GetGrade(Guid id);
        Task<List<MstGrade>> GetGradeList();
        Task<bool> AddGrade(MstGrade oRecord);
        Task<bool> UpdateGrade(MstGrade oRecord);
        Task<bool> DeleteGrade(Guid id);
    }
}
