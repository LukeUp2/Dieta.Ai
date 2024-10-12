using Dieta_Ai.Api.Dtos;
using Dieta_Ai.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dieta_Ai.Api.Controllers
{
    [ApiController]
    [Route("api/nutrition-ia")]
    public class NutritionController : ControllerBase
    {
        private readonly NutritionServices _nutritionService;

        public NutritionController(NutritionServices nutritionService)
        {
            _nutritionService = nutritionService;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var result = await _nutritionService.Example();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNutrition([FromBody] CreateNutritionDto createNutritionDto)
        {
            try
            {
                var result = await _nutritionService.CreateNutrition(createNutritionDto);
                if (result == null)
                {
                    return BadRequest("Algo deu errado");
                }
                var response = new NutritionCreateResponseJson
                {
                    Data = result
                };
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}