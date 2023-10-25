using Microsoft.Extensions.Configuration;
using Movies;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<TMDbApiSettings>(builder.Configuration.GetSection("TMDbApiSettings"));

// Додати HttpClient для взаємодії з TMDb API
builder.Services.AddHttpClient<TMDbApiClient>();
builder.Services.AddTransient<MoviesController>();

//Інша конфігурація
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactMovies",
       builder => builder
            .AllowAnyOrigin()  // Можливість запитів з будь-якого джерела
            .AllowAnyMethod()  // Дозвіл на будь-які HTTP-методи (GET, POST, itd.)
            .AllowAnyHeader()); // Дозвіл на будь-які HTTP-заголовки
}); 

//builder.Services.AddCors();
//builder.Services.AddSpaStaticFiles(configuration =>
//{
//    configuration.RootPath = "ClientApp/build";
//});








var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("ReactMovies");


app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello Movies");
});

app.UseCors("ReactMovies");


//app.MapGet("api/movies/{action}/{id?}", async context => ());


//app.Run(async (context) => await context.Response.WriteAsync("Hello I'm Movies"));

app.Run();
