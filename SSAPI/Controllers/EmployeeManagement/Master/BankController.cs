namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IMstBank repo;
        private readonly ILogger<BankController> log;

        public BankController(IMstBank repo, ILogger<BankController> log)
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

        [HttpGet("getbank/{Id}")]
        public async Task<ActionResult<MstBank>> GetBank(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetBank(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletebank/{id}")]
        public async Task<ActionResult> DeleteBank(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteBank(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("addbank")]
        public async Task<ActionResult> AddBank(MstBank InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            MstBank bank = new MstBank()
            {
                Title = InputData.Title,
                flgActive = InputData.flgActive,
                Company = InputData.Company,
                Unit = InputData.Unit
            };

            bool result = await repo.AddBank(bank);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }

        [HttpPost("updatebank")]
        public async Task<ActionResult> UpdateBank(MstBank InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateBank(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
