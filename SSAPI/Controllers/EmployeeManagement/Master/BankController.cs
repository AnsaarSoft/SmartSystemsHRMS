namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly MstBankService repo;
        private readonly ILogger<BankController> log;

        public BankController(MstBankService repo, ILogger<BankController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getbanks")]
        public async Task<ActionResult<List<MstBank>>> GetBanks()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetBankList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No bank found.");
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
