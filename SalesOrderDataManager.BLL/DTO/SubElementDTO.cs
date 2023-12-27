namespace SalesOrderDataManager.BLL.DTO;

public class SubElementDTO
{
    public string? Element { get; set; }
    public string? Type { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public WindowDTO? Window { get; set; }
}