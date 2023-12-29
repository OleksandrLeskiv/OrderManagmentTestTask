using Microsoft.AspNetCore.Mvc;
using SalesOrderDataManager.BLL.DTO;
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
    
    [HttpPost]
    public async Task<ActionResult> CreateOrUpdateSalesOrder(WindowDTO window)
    {
        var addedWindow = await _windowService.AddOrUpdate(window);
        return Ok(addedWindow);
    }
    
    [HttpDelete("{id:guid}")] 
    public async Task<IActionResult> DeleteWindow(Guid id)
    {
        await _windowService.DeleteById(id);
        return Ok();
    }
}