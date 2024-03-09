namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly MstGradeService repo;
        private readonly ILogger<GradeController> log;

        public GradeController(MstGradeService repo, ILogger<GradeController> log)
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
    }
}
