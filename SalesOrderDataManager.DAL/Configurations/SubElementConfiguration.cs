using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Configurations;

public class SubElementConfiguration : IEntityTypeConfiguration<SubElement>
{
    public void Configure(EntityTypeBuilder<SubElement> builder)
    {
        builder.HasData(
            new SubElement()
            {
                Id = Guid.NewGuid(),
                Element = "1",
                Type = "Doors",
                Width = 1200,
                Height = 1850,
                WindowId = WindowConfiguration.FirstId
            },
            new SubElement()
            {
                Id = Guid.NewGuid(),
                Element = "2",
                Type = "Window",
                Width = 800,
                Height = 1850,
                WindowId = WindowConfiguration.FirstId
            },
            new SubElement()
            {
                Id = Guid.NewGuid(),
                Element = "3",
                Type = "Window",
                Width = 700,
                Height = 1850,
                WindowId = WindowConfiguration.FirstId
            },
            new SubElement()
            {
                Id = Guid.NewGuid(),
                Element = "1",
                Type = "Window",
                Width = 1500,
                Height = 2000,
                WindowId = WindowConfiguration.SecondId
            },
            new SubElement()
            {
                Id = Guid.NewGuid(),
                Element = "1",
                Type = "Doors",
                Width = 1400,
                Height = 2200,
                WindowId = WindowConfiguration.ThirdId
            },
            new SubElement()
            {
                Id = Guid.NewGuid(),
                Element = "2",
                Type = "Window",
                Width = 600,
                Height = 2200,
                WindowId = WindowConfiguration.ThirdId
            },
            new SubElement()
            {
                Id = Guid.NewGuid(),
                Element = "1",
                Type = "Window",
                Width = 1500,
                Height = 2000,
                WindowId = WindowConfiguration.FourthId
            },
            new SubElement()
            {
                Id = Guid.NewGuid(),
                Element = "1",
                Type = "Window",
                Width = 1500,
                Height = 2000,
                WindowId = WindowConfiguration.FourthId
            });
    }
}