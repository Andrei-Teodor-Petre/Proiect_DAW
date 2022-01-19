using Microsoft.EntityFrameworkCore;
using QuertyKey_DAW;
using QuertyKey_DAW.DataModels;
using QuertyKey_DAW.Repositories;
using QuertyKey_DAW.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddDbContext<QuertyKey_DAWContext>(
    options =>
        options.UseNpgsql(builder.Configuration["ConnectionString"])
);

#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<AccessoryRepository>();
builder.Services.AddTransient<DeskmatRepository>();
builder.Services.AddTransient<KeyboardRepository>();
builder.Services.AddTransient<KeycapRepository>();
builder.Services.AddTransient<MerchRepository>();
builder.Services.AddTransient<OrderRepository>();
builder.Services.AddTransient<SpecialtyRepository>();
builder.Services.AddTransient<SwitchRepository>();
builder.Services.AddTransient<UserRepository>();

builder.Services.AddTransient<UnitOfWork>();
#endregion

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
