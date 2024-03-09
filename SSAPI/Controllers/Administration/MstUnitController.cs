namespace SSAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class MstUnitController : ControllerBase
    {
        private readonly MstUnitService repo;
        private readonly ILogger<MstUnitController> log;

        public MstUnitController(MstUnitService repo, ILogger<MstUnitController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getunits")]
        public async Task<ActionResult<List<MstUnit>>> GetUnits()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetUnitList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No units found.");
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

        [HttpGet("getunit/{Id}")]
        public async Task<ActionResult<MstUnit>> GetUnit(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetUnit(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deleteunit/{id}")]
        public async Task<ActionResult> DeleteUnit(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteUnit(EntityId);

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
