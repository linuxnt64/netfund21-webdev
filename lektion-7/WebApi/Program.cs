using Microsoft.EntityFrameworkCore;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SqlContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*  
    AllowAnyHeader()      =     "Content-Type": "application/json", "Authorization": "bearer tokenkey"
    AllowAnyMethod()      =     POST, GET, PUT, PATCH, DELETE
    AllowAnyOrigin()      =     "https://localhost:5000/", "https://domain.com/", "https://lexicon.se/"
*/

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
