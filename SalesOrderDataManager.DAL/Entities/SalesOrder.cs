using System.ComponentModel.DataAnnotations;

namespace SalesOrderDataManager.DAL.Entities;

public class SalesOrder
{
    [Key] public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? State { get; set; }
    public ICollection<Window>? Windows { get; set; }
}