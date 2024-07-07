namespace SharedLibrary.ViewModel
{
    public class vmCity
    {
        [Required]

        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";
        [StringLength(50)]
        [Required]

        public string Title { get; set; } = string.Empty;
        [Required]

        public MstCountry? Country { get; set; }
        [Required]

        public bool flgActive { get; set; } = true;
    }
}
