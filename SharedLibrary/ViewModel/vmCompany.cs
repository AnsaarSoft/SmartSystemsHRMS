namespace SharedLibrary.ViewModel
{
    public class vmCompany
    {
        [Required]

        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";
        [StringLength(50)]
        [Required]

        public string CompanyName { get; set; } = string.Empty;
        [Required]

        [StringLength(50)]
        public string Alias { get; set; } = string.Empty;
        [Required]

        [StringLength(50)]
        public string Region { get; set; } = string.Empty;
        [Required]

        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
        [Required]

        public int Subscription { get; set; }
        [Required]

        public bool flgActive { get; set; } = true;
    }
}
