namespace SSAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfgMenuController : ControllerBase
    {
        private readonly ICfgMenu repo;
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

        [HttpGet("getmenu/{Id}")]
        public async Task<ActionResult<CfgMenu>> GetMenu(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetMenu(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletemenul/{id}")]
        public async Task<ActionResult> DeleteMenu(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteMenu(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("addmenu")]
        public async Task<ActionResult> AddCity(CfgMenu InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.AddMenu(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }

        [HttpPost("updatemenu")]
        public async Task<ActionResult> UpdateCity(CfgMenu InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateMenu(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
