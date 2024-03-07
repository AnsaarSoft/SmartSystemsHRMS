namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly MstDepartmentService repo;
        private readonly ILogger<DepartmentController> log;

        public DepartmentController(MstDepartmentService repo, ILogger<DepartmentController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getdepartments")]
        public async Task<ActionResult<List<MstDepartment>>> GetDepartments()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetDepartmentList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No departments found.");
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
