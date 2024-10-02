namespace SharedLibrary.ViewModel
{
    public class vmMasterData
    {
        [Required]

        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";
        [Required]

        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]

        public bool flgActive { get; set; } = true;

    }
}
