using Services.FunctionCalling.Models;
using System.Text.Json;

namespace Services.FunctionCalling
{
    public class CustomFunctions : ICustomFunctions
    {
        public CustomFunctions()
        {

        }

        /// <summary>
        /// Gets the current weather for a given location.
        /// </summary>
        /// <param name="location">The location to get the weather for (e.g., city name, coordinates)</param>
        /// <returns>A description of the current weather conditions</returns>
        public async Task<string> GetCurrentWeather(string location)
        {
            try
            {
                var url = "http://api.openweathermap.org/geo/1.0/direct?q=" + location + "&limit=1&appid=903aaa4638047cf4e7c162fb9cd8010f";
                var content = await SendHttpRequest(url);

                var locationData = JsonSerializer.Deserialize<List<Location>>(content)?.FirstOrDefault();

                var latLongUrl = "https://api.openweathermap.org/data/2.5/weather?lat=" + locationData?.Latitude + "&lon=" + locationData?.Longitude + "&appid=903aaa4638047cf4e7c162fb9cd8010f";
                var weatherContent = await SendHttpRequest(latLongUrl);

                var weatherData = JsonSerializer.Deserialize<WeatherDetails>(weatherContent);

                return weatherData.Weather.FirstOrDefault()?.Description ?? "No weather data available";
            }
            catch (Exception ex)
            {
                return "Error fetching weather data: " + ex.Message;
            }
        }

        /// <summary>
        /// Gets user details by user ID from the system.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve details for</param>
        /// <returns>User details including name, email, and contact number in JSON format</returns>
        public string GetUserDetailById(int userId)
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", ContactNumber = "+1-555-0101" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", ContactNumber = "+1-555-0102" },
                new User { Id = 3, Name = "Bob Johnson", Email = "bob.johnson@example.com", ContactNumber = "+1-555-0103" },
                new User { Id = 4, Name = "Alice Williams", Email = "alice.williams@example.com", ContactNumber = "+1-555-0104" },
                new User { Id = 5, Name = "Charlie Brown", Email = "charlie.brown@example.com", ContactNumber = "+1-555-0105" }
            };

            var user = users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return $"User with ID {userId} not found";

            return JsonSerializer.Serialize(user);
        }

        private async Task<string> SendHttpRequest(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to get weather data: " + content);

            return content;
        }         
    }
}
