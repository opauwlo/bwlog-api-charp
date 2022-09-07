using BwlogApi.API.Repositories;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => policy.WithOrigins("http://localhost:5173")));

builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddSingleton<IUserRepository, InMemUserRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "BwlogApi.API", Version = "v1" });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();

app.Run();
