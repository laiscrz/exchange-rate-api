using Microsoft.AspNetCore.Mvc;

namespace exchange_rate_api.Controllers
{
    public interface IExchangeController
    {
        JsonResult GetExchangeRate();
    }
}
