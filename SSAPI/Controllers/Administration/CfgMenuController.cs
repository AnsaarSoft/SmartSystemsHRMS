namespace SSAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfgMenuController : ControllerBase
    {
        private readonly CfgMenuService repo;
        private readonly ILogger<CfgMenuController> log;

        public CfgMenuController(CfgMenuService repo, ILogger<CfgMenuController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getmenus")]
        public async Task<ActionResult<List<CfgMenu>>> GetMenus()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetMenuList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No menu found.");
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
