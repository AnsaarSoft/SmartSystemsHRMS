namespace SharedLibrary.Model.SystemManagement
{
    public class CfgRoleDetail
    {
        [Key, Required]
        public Guid Id { get; set; }
        public virtual CfgRole Role { get; set; } 
        public virtual CfgMenu Form { get; set; }
        public bool flgView { get; set; }
        public bool flgEdit { get; set; }
        public bool flgAdmin { get; set; }
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
