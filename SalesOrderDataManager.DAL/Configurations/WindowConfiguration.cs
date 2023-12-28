using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Configurations;

public class WindowConfiguration : IEntityTypeConfiguration<Window>
{
    public static Guid FirstId = new("5eca5808-4f44-4c4c-b481-72d2bdf24203");
    public static Guid SecondId = new("4ffa6173-bc0b-4d3b-9a68-65227dd1bc8b");
    public static Guid ThirdId = new("5eca5808-545a-4c4c-b481-72d2bdf24203");
    public static Guid FourthId = new("6eca5808-4f44-4c4c-b481-72d2bdf24203");

    public void Configure(EntityTypeBuilder<Window> builder)
    {
        builder.HasData(
            new Window()
            {
                Id = FirstId,
                Name = "A51",
                QuantityOfWindows = 4,
                TotalSubElements = 3,
                OrderId = SalesOrderConfiguration.FirstId
            }, new Window()
            {
                Id = SecondId,
                Name = "C Zone 5",
                QuantityOfWindows = 2,
                TotalSubElements = 1,
                OrderId = SalesOrderConfiguration.FirstId
            }, new Window()
            {
                Id = ThirdId,
                Name = "GLB",
                QuantityOfWindows = 3,
                TotalSubElements = 2,
                OrderId = SalesOrderConfiguration.SecondId
            }, new Window()
            {
                Id = FourthId,
                Name = "OHF",
                QuantityOfWindows = 10,
                TotalSubElements = 2,
                OrderId = SalesOrderConfiguration.SecondId
            });
    }
}