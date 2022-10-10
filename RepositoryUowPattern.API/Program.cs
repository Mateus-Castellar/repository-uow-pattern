using Microsoft.EntityFrameworkCore;
using RepositoryUowPattern.API.Data;
using RepositoryUowPattern.API.Data.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(lbda =>
    lbda.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationContext>(lbda =>
    lbda.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//inicializa a base de dados com resgistro (extension method)
app.IniciarBaseDaDados();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();