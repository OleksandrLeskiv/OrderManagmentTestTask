using Microsoft.AspNetCore.Mvc;
using SalesOrderDataManager.BLL.Interfaces;

namespace SalesOrderDataManager.Server.Controllers;

[ApiController]
[Route("api/SalesOrder/{salesOrderId:guid}/[controller]")]
public class WindowController : ControllerBase
{
    private readonly IWindowService _windowService;

    public WindowController(IWindowService windowService)
    {
        _windowService = windowService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWindows(Guid salesOrderId)
    {
        var all = await _windowService.GetAllByCondition(a => a.OrderId == salesOrderId);
        return Ok(all);
    }
}