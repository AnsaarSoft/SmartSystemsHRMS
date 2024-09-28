namespace SharedLibrary.ViewModel
{
    public class vmEmpData
    {
        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";
        public MstEmployee Employee { get; set; }
        [StringLength(100)]
        public string OrgName { get; set; } = string.Empty;
        [StringLength(100)]
        public string InstName { get; set; } = string.Empty;
        [StringLength(100)]
        public string DegreeName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MstList Relation { get; set; }

        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        [StringLength(50)]
        public string NationalCardNo { get; set; } = string.Empty;
        public bool flgActive { get; set; } = true;
    }
}
