namespace Services.VectorEmbeddingAgent
{
    public interface IVectorEmbedding
    {
        Task<string> GetEmbeddingForText(string input);
    }
}
