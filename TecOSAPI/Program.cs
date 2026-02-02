using Microsoft.EntityFrameworkCore;
using TecOS.Application.UseCases.Companies.CreateCompany;
using TecOS.Application.UseCases.Companies.DeleteCompany;
using TecOS.Application.UseCases.Companies.GetCompanies;
using TecOS.Application.UseCases.Companies.UpdateCompany;
using TecOS.Domain.Interfaces.Repositories;
using TecOS.Infrastructure.Data;
using TecOS.Infrastructure.Data;
using TecOS.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString, b => 
        b.MigrationsAssembly("TecOSAPI.Infrastructure")));

builder.Services.AddScoped<CreateCompanyUseCase>();
builder.Services.AddScoped<GetCompaniesUseCase>();
builder.Services.AddScoped<UpdateCompanyUseCase>();
builder.Services.AddScoped<DeleteCompanyUseCase>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI(); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();