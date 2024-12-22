namespace SSAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class MstCompanyController : ControllerBase
    {
        private readonly IMstCompany repo;
        private readonly ILogger<MstCompanyController> log;

        public MstCompanyController(IMstCompany repo, ILogger<MstCompanyController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getcompanies")]
        public async Task<ActionResult<List<MstCompany>>> GetCompanies()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetCompanyList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No company found.");
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

        [HttpGet("getcompany/{Id}")]
        public async Task<ActionResult<MstCompany>> GetCompany(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetCompany(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletecompany/{id}")]
        public async Task<ActionResult> DeleteCompany(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteCompany(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("addcompany")]
        public async Task<ActionResult> AddCompany(MstCompany InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.AddCompany(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }

        [HttpPost("updatecompany")]
        public async Task<ActionResult> UpdateCompany(MstCompany InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateCompany(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
