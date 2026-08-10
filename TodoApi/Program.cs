using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("ToDoDB")));



// Register CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            if (builder.Build().Environment.IsDevelopment())
            {
                policy.WithOrigins("http://localhost:5173") // Allow frontend in development
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            }
            else
            {
                policy.WithOrigins("https://rachmyers.github.io/vite-to-do/") // Allow frontend in production
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            }

        });

/*policy =>
{
    policy.WithOrigins("http://localhost:300") // Allow frontend
          .AllowAnyMethod()
          .AllowAnyHeader();
})*/;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
