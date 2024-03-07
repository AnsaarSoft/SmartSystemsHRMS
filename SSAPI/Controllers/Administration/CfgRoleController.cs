namespace SSAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfgRoleController : ControllerBase
    {
        private readonly CfgRoleService repo;
        private readonly ILogger<CfgRoleController> log;

        public CfgRoleController(CfgRoleService repo, ILogger<CfgRoleController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getroles")]
        public async Task<ActionResult<List<CfgRole>>> GetRoles()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetRoleList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No roles found.");
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
