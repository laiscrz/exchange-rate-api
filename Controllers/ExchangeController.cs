using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json.Linq;

namespace exchange_rate_api.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar API de câmbio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase, IExchangeController
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://v6.exchangerate-api.com/v6/de57eae077d496d8b855b3e3/latest/USD";

        public ExchangeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Obtém a taxa de câmbio mais recente do dólar americano (USD) para o real brasileiro (BRL).
        /// </summary>
        /// <returns>Retorna um objeto JSON contendo a taxa de câmbio atual, o par de moedas, e a data da consulta.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a taxa de câmbio mais recente do USD para BRL.", Description = "Retorna a taxa de câmbio do USD para BRL.")]
        public async Task<JsonResult> GetExchangeRate()
        {
            return await FetchExchangeRate();
        }

        JsonResult IExchangeController.GetExchangeRate()
        {
            return FetchExchangeRate().Result;
        }

        /// <summary>
        /// Método privado para buscar a taxa de câmbio.
        /// </summary>
        /// <returns>Retorna um JsonResult com a taxa de câmbio ou mensagem de erro.</returns>
        private async Task<JsonResult> FetchExchangeRate()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseData);
                var exchangeRate = json["conversion_rates"]?["BRL"]?.Value<decimal>();

                if (exchangeRate.HasValue)
                {
                    var result = new
                    {
                        CurrencyPair = "USD/BRL",
                        Rate = exchangeRate.Value,
                        Date = DateTime.Now
                    };

                    return new JsonResult(result);
                }
                else
                {
                    return new JsonResult(new { Error = "Taxa de câmbio para BRL não encontrada." });
                }
            }
            else
            {
                return new JsonResult(new { Error = $"Erro na requisição: {response.StatusCode}" });
            }
        }
    }
}
