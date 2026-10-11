
var builder = WebApplication.CreateBuilder(args);

// Allow the Vercel frontend to access the API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins(
            "https://campuseats-web-seven.vercel.app/"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

app.UseCors("Frontend");

// Test endpoint
app.MapGet("/", () => new
{
    message = "CampusEats API is running"
});

// Sample menu endpoint
app.MapGet("/api/menu", () => new[]
{
    new { id = 1, name = "Chicken Rice", price = 850 },
    new { id = 2, name = "Vegetable Rice", price = 650 },
    new { id = 3, name = "Sandwich", price = 450 }
});

app.Run();
