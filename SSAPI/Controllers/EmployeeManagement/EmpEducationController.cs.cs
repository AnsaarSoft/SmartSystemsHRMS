namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpEducationController : ControllerBase
    {
        private readonly IMstEmpEducation repo;
        private readonly ILogger<EmpEducationController> log;

        public EmpEducationController(IMstEmpEducation repo, ILogger<EmpEducationController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getempeducations")]
        public async Task<ActionResult<List<MstEmpEducation>>> GetEmpEducation()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetEmpEducationList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No education found.");
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

        [HttpGet("getempeducation/{Id}")]
        public async Task<ActionResult<MstEmpEducation>> GetEmpEducation(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetEmpEducation(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deleteempeducation/{id}")]
        public async Task<ActionResult> DeleteEmpEducation(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteEmpEducation(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("addempeducation")]
        public async Task<ActionResult> AddEmpEducation(MstEmpEducation InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            MstEmpEducation employee = new MstEmpEducation()
            {
                InstName = InputData.InstName,
                DegreeName = InputData.DegreeName,
                Employee = InputData.Employee,
                EndDate = InputData.EndDate,
                StartDate = InputData.StartDate,
                flgActive = InputData.flgActive,
            };

            bool result = await repo.AddEmpEducation(employee);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
        [HttpPost("updateempeducation")]
        public async Task<ActionResult> UpdateEmpEducation(MstEmpEducation InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateEmpEducation(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
