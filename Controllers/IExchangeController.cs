using Microsoft.AspNetCore.Mvc;

namespace exchange_rate_api.Controllers
{
    /// <summary>
    /// Define a estrutura para um controlador de API que lida com a obtenção da taxa de câmbio do dólar americano (USD) em relação a outras moedas.
    /// </summary>
    public interface IExchangeController
    {
        /// <summary>
        /// Obtém a taxa de câmbio mais recente do dólar americano (USD) em relação ao real brasileiro (BRL).
        /// </summary>
        /// <returns>Um <see cref="JsonResult"/> contendo a taxa de câmbio atual, ou uma mensagem de erro se a taxa não puder ser obtida.</returns>
        JsonResult GetExchangeRate();
    }
}
