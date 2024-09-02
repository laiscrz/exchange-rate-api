using Swashbuckle.AspNetCore.Annotations;

namespace exchange_rate_api.Models
{
    public class ConversionRate : IConversionRate
    {
        /// <summary>
        /// Obtém ou define a taxa de câmbio do real brasileiro (BRL) em relação ao dólar americano (USD).
        /// </summary>
        [SwaggerSchema(Title = "Taxa de Câmbio BRL", Description = "A taxa de câmbio atual do real brasileiro (BRL) em relação ao dólar americano (USD).")]
        public double BRL { get; set; }
    }
}
