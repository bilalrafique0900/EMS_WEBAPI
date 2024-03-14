using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Infra.IRepositories.IContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Application.Controllers.Contract
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IContractRepository _contactRepository;
        

        public ContractController(IConfiguration configuration, IContractRepository contactRepository)
        {
            _configuration = configuration;
            _contactRepository = contactRepository;
        }

        [Route("getcontact")]
        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> getContract(string Language, Guid StudentId)
        {
            try
            {
                string ContactFile="En";
                if (Language == "En")
                {
                    ContactFile = _configuration["Contracts:EnglishContact"];
                }else if (Language == "Ar")
                {
                    ContactFile = _configuration["Contracts:ArabicContact"];
                }
                else if (Language == "Kd")
                {
                    ContactFile = _configuration["Contracts:KurdishContract"];
                }

                
                return Ok(new ApiResponseModel
                {
                    Status = true,
                    Data = await _contactRepository.GetStudentContract(ContactFile, StudentId),
                    Message = StaticVariables.RecordFounded
                });
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        
    }
}
