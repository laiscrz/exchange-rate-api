using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace exchange_rate_api.Controller
{
    public interface IExchangeController
    {
        Task<JsonResult> GetExchangeRate();
    }
}
