using Alachisoft.NCache.Caching.Distributed;
using DistributedCache_NCache.Data;
using DistributedCache_NCache.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(c => 
c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Add NCache implementation here...
builder.Services.AddNCacheDistributedCache(configuration =>
{
    configuration.CacheName = "myClusteredCache";
    configuration.EnableLogs = true;
    configuration.ExceptionsEnabled = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IStudent<>), typeof(StudentService<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
