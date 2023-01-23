using OpenAi.API.Service;
using OpenAi.API.Service.Services;
using OpenAI.GPT3.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        //services.AddHostedService<Worker>();
        //services.AddHostedService<OpenAICompletionService>();
        services.AddHostedService<OpenAIImageService>();

    })
    .Build();

await host.RunAsync();
