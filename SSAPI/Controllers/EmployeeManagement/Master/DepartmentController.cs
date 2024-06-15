namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMstDepartment repo;
        private readonly ILogger<DepartmentController> log;

        public DepartmentController(IMstDepartment repo, ILogger<DepartmentController> log)
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

        [HttpGet("getdepartment/{Id}")]
        public async Task<ActionResult<MstDepartment>> GetDepartment(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetDepartment(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletedepartment/{id}")]
        public async Task<ActionResult> DeleteDepartment(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteDepartment(EntityId);

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
