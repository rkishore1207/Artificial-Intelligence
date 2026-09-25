using Microsoft.Extensions.AI;
using OllamaSharp;

namespace FunctionCalling
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await FunctionCalling();
        }

        public static async Task FunctionCalling()
        {
            IChatClient client = new OllamaApiClient(new Uri("http://localhost:11434/"), "llama3.1");

            client = client.AsBuilder().UseFunctionInvocation().Build();

            ChatOptions options = new ChatOptions() { Tools = [AIFunctionFactory.Create(GetWeather)]};

            var response = client.GetStreamingResponseAsync("Should I wear a rain coat?", options);

            await foreach (var item in response)
            {
                Console.Write(item);
            }
        }

        private static string GetWeather()
        {
            return Random.Shared.NextDouble() > 0.5 ? "It's Sunny" : "It's Rainy";
        }
    }
}
