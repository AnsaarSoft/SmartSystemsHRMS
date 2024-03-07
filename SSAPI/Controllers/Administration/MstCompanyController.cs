namespace SSAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class MstCompanyController : ControllerBase
    {
        private readonly MstCompanyService repo;
        private readonly ILogger<MstCompanyController> log;

        public MstCompanyController(MstCompanyService repo, ILogger<MstCompanyController> log)
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
    }
}
