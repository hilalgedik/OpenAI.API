using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace OpenAi.API.Service.Services
{
    public class OpenAICompletionService : BackgroundService
    {
        private readonly IOpenAIService _openAiService;

        public OpenAICompletionService(IOpenAIService openAiService)
        {
            _openAiService = openAiService;
        }

        protected  override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.WriteLine("Hi!");
              CompletionCreateResponse result = await _openAiService.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    MaxTokens = 500
                }, Models.TextDavinciV3);
                Console.WriteLine(result.Choices[0].Text);
            }
        }
    }
}
