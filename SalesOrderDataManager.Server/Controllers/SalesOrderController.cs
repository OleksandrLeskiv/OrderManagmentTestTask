using Microsoft.AspNetCore.Mvc;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.BLL.Interfaces;

namespace SalesOrderDataManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesOrderController : ControllerBase
{
    private readonly ISalesOrderService _salesOrderService;
    public SalesOrderController(ISalesOrderService salesOrderService)
    {
        _salesOrderService = salesOrderService;
    }

    [HttpGet] 
    public async Task<IActionResult> GetAll()
    {
        var all = await _salesOrderService.GetAllByCondition(_ => true);
        return Ok(all);
    }

    [HttpGet("{id:guid}")] 
    public async Task<IActionResult> GetSalesOrder(Guid id)
    {
        var orderDto = await _salesOrderService.GetFirstByCondition(a => a.Id == id);
        return orderDto is null
            ? NotFound()
            : Ok(orderDto);
    }
    
    [HttpPost] 
    public async Task<ActionResult> CreateOrUpdateSalesOrder(SalesOrderDTO order)
    {
        var addedOrder = await _salesOrderService.AddOrUpdate(order);
        return Ok(addedOrder);
    }
    
    [HttpDelete("{id:guid}")] 
    public async Task<IActionResult> DeleteSalesOrder(Guid id)
    {
        await _salesOrderService.DeleteById(id);
        return Ok();
    }
}