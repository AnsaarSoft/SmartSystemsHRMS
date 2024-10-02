namespace SharedLibrary.Model.EmployeeManagement
{
    public class MstEmployee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName
        {
            get
            {
                var names = new List<string>();

                if (!string.IsNullOrWhiteSpace(FirstName))
                    names.Add(FirstName);
                if (!string.IsNullOrWhiteSpace(MiddleName))
                    names.Add(MiddleName);
                if (!string.IsNullOrWhiteSpace(LastName))
                    names.Add(LastName);

                return string.Join(" ", names);
            }
        }
        public string FatherName { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public DateTime? ServiceStartDate { get; set; }
        public DateTime? ServiceEndDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string HomeAddress { get; set; } = string.Empty;
        public string HomePhoneNumber { get; set; } = string.Empty;
        public string HomeEmail { get; set; } = string.Empty;
        public string HomeCity { get; set; } = string.Empty;
        public string HomeCountry { get; set; } = string.Empty;
        public string WorkAddress { get; set; } = string.Empty;
        public string WorkPhoneNumber { get; set; } = string.Empty;
        public string WorkEmail { get; set; } = string.Empty;
        public string WorkCity { get; set; } = string.Empty;
        public string WorkCountry { get; set; } = string.Empty;
        public int EmployeeID { get; set; }

        public bool UserType { get; set; }

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
