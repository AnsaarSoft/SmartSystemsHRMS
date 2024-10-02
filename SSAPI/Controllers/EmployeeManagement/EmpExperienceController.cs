namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpExperienceController : ControllerBase
    {
        private readonly IMstEmpExperience repo;
        private readonly IMstEmployee employee_repo;
        private readonly ILogger<EmpExperienceController> log;

        public EmpExperienceController(IMstEmpExperience repo, ILogger<EmpExperienceController> log, IMstEmployee employee)
        {
            this.repo = repo;
            this.log = log;
            this.employee_repo = employee;
        }

        [HttpGet("getempexperiences")]
        public async Task<ActionResult<List<MstEmpExperience>>> GetEmpExperiences()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetEmpExperienceList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No experiences found.");
                }
                else
                {
                    //foreach (var employee in oCollection)
                    //{
                    //    employee.Employee = await employee_repo.GetEmployee(employee.Employee.Id);
                    //}

                    return Ok(oCollection);
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpGet("getempexperience/{Id}")]
        public async Task<ActionResult<MstEmpExperience>> GetEmpExperience(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetEmpExperience(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deleteempexperience/{id}")]
        public async Task<ActionResult> DeleteEmpExperience(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteEmpExperience(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }
        [HttpPost("addempexperience")]
        public async Task<ActionResult> AddEmpExperience(MstEmpExperience InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            MstEmpExperience employee = new MstEmpExperience()
            {
                OrgName = InputData.OrgName,
                Employee = InputData.Employee,
                EndDate = InputData.EndDate,
                StartDate = InputData.StartDate,

                flgActive = InputData.flgActive,
            };

            bool result = await repo.AddEmpExperience(employee);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
        [HttpPost("updateempexperience")]
        public async Task<ActionResult> UpdateEmpExperience(MstEmpExperience InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateEmpExperience(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
