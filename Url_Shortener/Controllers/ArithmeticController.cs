using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Url_Shortener.Controllers;

public class ArithmeticController : ControllerBase
{
    [Authorize]
    [Route("SumValues")]
    public IActionResult Sum([FromQuery(Name = "Value1")] int value1, [FromQuery(Name = "Value2")] int value2)
    {
        var result = value1 + value2;
        return Ok(result);
    }
}