namespace SSUI.Services.Interface.EmployeeManagement
{
    public interface IEmpAttachment
    {
        public Task<vmEmpAttachment?> ModifyEmpAttachment(vmEmpAttachment UserInput);
        public Task<List<vmEmpAttachment>?> ListEmpAttachments();
        public Task<bool?> RemoveEmpAttachment(string Id);
        public Task<vmEmpAttachment?> EditEmpAttachment(string Id);
    }
}
