﻿namespace SharedLibrary.Model.OrganizationManagement
{
    public class MstCompany
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string CompanyName { get; set; } = string.Empty;

        [StringLength(50)]
        public string Alias { get; set; } = string.Empty;

        [StringLength(50)]
        public string Region { get; set; } = string.Empty;

        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        public int Subscription { get; set; }
        public string Status { get; set; } = string.Empty;
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
