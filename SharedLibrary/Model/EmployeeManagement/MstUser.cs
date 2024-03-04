namespace SharedLibrary.Model.EmployeeManagement
{
    public class MstUser
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50), Required]
        public string UserCode { get; set; } = string.Empty;
        [StringLength(100), Required, PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
        [StringLength(150), Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public UInt16 UserType { get; set; } //1 = super user 2 = super but company level 3 = mss user 4 = ess user
        public MstEmployee? Employee { get; set; }
        public MstUnit? Unit { get; set; }
        public MstCompany? Company { get; set; }
        public bool flgActive { get; set; } = true;

        public bool flgDelete { get; set; } = false;

        [StringLength(50)]
        public string CreatedBy { get; set; } = string.Empty;

        [StringLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [StringLength(20)]
        public string cAppStamp { get; set; } = string.Empty;
        [StringLength(20)]
        public string uAppStamp { get; set; } = string.Empty;
    }
}
