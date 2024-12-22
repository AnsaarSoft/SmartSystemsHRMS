namespace SharedLibrary.ViewModel
{
    public class vmEmpAttachment
    {
        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";

        public MstEmployee Employee { get; set; }

        [StringLength(100)]
        public string FileName { get; set; } = string.Empty;

        [StringLength(500)]
        public string FilePath { get; set; } = string.Empty;

        [StringLength(200)]
        public string Remarks { get; set; } = string.Empty;
        public bool flgActive { get; set; } = true;
    }
}
