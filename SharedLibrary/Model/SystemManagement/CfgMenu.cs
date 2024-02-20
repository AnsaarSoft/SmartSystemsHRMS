namespace SharedLibrary.Model.SystemManagement
{
    public class CfgMenu
    {
        [Key, Required]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        public bool FlgHead { get; set; }

        public bool FlgForm { get; set; }

        [StringLength(200)]
        public string FormUrl { get; set; } = string.Empty;

        public CfgMenu ParentForm { get; set; }

        [StringLength(100)]
        public string FormIcon { get; set; } = string.Empty;
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
