using Azure.AI.OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.Text.Json;

namespace Services.FunctionCalling
{
    public class FunctionCalling: IFunctionCalling
    {
        private readonly string _modelEndpoint = "";
        private readonly string _modelName = "gpt-4o";
        private readonly string _apiKey = "";
        private readonly ICustomFunctions _customFunctions;

        public FunctionCalling(ICustomFunctions customFunctions)
        {
            _customFunctions = customFunctions;
        }

        public async Task<string> CallModelWithFunction(string userInput)
        {            
            var endpoint = new Uri(_modelEndpoint);
            ApiKeyCredential credential = new ApiKeyCredential(_apiKey);
            var clientOptions = new AzureOpenAIClientOptions(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21);
            AzureOpenAIClient client = new AzureOpenAIClient(endpoint, credential, clientOptions);

            ChatClient chatClient = client.GetChatClient(_modelName);            

            var messages = new List<ChatMessage>
                {
                    ChatMessage.CreateSystemMessage("You are a helpful assistant"),
                    ChatMessage.CreateUserMessage(userInput)
                };

            var tools = new List<ChatTool>
            {
                ChatTool.CreateFunctionTool(
                    functionName: "GetCurrentWeather",
                    functionDescription: "Gets the current weather for a given location",
                    functionParameters: BinaryData.FromString("""
                    {
                        "type": "object",
                        "properties": {
                            "location": {
                                "type": "string",
                                "description": "The location to get the weather for (e.g., city name, coordinates)"
                            }
                        },
                        "required": ["location"]
                    }
                    """)
                ),
                ChatTool.CreateFunctionTool(
                    functionName: "GetUserDetailById",
                    functionDescription: "Gets user details by user ID from the system",
                    functionParameters: BinaryData.FromString("""
                    {
                        "type": "object",
                        "properties": {
                            "userId": {
                                "type": "integer",
                                "description": "The ID of the user to retrieve details for"
                            }
                        },
                        "required": ["userId"]
                    }
                    """)
                )
            };

            var chatOptions = new ChatCompletionOptions
            {
                Temperature = null
            };

            foreach (var tool in tools)
            {
                chatOptions.Tools.Add(tool);
            }

            var chatCompletion = await chatClient.CompleteChatAsync(messages, chatOptions);

            while (chatCompletion.Value.FinishReason == ChatFinishReason.ToolCalls)
            {
                messages.Add(new AssistantChatMessage(chatCompletion.Value));

                foreach (var toolCall in chatCompletion.Value.ToolCalls)
                {
                    string functionResult = await ExecuteFunction(toolCall.FunctionName, toolCall.FunctionArguments.ToString());
                    messages.Add(new ToolChatMessage(toolCall.Id, functionResult));
                }

                chatCompletion = await chatClient.CompleteChatAsync(messages, chatOptions);
            }

            return chatCompletion.Value.Content[0].Text;
        }

        private async Task<string> ExecuteFunction(string functionName, string functionArguments)
        {
            switch (functionName)
            {
                case "GetCurrentWeather":
                    var weatherArgs = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(functionArguments);
                    var location = weatherArgs["location"].GetString();
                    return await _customFunctions.GetCurrentWeather(location);

                case "GetUserDetailById":
                    var userArgs = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(functionArguments);
                    var userId = userArgs["userId"].GetInt32();
                    return _customFunctions.GetUserDetailById(userId);

                default:
                    return $"Unknown function: {functionName}";
            }
        }

    }
}
