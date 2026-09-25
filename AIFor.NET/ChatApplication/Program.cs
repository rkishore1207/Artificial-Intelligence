using Microsoft.Extensions.AI;
using OllamaSharp;

namespace ChatApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await ChatApplication();
        }

        private static async Task ChatApplication()
        {
            IChatClient client = new OllamaApiClient(new Uri("http://localhost:11434/"), "phi3:mini");
            var response = await client.GetResponseAsync("Which programming language is great. Java or .NET");
            Console.WriteLine(response.Text);
        }
    }
}
