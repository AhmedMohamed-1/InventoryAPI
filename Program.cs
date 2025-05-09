using CRUD_API.DTOs.CategoryDTOs;
using CRUD_API.DTOs.SupplierDTOs;
using CRUD_API.DTOs.ProductDTOs;
using CRUD_API.Models;
using CRUD_API.Repositories.CategoryRepositories;
using CRUD_API.Repositories.ProductRepositories;
using CRUD_API.Repositories.SupplierRepositories;
using CRUD_API.Services.CategoryServices;
using CRUD_API.Services.ProductServices;
using CRUD_API.Services.SupplierServices;
using CRUD_API.ValidatorClasses.CategoryValidatorClasses;
using CRUD_API.ValidatorClasses.ProductValidatorClasses;
using CRUD_API.ValidatorClasses.SupplierValidatorClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register FluentValidation services
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

// Register specific validators
builder.Services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateCategoryDto>, UpdateCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<CreateSupplierDto>, CreateSupplierDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateSupplierDto>, UpdateSupplierDtoValidator>();
builder.Services.AddScoped<IValidator<CreateProductDto>, CreateProductDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateProductDto>, UpdateProductDtoValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

builder.Services.AddLogging();
builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryAPIconnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();

//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
