using Server.Repository.Service.Employee;

namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpEducationController : ControllerBase
    {
        private readonly MstEmpEducationService repo;
        private readonly ILogger<EmpEducationController> log;

        public EmpEducationController(MstEmpEducationService repo, ILogger<EmpEducationController> log)
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
    }
}
