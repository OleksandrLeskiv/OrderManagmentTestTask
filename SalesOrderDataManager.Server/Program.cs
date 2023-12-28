using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesOrderDataManager.BLL.Interfaces;
using SalesOrderDataManager.BLL.Mappers;
using SalesOrderDataManager.BLL.Services;
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

var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ISalesOrderService, SalesOrderService>();
builder.Services.AddScoped<IWindowService, WindowService>();
builder.Services.AddScoped<ISubElementService, SubElementService>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

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