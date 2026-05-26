namespace Services.FunctionCalling
{
    public interface IFunctionCalling
    {
        Task<string> CallModelWithFunction(string userInput);
    }
}
