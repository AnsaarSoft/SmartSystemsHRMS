namespace SharedLibrary.ViewModel
{
    public class vmBankBranch
    {
        [Required]

        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";
        [Required]

        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]

        public virtual MstBank Bank { get; set; }
        [Required]

        public virtual MstUnit? Unit { get; set; }
        [Required]

        public virtual MstCompany? Company { get; set; }
        [Required]

        public bool flgActive { get; set; } = true;
    }
}
