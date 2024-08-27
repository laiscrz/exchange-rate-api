using System.Net.Http;
using System.Threading.Tasks;

public class ExchangeRateService
{
    private readonly HttpClient _httpClient;

    public ExchangeRateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetExchangeRateAsync()
    {
        var requestUri = "https://v6.exchangerate-api.com/v6/de57eae077d496d8b855b3e3/latest/USD";
        HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");
        }
    }
}
