namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly MstLocationService repo;
        private readonly ILogger<LocationController> log;

        public LocationController(MstLocationService repo, ILogger<LocationController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getlocations")]
        public async Task<ActionResult<List<MstLocation>>> GetLocations()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetLocationList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No locations found.");
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
