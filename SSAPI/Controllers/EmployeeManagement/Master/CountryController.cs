﻿namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly MstCountryService repo;
        private readonly ILogger<CountryController> log;

        public CountryController(MstCountryService repo, ILogger<CountryController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getcountries")]
        public async Task<ActionResult<List<MstCountry>>> GetCountries()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetCountryList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No country found.");
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

        [HttpGet("getcountry/{Id}")]
        public async Task<ActionResult<MstCountry>> GetCountry(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetCountry(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletecountry/{id}")]
        public async Task<ActionResult> DeleteCountry(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteCountry(EntityId);

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
