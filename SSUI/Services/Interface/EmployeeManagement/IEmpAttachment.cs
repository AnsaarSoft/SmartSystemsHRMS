namespace SSUI.Services.Interface.EmployeeManagement
{
    public interface IEmpAttachment
    {
        public Task<vmMasterDataDD?> ModifyEmpAttachment(vmMasterDataDD UserInput);
        public Task<List<vmMasterDataDD>?> ListEmpAttachments();
        public Task<bool?> RemoveEmpAttachment(string Id);
        public Task<vmMasterDataDD?> EditEmpAttachment(string Id);
    }
}
