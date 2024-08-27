using Microsoft.AspNetCore.Mvc;
using System;

namespace exchange_rate_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly ExchangeRateService _exchangeRateService;

        public ExchangeController(ExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExchangeRate()
        {
            try
            {
                var exchangeRate = await _exchangeRateService.GetExchangeRateAsync();
                return Ok(exchangeRate);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
