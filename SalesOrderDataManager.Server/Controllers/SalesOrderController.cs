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
        var all = await _salesOrderService.GetAllByCondition(a => a.Id == id);
        return Ok(all);
    }
    
    [HttpPost] // add new sales order
    public async Task<ActionResult> CreateEmployeeAsync(SalesOrderDTO employee)
    {
        await _salesOrderService.Add(employee);
        return Ok();
    }

    [HttpDelete("{id:guid}")] // delete sales order by id
    public async Task<IActionResult> DeleteSalesOrder(Guid id)
    {
        return Ok();
    }
}