using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<appDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("appDBContext") ?? throw new InvalidOperationException("Connection string 'appDBContext' not found.")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//TODO: migra��o automatica

app.Run();
