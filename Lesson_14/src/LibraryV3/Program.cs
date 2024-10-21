using LibraryV3.Endpoints.Books;
using LibraryV3.Endpoints.User;
using LibraryV3.Repositories;
using LibraryV3.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", false)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IUserAuthorizationService, UserAuthorizationService>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapCreateUser();
app.MapLogIn();
app.MapCreateBook();
app.MapGetBooksByTitle();
app.MapGetBooksByAuthor();
app.MapDeleteBook();
app.Run();