namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IMstDesignation repo;
        private readonly ILogger<DesignationController> log;

        public DesignationController(IMstDesignation repo, ILogger<DesignationController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getdesignations")]
        public async Task<ActionResult<List<MstDesignation>>> GetDesignations()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetDesignationList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No designations found.");
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

        [HttpGet("getdesignation/{Id}")]
        public async Task<ActionResult<MstDesignation>> GetDesignation(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetDesignation(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletedesignation/{id}")]
        public async Task<ActionResult> DeleteDesignation(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteDesignation(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("adddesignation")]
        public async Task<ActionResult> AddDesignation(MstDesignation InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.AddDesignation(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }

        [HttpPost("updatedesignation")]
        public async Task<ActionResult> UpdateDesignation(MstDesignation InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateDesignation(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
