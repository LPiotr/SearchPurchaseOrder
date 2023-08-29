using SearchPurchaseOrder.Configuration;
using SearchPurchaseOrder.Filters;
using SearchPurchaseOrder.Interfaces;

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

//rejestracja filtrów
//singleton dla klasy implementującej import CSV:
builder.Services.AddSingleton<IPurchaseOrderFileReader, CsvOrderFileReader>();
builder.Services.AddTransient<IOrderFilter, PurchaseOrderFilters>();
//dodajemy DI dla sciezki do pliku z appsettings:
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
