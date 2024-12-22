namespace SSAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfgRoleController : ControllerBase
    {
        private readonly ICfgRole repo;
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

        [HttpGet("getrole/{Id}")]
        public async Task<ActionResult<CfgRole>> GetRole(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetRole(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deleterole/{id}")]
        public async Task<ActionResult> DeleteRole(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteRole(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("addrole")]
        public async Task<ActionResult> AddCity(CfgRole InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.AddRole(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }

        [HttpPost("updaterole")]
        public async Task<ActionResult> UpdateCity(CfgRole InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateRole(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
