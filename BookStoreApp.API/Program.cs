using BookStoreApp.API.Configurations;
using BookStoreApp.API.Contracts;
using BookStoreApp.API.Data;
using BookStoreApp.API.Middleware;
using BookStoreApp.API.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("BookStoreAppDbConnection");
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(connString));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// add custom middleware for global exception handling
app.UseMiddleware<ExceptionMiddleware>();


app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();