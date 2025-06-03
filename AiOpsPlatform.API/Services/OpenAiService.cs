using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace AiOpsPlatform.API.Services
{
    public class OpenAiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public OpenAiService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> GenerateSummaryAsync(string input)
        {

            // Simulated response
            await Task.Delay(200); // simulate API call delay
            return $"Summary: {input.Substring(0, Math.Min(input.Length, 50))}...";



            // var body = new
            // {
            //     model = "gpt-4",
            //     messages = new[]
            //     {
            //         new { role = "system", content = "Summarize this construction jobsite note clearly." },
            //         new { role = "user", content = input }
            //     }
            // };

            // var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            // request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _config["OpenAI:ApiKey"]);
            // request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            // var response = await _httpClient.SendAsync(request);
            // var json = await response.Content.ReadAsStringAsync();
            // dynamic result = JsonConvert.DeserializeObject(json);

            // return result.choices[0].message.content.ToString();
        }
    }
}
