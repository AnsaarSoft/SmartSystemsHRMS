using Server.Repository.Service.Employee;

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
    }
}
