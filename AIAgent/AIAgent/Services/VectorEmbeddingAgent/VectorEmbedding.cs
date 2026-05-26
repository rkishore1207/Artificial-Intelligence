using Azure;
using Azure.AI.OpenAI;

namespace Services.VectorEmbeddingAgent
{
    public class VectorEmbedding: IVectorEmbedding
    {
        private readonly string _embeddingEndpoint = "";
        private readonly string _apiKey = "";
        private readonly string _textEmbeddingModel = "text-embedding-ada-002";

        public VectorEmbedding()
        {

        }

        public async Task<string> GetEmbeddingForText(string input)
        {
            var client = new AzureOpenAIClient(new Uri(_embeddingEndpoint), new AzureKeyCredential(_apiKey));
            var embeddingClient = client.GetEmbeddingClient(_textEmbeddingModel);

            var response = await embeddingClient.GenerateEmbeddingAsync(input);

            var embeddings = response.Value.ToFloats();

            return string.Join(", ", embeddings.ToArray());
        }
    }
}
