using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using exchange_rate_api.Models;

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
        private const string API_KEY = "de57eae077d496d8b855b3e3";
        private const string ApiUrl = $"https://v6.exchangerate-api.com/v6/{API_KEY}/latest/USD";

        public ExchangeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Obtém a taxa de câmbio mais recente do dólar americano (USD) para o real brasileiro (BRL).
        /// </summary>
        /// <returns>Retorna um objeto JSON contendo a taxa de câmbio atual, o par de moedas, e a data da consulta.</returns>
        /// <response code="200">Retorna a taxa de câmbio do USD para BRL com sucesso.</response>
        /// <response code="400">Requisição malformada ou erro ao processar a taxa de câmbio.</response>
        /// <response code="500">Erro interno no servidor ou erro na chamada à API externa.</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a taxa de câmbio mais recente do USD para BRL.", Description = "Retorna a taxa de câmbio do USD para BRL.")]
        [Tags("Consulta de Câmbio")]
        [ProducesResponseType(typeof(ConversionRate), StatusCodes.Status200OK)]
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
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Requisição à API externa concluída com sucesso!");
                    
                    var responseData = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseData);
                    var exchangeRate = json["conversion_rates"]?["BRL"]?.Value<double>();

                    if (exchangeRate.HasValue)
                    {
                        var result = new ConversionRate
                        {
                            BRL = exchangeRate.Value
                        };

                        var responseJson = new JsonResult(new
                        {
                            CurrencyPair = "USD/BRL",
                            Rate = result.BRL,
                            Date = DateTime.Now
                        });
                        
                        return responseJson;
                    }
                    else
                    {
                        return new JsonResult(new { Error = "Taxa de câmbio para BRL não encontrada." });
                    }
                }
                else
                {
                    return new JsonResult(new { Error = $"Erro na resposta da API: {response.StatusCode}" });
                }
            }
            catch (HttpRequestException ex)
            {
                return new JsonResult(new { Error = $"Erro ao enviar a requisição: {ex.Message}" });
            }
            catch (JsonException ex)
            {
                return new JsonResult(new { Error = $"Erro ao processar a resposta JSON: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Error = $"Erro inesperado: {ex.Message}" });
            }
        }
    }
}
