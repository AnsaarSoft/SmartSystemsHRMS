namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMstUser repo;
        //private readonly IMstEmployee repoEmployee;
        private readonly ILogger<UserController> log;
        private readonly IConfiguration config;

        public UserController(IMstUser user, ILogger<UserController> logger, IConfiguration configuration)
        {
            repo = user;
            log = logger;
            config = configuration;
        }

        [HttpPost("validateuser"), AllowAnonymous]
        public async Task<ActionResult<vmLogin>> ValidateUser([FromBody] vmLogin oRecord)
        {
            vmLogin login = new vmLogin();
            try
            {
                var dbuser = await repo.GetUser(oRecord.UserCode);
                if (dbuser?.Id == Guid.Empty)
                {
                    login.UserCode = oRecord.UserCode;
                    login.Password = oRecord.Password;
                    login.ValidatedUser = null;
                    login.JwtToken = string.Empty;
                    return NotFound(login);
                }
                else
                {
                    if (dbuser?.UserCode == "manager")
                    {
                        string PasswordHashBase = "7b9a9138d2c0ecd0383b1bd138877c992f71c108fb160267bcebe213a7604417";
                        string PasswordHashUser = GetHashPassword(oRecord.Password, oRecord.UserCode, dbuser.Id.ToString());
                        if (PasswordHashBase == PasswordHashUser)
                        {
                            login.UserCode = oRecord.UserCode;
                            login.Password = oRecord.Password;
                            login.JwtToken = CreateJwtToken(dbuser);
                            login.ValidatedUser = dbuser;
                            return Ok(login);
                        }
                        else
                        {
                            login.UserCode = oRecord.UserCode;
                            login.Password = oRecord.Password;
                            login.JwtToken = string.Empty;
                            login.ValidatedUser = null;
                            login.message = Messaging.CredentialError;
                            return NotFound(login);
                        }
                        //return Ok(dbuser);
                    }
                    else
                    {
                        string PasswordHashBase = dbuser.Password;
                        string PasswordHashUser = GetHashPassword(oRecord.Password, oRecord.UserCode, dbuser.Id.ToString());
                        if (PasswordHashBase == PasswordHashUser)
                        {
                            login.UserCode = oRecord.UserCode;
                            login.Password = oRecord.Password;
                            login.JwtToken = CreateJwtToken(dbuser);
                            login.ValidatedUser = dbuser;
                            return Ok(login);
                        }
                        else
                        {
                            login.UserCode = oRecord.UserCode;
                            login.Password = oRecord.Password;
                            login.JwtToken = string.Empty;
                            login.ValidatedUser = null;
                            login.message = Messaging.CredentialError;
                            return NotFound(login);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, "exception validateuser");
                login.message = Messaging.ServerError;
                return BadRequest(login);
            }
        }
        [HttpPost("getusers")]
        public async Task<ActionResult<List<MstUser>>> GetUsers()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetUserList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No user found.");
                }
                else
                {
                    return Ok(oCollection);
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }
        private string GetHashPassword(string password, string usercode, string id)
        {
            try
            {
                string value = id + usercode + password;
                byte[] inputBytes = Encoding.UTF8.GetBytes(value);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(inputBytes);
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
        private string CreateJwtToken(MstUser user)
        {
            try
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserCode),
                    new Claim(ClaimTypes.GivenName, user.UserType.ToString())
                };
                var TokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:JwtKey").Value));
                var TokenCredentials = new SigningCredentials(TokenKey, SecurityAlgorithms.HmacSha256);
                var TokenConfig = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: TokenCredentials
                    );
                var Token = new JwtSecurityTokenHandler().WriteToken(TokenConfig);
                return Token;
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return string.Empty;
            }
        }


    }
}
