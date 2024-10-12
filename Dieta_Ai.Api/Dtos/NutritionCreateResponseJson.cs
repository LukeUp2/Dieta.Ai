using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dieta_Ai.Api.Dtos
{
    public class NutritionCreateResponseJson
    {
        public required NutritionResult Data { get; set; }
    }
}