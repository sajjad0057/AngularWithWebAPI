using Crud_back.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CrudDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrudConnectionString")));

//#region ForConfiguring CORS

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSites",
//        builder =>
//        {
//            builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//        });
//});

//#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
