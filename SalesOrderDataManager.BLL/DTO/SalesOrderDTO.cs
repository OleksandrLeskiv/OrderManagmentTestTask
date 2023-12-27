namespace SalesOrderDataManager.BLL.DTO;

public class SalesOrderDTO
{
    public string? Name { get; set; }
    public string? State { get; set; }
    public List<WindowDTO>? Windows { get; set; }
}