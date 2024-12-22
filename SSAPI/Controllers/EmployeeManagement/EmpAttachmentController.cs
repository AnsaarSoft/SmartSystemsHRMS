namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAttachmentController : ControllerBase
    {
        private readonly IMstEmpAttachment repo;
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
        [HttpPost("addempempattachment")]
        public async Task<ActionResult> Addempattachment(MstEmpAttachment InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            MstEmpAttachment employee = new MstEmpAttachment()
            {
                FilePath = InputData.FilePath,
                FileName = InputData.FileName,
                Employee = InputData.Employee,
                Remarks = InputData.Remarks,
                flgActive = InputData.flgActive,
            };

            bool result = await repo.AddEmpAttachment(employee);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
        [HttpPost("updateempempattachment")]
        public async Task<ActionResult> Updateempattachment(MstEmpAttachment InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateEmpAttachment(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
