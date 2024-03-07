namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly MstDesignationService repo;
        private readonly ILogger<DesignationController> log;

        public DesignationController(MstDesignationService repo, ILogger<DesignationController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getdesignations")]
        public async Task<ActionResult<List<MstDesignation>>> GetDesignations()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetDesignationList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No designations found.");
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
