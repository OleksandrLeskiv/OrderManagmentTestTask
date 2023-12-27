using Microsoft.EntityFrameworkCore;
using SalesOrderDataManager.DAL;
using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Interfaces;
using SalesOrderDataManager.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
builder.Services.AddScoped(provider => new Lazy<ISalesOrderRepository>(
    () => provider.GetService<ISalesOrderRepository>()!,
    LazyThreadSafetyMode.ExecutionAndPublication));

builder.Services.AddScoped<ISubElementRepository, SubElementRepository>();
builder.Services.AddScoped(provider => new Lazy<ISubElementRepository>(
    () => provider.GetService<ISubElementRepository>()!,
    LazyThreadSafetyMode.ExecutionAndPublication));

builder.Services.AddScoped<IWindowRepository, WindowRepository>();
builder.Services.AddScoped(provider => new Lazy<IWindowRepository>(
    () => provider.GetService<IWindowRepository>()!,
    LazyThreadSafetyMode.ExecutionAndPublication));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services
    .AddDbContext<ApplicationDbContext>(opts =>
        opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("SalesOrderDataManager.Server")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();