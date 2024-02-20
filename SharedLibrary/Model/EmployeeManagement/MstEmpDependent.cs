namespace SharedLibrary.Model.EmployeeManagement
{
    public class MstEmpDependent
    {
        [Key, Required]
        public Guid Id { get; set; }
        public MstEmployee Employee { get; set; }

        public MstList Relation { get; set; }

        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        [StringLength(50)]
        public string NationalCardNo { get; set; } = string.Empty;
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
