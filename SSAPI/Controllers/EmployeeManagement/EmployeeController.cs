namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMstEmployee repo;
        private readonly ILogger<EmployeeController> log;

        public EmployeeController(IMstEmployee repo, ILogger<EmployeeController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getemployees")]
        public async Task<ActionResult<List<MstEmployee>>> GetEmployees()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetEmployeeList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No attachments found.");
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

        [HttpGet("getemployee/{Id}")]
        public async Task<ActionResult<MstEmployee>> GetEmployee(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetEmployee(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deleteemployee/{id}")]
        public async Task<ActionResult> DeleteEmpExperience(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteEmployee(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }
        [HttpPost("addEmployee")]
        public async Task<ActionResult> AddEmployee(MstEmployee InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            MstEmployee employee = new MstEmployee()
            {
                FirstName = InputData.FirstName,
                LastName = InputData.LastName,
                MiddleName = InputData.MiddleName,
                flgActive = InputData.flgActive,

                HomeAddress = InputData.HomeAddress,
                HomeEmail = InputData.HomeEmail,
                HomeCity = InputData.HomeCity,
                HomePhoneNumber = InputData.HomePhoneNumber,
                HomeCountry = InputData.HomeCountry,

                WorkAddress = InputData.WorkAddress,
                WorkEmail = InputData.WorkEmail,
                WorkCity = InputData.WorkCity,
                WorkPhoneNumber = InputData.WorkPhoneNumber,
                WorkCountry = InputData.WorkCountry,

                MotherName = InputData.MotherName,
                FatherName = InputData.FatherName,
                DOB = InputData.DOB,
                ConfirmationDate = InputData.ConfirmationDate,
                ServiceStartDate = InputData.ServiceStartDate,
                ServiceEndDate = InputData.ServiceEndDate,

                Title = InputData.Title,
                EmployeeID = InputData.EmployeeID,
            };

            bool result = await repo.AddEmployee(employee);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
        [HttpPost("updateEmployee")]
        public async Task<ActionResult> UpdateEmployee(MstEmployee InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateEmployee(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
