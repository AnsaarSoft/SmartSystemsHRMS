namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly MstListService repo;
        private readonly ILogger<ListController> log;

        public ListController(MstListService repo, ILogger<ListController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getlists")]
        public async Task<ActionResult<List<MstList>>> GetLists()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetListList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No lists found.");
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

        [HttpGet("getlist/{Id}")]
        public async Task<ActionResult<MstList>> GetList(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetList(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletelist/{id}")]
        public async Task<ActionResult> DeleteList(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteList(EntityId);

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
