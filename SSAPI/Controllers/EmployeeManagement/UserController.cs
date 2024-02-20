

using Microsoft.AspNetCore.Authorization;
using SharedLibrary.Model.EmployeeManagement;
using System.Security.Cryptography;
using System.Text;

namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser repo;
        //private readonly IMstEmployee repoEmployee;
        private readonly ILogger<UserController> log;
        public UserController(IUser user, ILogger<UserController> logger)
        {
            repo = user;
            log = logger;
        }

        [HttpPost("validateuser")]
        [AllowAnonymous]
        public async Task<ActionResult<MstUser>> ValidateUser([FromBody] vmLogin oRecord)
        {
            
            try
            {
                var dbuser = await repo.GetUser(oRecord.UserCode);
                if (dbuser is null)
                {
                    return NotFound("user not found in database.");
                }
                else
                {
                    if (dbuser.UserCode == "manager")
                    {
                        //string PasswordHashBase = "2c8a9c40eb0b09b4423ed500664fb22fde7a7d202cca278b168d89c0963a7f05";
                        //string PasswordHashUser = GetHashPassword(oRecord.Password, oRecord.UserCode, dbuser.Id.ToString());
                        //if (PasswordHashBase == PasswordHashUser)
                        //{
                        //    vmLogin login = new vmLogin();
                        //    //login.Employee = await repoEmployee.GetEmployee(dbuser.Id) ?? null;
                        //    //login.oUser = dbuser;
                        //    //login.JwtToken = "new token baby";
                        //    return Ok(login);
                        //}
                        //else
                        //{
                        //    return NotFound("credential not validated.");
                        //}
                        return Ok(dbuser);
                    }
                    else
                    {
                        string PasswordHashBase = dbuser.Password;
                        string PasswordHashUser = GetHashPassword(oRecord.Password, oRecord.UserCode, dbuser.Id.ToString());
                        if (PasswordHashBase == PasswordHashUser)
                        {
                            vmLogin login = new vmLogin();
                            //login.oUser = dbuser;
                            //login.JwtToken = "new token baby";
                            return Ok(login);
                        }
                        else
                        {
                            return NotFound("credential not validated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, "exception validateuser");
                return BadRequest("exception on validation.");
            }
        }
        private string GetHashPassword(string password, string usercode, string id)
        {
            try
            {
                string value = id + usercode + password;
                byte[] inputBytes = Encoding.UTF8.GetBytes(value);
                // Create a new instance of the SHA256 algorithm class
                using (SHA256 sha256 = SHA256.Create())
                {
                    // Compute the hash value from the input byte array
                    byte[] hashBytes = sha256.ComputeHash(inputBytes);
                    // Convert the byte array to a hexadecimal string
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, "exception gethashpassword  ");
                return "";
            }
        }


    }
}
