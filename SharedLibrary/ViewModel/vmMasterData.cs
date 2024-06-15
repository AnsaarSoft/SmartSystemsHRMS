namespace SharedLibrary.ViewModel
{
    public class vmMasterData
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        public bool flgActive { get; set; } = true;

    }
}
