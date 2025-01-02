using Microsoft.EntityFrameworkCore;
using PF2EBattleTracker.API;
using PF2EBattleTracker.API.DbContexts;
using PF2EBattleTracker.API.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/characterinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

builder.Services.AddProblemDetails();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif
builder.Services.AddSingleton<CharactersDataStore>();
//builder.Services.AddDbContext<CharacterInfoContext>(dbContextOptions => dbContextOptions.UseSqlServer("server=DESKTOP-PT0JD3S\\SQLEXPRESS;database=PF2eTracker.;trusted_connection=true;"));
builder.Services.AddDbContext<CharacterInfoContext>(dbContextOptions => 
    dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:CharacterInfoDBConnectionString"])
);

builder.Services.AddScoped<ICharacterInfoRepository, CharacterInfoRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
