using Microsoft.Extensions.Configuration;
using Movies;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<TMDbApiSettings>(builder.Configuration.GetSection("TMDbApiSettings"));

// ������ HttpClient ��� �����䳿 � TMDb API
builder.Services.AddHttpClient<TMDbApiClient>();
builder.Services.AddTransient<MoviesController>();

//���� ������������
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactMovies",
       builder => builder
            .AllowAnyOrigin()  // ��������� ������ � ����-����� �������
            .AllowAnyMethod()  // ����� �� ����-�� HTTP-������ (GET, POST, itd.)
            .AllowAnyHeader()); // ����� �� ����-�� HTTP-���������
}); 



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello Movies");
//    });
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


app.Run();
