using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Infra.IRepositories.ILovType;

namespace EmployeeSystem.Application.Controllers.MasterData
{
    [Authorize]
    [Route("master-data/lov")]
    [ApiController]
    public class LovTypeController : ControllerBase
    {

        private readonly ILovTypeRepository _LovTypeRepository;
        public LovTypeController(ILovTypeRepository LovTypeRepository)
        {
            _LovTypeRepository = LovTypeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string lovCode)
        {
            var result = await _LovTypeRepository.GetLovTypeByCode(lovCode);
            var response = new ApiResponseModel
            {
                Status = true,
                Data = result
            };

            return Ok(response);
        }
        [HttpGet]
        [Route("get-studdent-attachment-By-lovcode")]
        public async Task<IActionResult> GetStuddentLovByLovCode(string lovCode)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _LovTypeRepository.GetStuddentLovByLovCode(lovCode),
                Message = StaticVariables.RecordFounded
            });
        }
    }
}
