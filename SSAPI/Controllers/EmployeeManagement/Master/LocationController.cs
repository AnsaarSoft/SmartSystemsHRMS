﻿namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMstLocation repo;
        private readonly ILogger<LocationController> log;

        public LocationController(IMstLocation repo, ILogger<LocationController> log)
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

        [HttpGet("getlocation/{Id}")]
        public async Task<ActionResult<MstLocation>> Getlocation(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetLocation(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletelocation/{id}")]
        public async Task<ActionResult> DeleteLocation(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteLocation(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("addlocation")]
        public async Task<ActionResult> AddLocation(MstLocation InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.AddLocation(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }

        [HttpPost("updatelocation")]
        public async Task<ActionResult> UpdateLocation(MstLocation InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateLocation(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
