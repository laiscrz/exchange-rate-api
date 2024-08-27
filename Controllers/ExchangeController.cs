using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace exchange_rate_api.Controllers
{
    /// <summary>
    /// Controlador responsavel por gerenciar api cambio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ExchangeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Obtém a taxa de câmbio atual para USD.
        /// </summary>
        /// <returns>Taxa de câmbio em formato JSON.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a taxa de câmbio mais recente.", Description = "Retorna a taxa de câmbio do USD para outras moedas.")]
        public async Task<IActionResult> GetExchangeRate()
        {
            var requestUri = "https://v6.exchangerate-api.com/v6/de57eae077d496d8b855b3e3/latest/USD";
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return Content(responseData, "application/json");
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { Error = $"Erro na requisição: {response.StatusCode}" });
            }
        }
    }
}
