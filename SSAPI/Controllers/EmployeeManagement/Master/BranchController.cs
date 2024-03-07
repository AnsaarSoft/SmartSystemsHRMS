namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly MstBranchService repo;
        private readonly ILogger<BranchController> log;

        public BranchController(MstBranchService repo, ILogger<BranchController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getbranches")]
        public async Task<ActionResult<List<MstBranch>>> GetBranches()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetBranchList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No branch found.");
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
