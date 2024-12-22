namespace SSAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfgRoleDetailController : ControllerBase
    {
        private readonly ICfgRoleDetail repo;
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

        [HttpGet("getroledetail/{Id}")]
        public async Task<ActionResult<CfgRoleDetail>> GetRoleDetail(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetRoleDetail(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deleteroledetail/{id}")]
        public async Task<ActionResult> DeleteRoleDetail(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteRoleDetail(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("addroledetail")]
        public async Task<ActionResult> AddCity(CfgRoleDetail InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.AddRoleDetail(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }

        [HttpPost("updateroledetail")]
        public async Task<ActionResult> UpdateCity(CfgRoleDetail InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateRoleDetail(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
