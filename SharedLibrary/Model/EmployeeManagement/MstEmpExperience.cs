namespace SharedLibrary.Model.EmployeeManagement
{
    public class MstEmpExperience
    {
        [Key, Required]
        public Guid Id { get; set; }

        public MstEmployee Employee { get; set; }

        [StringLength(100)]
        public string OrgName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
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
