using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrderDataManager.DAL.Entities;

public class SubElement
{
    [Key] public Guid Id { get; set; }
    public string? Element { get; set; }
    public string? Type { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    [ForeignKey(nameof(Window))] public Guid? WindowId { get; set; }
    public Window? Window { get; set; }
}