var builder = WebApplication.CreateBuilder(args);
string allowAllPolicy = "AllowAll";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllPolicy,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseCors(allowAllPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
