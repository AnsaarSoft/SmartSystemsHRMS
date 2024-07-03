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

        [HttpGet("getcity/{Id}")]
        public async Task<ActionResult<MstCity>> GetCity(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetCity(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletecity/{id}")]
        public async Task<ActionResult> DeleteCity(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteCity(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("Add-City")]
        public async Task<ActionResult> AddCity(MstCity InputData)
        {
            if (InputData == null)
                return BadRequest();

            bool result = await repo.AddCity(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
