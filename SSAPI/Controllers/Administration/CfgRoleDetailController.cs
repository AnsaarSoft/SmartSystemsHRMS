namespace SSAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfgRoleDetailController : ControllerBase
    {
        private readonly CfgRoleDetailService repo;
        private readonly ILogger<CfgRoleDetailController> log;

        public CfgRoleDetailController(CfgRoleDetailService repo, ILogger<CfgRoleDetailController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getroledetails")]
        public async Task<ActionResult<List<CfgRoleDetail>>> GetRoleDetails()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetRoleDetailList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No role details found.");
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
