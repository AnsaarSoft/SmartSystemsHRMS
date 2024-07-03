namespace SharedLibrary.ViewModel
{
    public class vmMasterData
    {
        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";

        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        public bool flgActive { get; set; } = true;

    }
}
