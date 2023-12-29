using Microsoft.AspNetCore.Mvc;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.BLL.Interfaces;

namespace SalesOrderDataManager.Server.Controllers;

[ApiController]
[Route("api/SalesOrder/{salesOrderId:guid}/Window/{windowId:guid}/[controller]")]
public class SubElementController : ControllerBase
{
    private readonly ISubElementService _subElementService;

    public SubElementController(ISubElementService subElementService)
    {
        _subElementService = subElementService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubElementsForWindow(Guid salesOrderId, Guid windowId)
    {
        var all = await _subElementService.GetAllByCondition(a =>
            a.WindowId == windowId);

        return Ok(all);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteSalesOrder(Guid salesOrderId, Guid windowId, Guid id)
    {
        await _subElementService.DeleteById(id);
        return Ok();
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateOrUpdateSubElement(SubElementDTO subElement)
    {
        var addedOrder = await _subElementService.AddOrUpdate(subElement);
        return Ok(addedOrder);
    }
}
