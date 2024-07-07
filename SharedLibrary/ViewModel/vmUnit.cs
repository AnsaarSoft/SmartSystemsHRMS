namespace SharedLibrary.ViewModel
{
    public class vmUnit
    {
        [Required]
        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";
        [Required]
        [StringLength(50)]
        public string UnitName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Alias { get; set; } = string.Empty;
        [Required]
        public MstCompany? Company { get; set; }
        [Required]
        public int UnitSize { get; set; }
        [Required]
        [StringLength(10)]
        public string Region { get; set; } = string.Empty;
        [Required]
        [StringLength(10)]
        public string Currency { get; set; } = string.Empty;
        [Required]
        public bool flgActive { get; set; } = true;
    }
}
