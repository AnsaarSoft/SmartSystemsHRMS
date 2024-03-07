namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankBranchController : ControllerBase
    {
        private readonly MstBankBranchService repo;
        private readonly ILogger<BankBranchController> log;

        public BankBranchController(MstBankBranchService repo, ILogger<BankBranchController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getbankbranches")]
        public async Task<ActionResult<List<MstCity>>> GetBankBranches()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetBankBranchList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No bank branch found.");
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

        [HttpGet("getbankbranch/{Id}")]
        public async Task<ActionResult<MstBankBranch>> GetBankBranch(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetBankBranch(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletebankbranch/{id}")]
        public async Task<ActionResult> DeleteBankBranch(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteBankBranch(EntityId);

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
