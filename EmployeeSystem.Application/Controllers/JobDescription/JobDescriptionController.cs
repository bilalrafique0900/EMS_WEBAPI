using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Infra.IRepositories.IJobDescription;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace EmployeeSystem.Application.Controllers.JobDescription
{
    [Authorize]
    [Route("job-description")]
    [ApiController]
    public class JobDescriptionController : ControllerBase
    {

        private readonly IJobDescriptionRepository _jobdescriptionRepository;
        public JobDescriptionController(IJobDescriptionRepository jobdescriptionRepository)
        {
            _jobdescriptionRepository = jobdescriptionRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdate(JobDescriptionDto obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobdescriptionRepository.CreateUpdate1(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobdescriptionRepository.GetAllJobs(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("jobdescription-list")]
        public async Task<IActionResult> GetJobDescriptions(int pageNo, int pageSize, string searchText = "")
        {
            return Ok(await _jobdescriptionRepository.GetAllJobDescriptions(pageNo, pageSize, searchText));

        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobdescriptionRepository.Delete(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("active/{id}")]
        public async Task<IActionResult> Active(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobdescriptionRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("approve/{id}")]
        public async Task<IActionResult> Approve(Guid id)
        {
            var ApprovedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobdescriptionRepository.Approve(id,ApprovedBy),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("publish/{id}")]
        public async Task<IActionResult> Publish(Guid id)
        {
            var PublishedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobdescriptionRepository.Publish(id,PublishedBy),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
