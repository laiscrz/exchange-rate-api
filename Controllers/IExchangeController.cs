using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace exchange_rate_api.Controllers
{
    public interface IExchangeController
    {
        JsonResult GetExchangeRate();
    }
}
