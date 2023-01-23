using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;

namespace OpenAi.API.Service.Services
{
    public class OpenAIImageService : BackgroundService
    {
        readonly IOpenAIService _openAIService;

        public OpenAIImageService(IOpenAIService openAiService)
        {
            _openAIService = openAiService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (true)
            {
                Console.WriteLine("Hi!");
                ImageCreateResponse result = await _openAIService.Image.CreateImage(new ImageCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    N = 2,
                    Size = StaticValues.ImageStatics.Size.Size256,
                    ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                    User = "test"
                });

                Console.WriteLine(string.Join("\n", result.Results.Select(r => r.Url)));
            }
        }
    }
}
