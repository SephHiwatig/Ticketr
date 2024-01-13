using Ticketr.Configuration.Extensions;
using Ticketr.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Backend features
builder.Host.UseConfigurations()
            .UseIdentityDbContext();

// Add services to the container.
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
