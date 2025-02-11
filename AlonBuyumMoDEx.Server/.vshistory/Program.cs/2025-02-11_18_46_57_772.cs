using AlonBuyumMoDEx.Server.DAL;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// for SQL server
//builder.Services.AddDbContext<ShoppingDb>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// for SQLite
builder.Services.AddDbContext<ShoppingDb>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// create the SQLite database
using (var scope = app.Services.CreateScope())
{
    var shoppingDb = scope.ServiceProvider.GetRequiredService<ShoppingDb>();
    shoppingDb.Database. EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
