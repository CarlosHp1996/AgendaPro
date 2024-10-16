using AgendaPro.Application.Services.Interfaces;
using System.Net.Http.Json;

namespace AgendaPro.Application.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly string _apiKey;
        private static readonly HttpClient client = new HttpClient(); // HttpClient deve ser singleton

        public OpenAIService(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public async Task<string> GetChatGPTResponse(string pergunta)
        {
            // Configuração do cabeçalho de autorização
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var requestContent = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = pergunta }
                }
            };

            // Retry com exponencial backoff
            int retryCount = 0;
            int maxRetries = 5;
            int delay = 1000; // 1 segundo

            while (retryCount < maxRetries)
            {
                try
                {
                    var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestContent);

                    // Verifica se a resposta foi bem-sucedida
                    response.EnsureSuccessStatusCode();

                    // Lê o conteúdo da resposta
                    var responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
                catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    // Exibe aviso e aguarda
                    retryCount++;
                    Console.WriteLine($"Limite de requisições excedido (429). Tentativa {retryCount} de {maxRetries}. Aguardando {delay}ms...");
                    await Task.Delay(delay);

                    // Exponencial backoff - dobra o tempo de espera a cada retry
                    delay *= 2;
                }
                catch (Exception ex)
                {
                    // Outras exceções
                    throw new Exception($"Erro ao chamar a API do OpenAI: {ex.Message}");
                }
            }

            throw new Exception("Número máximo de tentativas de chamadas à API do OpenAI excedido.");
        }
    }
}
