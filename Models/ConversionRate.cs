using Swashbuckle.AspNetCore.Annotations;

namespace exchange_rate_api.Models
{
    /// <summary>
    /// Representa a taxa de câmbio do real brasileiro (BRL) em relação ao dólar americano (USD).
    /// </summary>
    public class ConversionRate : IConversionRate
    {
        /// <summary>
        /// Obtém ou define a taxa de câmbio atual do real brasileiro (BRL) em relação ao dólar americano (USD).
        /// Esta propriedade indica o valor do dólar americano (USD) em reais brasileiros (BRL).
        /// </summary>
        [SwaggerSchema(Title = "Taxa de Câmbio BRL", Description = "A taxa de câmbio atual do real brasileiro (BRL) em relação ao dólar americano (USD).")]
        public double BRL { get; set; }
    }
}
