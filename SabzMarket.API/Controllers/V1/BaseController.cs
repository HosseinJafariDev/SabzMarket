using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.Filters;

namespace SabzMarket.API.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiResultFilter]
    public class BaseController : ControllerBase
    {
    }
}