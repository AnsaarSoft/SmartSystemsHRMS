namespace SharedLibrary.ViewModel
{
    public class vmList
    {
        [Required]

        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";
        [Required]

        public string Title { get; set; } = string.Empty;
        [Required]

        public string Type { get; set; } = string.Empty;
        [Required]

        public bool flgActive { get; set; } = true;
    }
}
