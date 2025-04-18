using Microsoft.EntityFrameworkCore;
using PLanguageQuizGame.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuizgameDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("QuizGameDataBase"),
        new MySqlServerVersion(new Version(8, 0, 36)), 
        mySqlOptions => mySqlOptions.EnableRetryOnFailure() 
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseSwagger();
app.UseSwaggerUI();

app.Run();

