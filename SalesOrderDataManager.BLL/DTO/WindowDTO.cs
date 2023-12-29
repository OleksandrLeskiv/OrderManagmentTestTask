namespace SalesOrderDataManager.BLL.DTO;

public class WindowDTO
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public int QuantityOfWindows { get; set; }
    public int TotalSubElements { get; set; }
    public List<SubElementDTO>? SubElements { get; set; }
    public SalesOrderDTO? Order { get; set; }
    public string? OrderId { get; set; }
}