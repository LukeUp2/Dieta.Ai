

namespace Dieta_Ai.Api.Dtos
{
    public class CreateNutritionDto
    {
        public required string Name { get; set; }
        public required string Weight { get; set; }
        public required string Height { get; set; }
        public required string Age { get; set; }
        public required string Gender { get; set; }
        public required string Objective { get; set; }
        public required string Level { get; set; }

    }
}