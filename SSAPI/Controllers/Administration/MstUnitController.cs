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
    }
}
