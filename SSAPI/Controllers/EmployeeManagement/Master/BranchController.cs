﻿namespace SSAPI.Controllers.EmployeeManagement.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMstBranch repo;
        private readonly ILogger<BranchController> log;

        public BranchController(IMstBranch repo, ILogger<BranchController> log)
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

        [HttpGet("getbranch/{Id}")]
        public async Task<ActionResult<MstBranch>> GetBranch(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetBranch(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deletebranch/{id}")]
        public async Task<ActionResult> DeleteBranch(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteBranch(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }
        [HttpPost("addbranch")]
        public async Task<ActionResult> AddBranch(MstBranch InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.AddBranch(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }

        [HttpPost("updatebranch")]
        public async Task<ActionResult> UpdateBranch(MstBranch InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateBranch(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
