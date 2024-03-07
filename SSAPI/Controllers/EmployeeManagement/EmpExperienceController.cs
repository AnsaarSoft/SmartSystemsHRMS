using Server.Repository.Service.Employee;

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
    }
}
