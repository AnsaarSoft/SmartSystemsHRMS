﻿using Server.Repository.Service.Employee;

namespace SSAPI.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpEducationController : ControllerBase
    {
        private readonly MstEmpEducationService repo;
        private readonly ILogger<EmpEducationController> log;

        public EmpEducationController(MstEmpEducationService repo, ILogger<EmpEducationController> log)
        {
            this.repo = repo;
            this.log = log;
        }

        [HttpGet("getempeducations")]
        public async Task<ActionResult<List<MstEmpEducation>>> GetEmpEducation()
        {
            try
            {
                await Task.Delay(1000);
                var oCollection = await repo.GetEmpEducationList();
                if (oCollection.Count == 0)
                {
                    return NotFound("No education found.");
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

        [HttpGet("getempeducation/{Id}")]
        public async Task<ActionResult<MstEmpEducation>> GetEmpEducation(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                var oEntity = await repo.GetEmpEducation(EntityId);

                return (oEntity != null) ? Ok(oEntity) :
                NotFound("Not found.");

            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return BadRequest(Messaging.ServerError);
            }
        }

        [HttpDelete("deleteempeducation/{id}")]
        public async Task<ActionResult> DeleteEmpEducation(string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid EntityId))
                {
                    return BadRequest("Invalid Id.");
                }

                bool result = await repo.DeleteEmpEducation(EntityId);

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
