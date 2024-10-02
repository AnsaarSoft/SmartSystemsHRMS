namespace SSUI.Services.Interface
{
    public interface IDropdownEmployee
    {
        public Task<List<MstEmployee>?> ListEmployees();

    }
}
