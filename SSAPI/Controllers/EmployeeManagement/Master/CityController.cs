namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly MstCityService repo;
        private readonly ILogger<CityController> log;

        public CityController(MstCityService repo, ILogger<CityController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getcities")]
        public async Task<ActionResult<List<MstCity>>> GetCities()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetCityList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No city found.");
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
