using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrderDataManager.DAL.Entities;

public class Window
{
    [Key] public Guid Id { get; set; }
    public string? Name { get; set; }
    public int QuantityOfWindows { get; set; }
    public int TotalSubElements { get; set; }

    public ICollection<SubElement>? SubElements { get; set; }

    [ForeignKey(nameof(Order))] public Guid? OrderId { get; set; }
    public SalesOrder? Order { get; set; }
}