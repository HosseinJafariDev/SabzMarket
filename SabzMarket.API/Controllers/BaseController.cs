using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.Filters;

namespace SabzMarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiResultFilter]
    public class BaseController : ControllerBase
    {
    }
}