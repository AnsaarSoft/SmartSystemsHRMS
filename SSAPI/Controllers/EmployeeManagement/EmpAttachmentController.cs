namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAttachmentController : ControllerBase
    {
        private readonly MstEmpAttachmentService repo;
        private readonly ILogger<EmpAttachmentController> log;

        public EmpAttachmentController(MstEmpAttachmentService repo, ILogger<EmpAttachmentController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getempattachments")]
        public async Task<ActionResult<List<MstEmpAttachment>>> GetEmpAttachments()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetEmpAttachmentList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No attachments found.");
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

        [HttpGet("getempattachment/{Id}")]
        public async Task<ActionResult<MstEmpAttachment>> GetEmpAttachment(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetEmpAttachment(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deleteempattachment/{id}")]
        public async Task<ActionResult> DeleteEmpExperience(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteEmpAttachment(EntityId);

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
