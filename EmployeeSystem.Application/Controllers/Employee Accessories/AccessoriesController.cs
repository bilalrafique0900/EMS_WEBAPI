using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.IIAceessriesRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Application.Controllers.Employee_Accessories
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoriesController : ControllerBase
    {
        private readonly IAceessriesRepository _aceessries;

        public AccessoriesController(IAceessriesRepository aceessries)
        {
            _aceessries = aceessries;
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] Accessories obj)
        {
            if (obj == null) return BadRequest("Accessory data is required");

            obj.AccessoriesId = Guid.NewGuid();

            var result = await _aceessries.Create(obj);
            if (result) return Ok("Accessory created successfully");
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create accessory");
        }
        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] Accessories obj)
        {
            if (obj == null) return BadRequest("Accessory data is required");

            var result = await _aceessries.Update(obj);
            if (result) return Ok("Accessory updated successfully");
            return NotFound("Accessory not found");
        }

        [HttpPut("Active/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Active(Guid id)
        {
            var result = await _aceessries.Active(id);
            if (result) return Ok("Accessory activated successfully");
            return NotFound("Accessory not found");
        }
        [HttpDelete("Delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _aceessries.Delete(id);
            if (result) return Ok("Accessory deleted successfully");
            return NotFound("Accessory not found");
        }

        [HttpGet("GetAllAccessories")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAccessories()
        {
            var accessories = await _aceessries.GetAllAccessories();
            if (accessories == null || !accessories.Any()) return NotFound("No accessories found");

            return Ok(accessories);
        }


        [HttpPut("UpdateMultiple")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateMultiple([FromBody] List<Accessories> accessoriesList)
        {
            if (accessoriesList == null || !accessoriesList.Any())
                return BadRequest("Accessory data is required");

            try
            {
                var result = await _aceessries.UpdateMultiple(accessoriesList);
                if (result)
                    return Ok("Accessories updated successfully");
                return StatusCode(StatusCodes.Status304NotModified, "No item is updated");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception: {ex.Message}");
            }
        }


        }
}
