namespace SalesOrderDataManager.BLL.DTO;

public class SalesOrderDTO
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? State { get; set; }
    public List<WindowDTO>? Windows { get; set; }
}