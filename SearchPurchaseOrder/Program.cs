using SearchPurchaseOrder.Configuration;
using SearchPurchaseOrder.Filters;
using SearchPurchaseOrder.Interfaces;
using SearchPurchaseOrder.Services;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MediatR rejestracja
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//singleton for the class implementing CSV import: (cache class for the csv object)
builder.Services.AddSingleton<IPurchaseOrderFileReader>(CsvOrderFileReader.Instance);

builder.Services.AddHostedService<PurchaseOrderHostedService>();
//rejestracja filtrów
builder.Services.AddTransient<IOrderFilter, PurchaseOrderFilters>();
//add DI for the path to the appsettings file:
builder.Services.Configure<PurchaseOrderDataSettings>(Configuration.GetSection(nameof(PurchaseOrderDataSettings)));

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
