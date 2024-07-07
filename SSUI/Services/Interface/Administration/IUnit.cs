namespace SSUI.Services.Interface.Administration
{
    public interface IUnit
    {
        public Task<vmUnit?> ModifyUnit(vmUnit UserInput);
        public Task<List<vmUnit>?> ListUnits();
        public Task<bool?> RemoveUnit(string Id);
        public Task<vmUnit?> EditUnit(string Id);
    }
}
