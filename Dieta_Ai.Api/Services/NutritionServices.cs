using Dieta_Ai.Api.Dtos;
using DotnetGeminiSDK.Client.Interfaces;
using DotnetGeminiSDK.Model.Request;
using DotnetGeminiSDK.Model.Response;
using Newtonsoft.Json;

namespace Dieta_Ai.Api.Services
{
    public class NutritionServices
    {
        private readonly IGeminiClient _geminiClient;

        public NutritionServices(IGeminiClient geminiClient)
        {
            _geminiClient = geminiClient;
        }

        public async Task<GeminiMessageResponse?> Example()
        {
            var response = await _geminiClient.TextPrompt("Estou testando a API");
            return response;
        }

        public async Task<NutritionResult?> CreateNutrition(CreateNutritionDto createNutritionDto)
        {
            try
            {
                string prompt = $"Crie uma dieta completa para uma pessoa com nome: ${createNutritionDto.Name} do sexo ${createNutritionDto.Gender} com peso atual: ${createNutritionDto.Weight}kg, altura: ${createNutritionDto.Height}, idade: ${createNutritionDto.Age} anos e com foco e objetivo em ${createNutritionDto.Objective}, atualmente nível de atividade: ${createNutritionDto.Level} e ignore qualquer outro parametro que não seja os passados, retorne em json com as respectivas propriedades, propriedade nome o nome da pessoa, propriedade sexo com sexo, propriedade idade, propriedade altura, propriedade peso, propriedade objetivo com o objetivo atual, propriedade refeições com uma array contendo dentro cada objeto sendo uma refeição da dieta e dentro de cada refeição a propriedade horário com horário da refeição, propriedade nome com nome e a propriedade alimentos com array contendo os alimentos dessa refeição e pode incluir uma propriedade de nome suplementos contendo um array de strings sendo cada index uma sugestão de suplemento que é indicado para o sexo dessa pessoa e o objetivo dela e não retorne nenhuma observação alem das passadas no prompt, retorne em json. Nenhuma propriedade do resultado deve conter acentos!";


                var result = await _geminiClient.TextPrompt(prompt, new GenerationConfig { }) ?? throw new Exception("Algo deu errado, tente novamente mais tarde :(");
                string resultJson = result.Candidates[0].Content.Parts[0].Text.Replace("\\n", "").Replace("`", "").Replace("json", "").Trim();
                Console.WriteLine(resultJson);
                NutritionResult? nutritionResult = JsonConvert.DeserializeObject<NutritionResult>(resultJson);

                return nutritionResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}