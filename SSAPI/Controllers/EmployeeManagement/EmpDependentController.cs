namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDependentController : ControllerBase
    {
        private readonly MstEmpDependentService repo;
        private readonly ILogger<EmpDependentController> log;

        public EmpDependentController(MstEmpDependentService repo, ILogger<EmpDependentController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getempdependents")]
        public async Task<ActionResult<List<MstEmpDependent>>> GetEmpDependents()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetEmpDependentList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No dependents found.");
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

        [HttpGet("getempdependent/{Id}")]
        public async Task<ActionResult<MstEmpDependent>> GetEmpDependent(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetEmpDependent(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deleteempdependent/{id}")]
        public async Task<ActionResult> DeleteEmpDependent(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteEmpDependent(EntityId);

                return result ? Ok("Deleted successfully.") :
                    BadRequest("Failed to delete.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpPost("addempeducation")]
        public async Task<ActionResult> AddEmpDependent(MstEmpDependent InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            MstEmpDependent employee = new MstEmpDependent()
            {
                Name = InputData.Name,
                DOB = InputData.DOB,
                Employee = InputData.Employee,
                NationalCardNo = InputData.NationalCardNo,
                Relation = InputData.Relation,
                flgActive = InputData.flgActive,
            };

            bool result = await repo.AddEmpDependent(employee);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
        [HttpPost("updateempeducation")]
        public async Task<ActionResult> UpdateEmpDependent(MstEmpDependent InputData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await repo.UpdateEmpDependent(InputData);

            return result ? Ok("Added successfully.") :
                     BadRequest("Failed to Add.");
        }
    }
}
