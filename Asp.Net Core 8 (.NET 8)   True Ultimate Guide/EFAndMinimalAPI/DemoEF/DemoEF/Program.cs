using DemoNop.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClassicModelsDBContext>(
               options => options.UseMySQL(builder.Configuration.GetConnectionString("Default") ?? string.Empty));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapGet("/productsEagerLoading", async (ClassicModelsDBContext db) =>
//    await db.Products.Where(t => t.ProductCode == "S10_1678")
//            .Include(a => a.ProductLines).ToListAsync());

app.MapGet("/productsLazyLoading", async (ClassicModelsDBContext db) =>
    await db.Products.ToListAsync());

app.MapControllers();

app.Run();
