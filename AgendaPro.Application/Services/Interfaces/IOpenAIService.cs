namespace AgendaPro.Application.Services.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GetChatGPTResponse(string pergunta);
    }
}
