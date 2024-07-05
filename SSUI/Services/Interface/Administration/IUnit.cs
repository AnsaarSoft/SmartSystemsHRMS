namespace SSUI.Services.Interface.Administration
{
    public interface IUnit
    {
        public Task<vmMasterData?> ModifyUnit(vmMasterData UserInput);
        public Task<List<vmMasterData>?> ListUnits();
        public Task<bool?> RemoveUnit(string Id);
        public Task<vmMasterData?> EditUnit(string Id);
    }
}
