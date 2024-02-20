namespace SharedLibrary.Model.OrganizationManagement
{
    public class MstUnit
    {
        public Guid Id { get; set; }
        
        [StringLength(50)]
        public string UnitName { get; set; } = string.Empty;

        [StringLength(50)]
        public string Alias { get; set; } = string.Empty;

        public MstCompany? Company { get; set; }

        public string Status { get; set; } = string.Empty;

        public int UnitSize { get; set; }

        [StringLength(10)]
        public string Region { get; set; } = string.Empty;

        [StringLength(10)]
        public string Currency { get; set; } = string.Empty;
        
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
