namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IMstGrade repo;
        private readonly ILogger<GradeController> log;

        public GradeController(IMstGrade repo, ILogger<GradeController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getgrades")]
        public async Task<ActionResult<List<MstGrade>>> GetGrades()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetGradeList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No grades found.");
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

        [HttpGet("getgrade/{Id}")]
        public async Task<ActionResult<MstGrade>> GetGrade(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetGrade(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletegrade/{id}")]
        public async Task<ActionResult> DeleteGrade(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteGrade(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("addgrade")]
        public async Task<ActionResult> AddGrade(MstGrade InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.AddGrade(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }

        [HttpPost("updategrade")]
        public async Task<ActionResult> UpdateGrade(MstGrade InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateGrade(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
