using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dieta_Ai.Api.Dtos
{
    public class NutritionResult
    {
        public required string Nome { get; set; }
        public required string Sexo { get; set; }
        public int Idade { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public required string Objetivo { get; set; }
        public required List<Refeicao> Refeicoes { get; set; }
        public required List<string> Suplementos { get; set; }
    }
    public class Refeicao
    {
        public required string Horario { get; set; }
        public required string Nome { get; set; }
        public required List<string> Alimentos { get; set; }
    }
}