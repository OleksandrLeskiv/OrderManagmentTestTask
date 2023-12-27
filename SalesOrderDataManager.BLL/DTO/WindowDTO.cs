namespace SalesOrderDataManager.BLL.DTO;

public class WindowDTO
{
    public string? Name { get; set; }
    public int QuantityOfWindows { get; set; }
    public int TotalSubElements { get; set; }
    public List<SubElementDTO>? SubElements { get; set; }
    public SalesOrderDTO? Order { get; set; }
}