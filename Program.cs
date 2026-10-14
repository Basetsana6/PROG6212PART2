var builder = WebApplication.CreateBuilder(args);
// Add controller support so the API can handle HTTP requests.
builder.Services.AddControllers();
// Add API documentation and Swagger support.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Enable Swagger for testing the API in the development environment.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();
// Map controller routes to their endpoints.
app.MapControllers();
// Start the Race Day API application.
app.Run();