namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpExperienceController : ControllerBase
    {
        private readonly MstEmpExperienceService repo;
        private readonly ILogger<EmpExperienceController> log;

        public EmpExperienceController(MstEmpExperienceService repo, ILogger<EmpExperienceController> log)
        {
            this.repo = repo;
            this.log = log;
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
    }
}
