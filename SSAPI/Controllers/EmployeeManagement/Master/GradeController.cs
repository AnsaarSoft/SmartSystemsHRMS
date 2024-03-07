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
    }
}
