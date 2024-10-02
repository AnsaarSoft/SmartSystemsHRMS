namespace SharedLibrary.ViewModel
{
    public class vmEmployee
    {

        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName { get; } = string.Empty;

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
    }
}
