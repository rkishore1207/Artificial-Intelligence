namespace Services.FunctionCalling
{
    public interface ICustomFunctions
    {
        Task<string> GetCurrentWeather(string location);
        string GetUserDetailById(int userId);
    }
}
