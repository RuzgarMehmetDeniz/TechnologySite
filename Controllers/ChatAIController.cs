using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TechnologySite.Controllers
{
    public class ChatAIController : Controller
    {
        [HttpGet]
        public IActionResult SendChatWithAI()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendChatWithAI([FromBody] ChatRequest request)
        {
            string userInput = request.UserInput;

            if (string.IsNullOrWhiteSpace(userInput))
                return Json(new { answer = "Lütfen bir soru girin." });

            // API Key
            string apiKey = "";// Buraya OpenAI API anahtarınızı ekleyin
                return Json(new { answer = "API Key bulunamadı!" });

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
            new { role = "user", content = userInput }
        },
                max_tokens = 150
            };

            var json = JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var response = await client.PostAsync(
                "https://api.openai.com/v1/chat/completions", content);

            var responseContent = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(responseContent);

            string answer = "AI’den cevap gelmedi.";

            if (doc.RootElement.TryGetProperty("choices", out var choices) &&
                choices.GetArrayLength() > 0)
            {
                var firstChoice = choices[0];
                if (firstChoice.TryGetProperty("message", out var message) &&
                    message.TryGetProperty("content", out var contentProp))
                {
                    answer = contentProp.GetString();
                }
            }

            return Json(new { answer });
        }

        public class ChatRequest
        {
            public string UserInput { get; set; }
        }

    }
}
