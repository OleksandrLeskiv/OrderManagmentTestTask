using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Configurations;

public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
{
    public static Guid FirstId = new("5eca5808-4f44-4c4c-b481-72d2bdf24203");
    public static Guid SecondId = new("5b32effd-2636-4cab-8ac9-3258c746aa53");

    public void Configure(EntityTypeBuilder<SalesOrder> builder)
    {
        builder.HasData(
            new SalesOrder()
            {
                Id = FirstId,
                Name = "New York Building 1",
                State = "NY",
            }, new SalesOrder()
            {
                Id = SecondId,
                Name = "California Hotel AJK",
                State = "CA"
            });
    }
}