using MarkMe.Core;
using MarkMe.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var _connectionString = builder.Configuration.GetConnectionString("MarkMe") ?? throw new Exception("Connections string for `MarkMe` is not provided.");
builder.Services.AddDapper(_connectionString);
builder.Services.AddDbContext(_connectionString);
builder.Services.AddServices();
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.Authority = "https://leading-yak-1.clerk.accounts.dev"; // Replace with your Clerk Issuer
    //options.Audience = "app_2pYpP3kQKnIA0qWOSW4OkQ883O2"; // Replace with your Clerk Frontend API key (Client ID)
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidIssuer = "https://leading-yak-1.clerk.accounts.dev", // Replace with your Clerk Issuer
        //ValidAudience = "app_2pYpP3kQKnIA0qWOSW4OkQ883O2", // Replace with your Clerk Frontend API key
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Use CORS policy
app.UseCors("AllowLocalhost3000");

app.MapControllers();

ApplyMigration();

app.Run();

void ApplyMigration()
{
    using var scope = app.Services.CreateScope();
    var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    // Ensure the database is deleted
    if (_db.Database.GetPendingMigrations().Count() > 0)
    {
        _db.Database.Migrate();
    }
}