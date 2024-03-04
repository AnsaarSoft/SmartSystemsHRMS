using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.ViewModel
{
    public class vmLogin
    {
        [Required]
        [StringLength(20, ErrorMessage ="Can't be more 20 Characters")]
        public string UserCode { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage ="Can't be more then 50 characters.")]
        public string Password { get; set; } = string.Empty;
        public string JwtToken { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public MstUser? ValidatedUser { get; set; }


    }
}
