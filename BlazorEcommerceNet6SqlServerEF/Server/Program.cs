global using BlazorEcommerceNet6SqlServerEF.Shared;
global using Microsoft.EntityFrameworkCore;
global using BlazorEcommerceNet6SqlServerEF.Server.Data;
global using BlazorEcommerceNet6SqlServerEF.Server.Service.ProductService;
global using BlazorEcommerceNet6SqlServerEF.Server.Service.CategoryService;
using Microsoft.AspNetCore.ResponseCompression;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => // for database
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//instal swashbuckle.aspnetcore for swagger 
builder.Services.AddEndpointsApiExplorer(); //for swagger 
builder.Services.AddSwaggerGen(); //for swagger 

builder.Services.AddScoped<IProductService, ProductService>(); //
builder.Services.AddScoped<ICategoryService, CategoryService>();//

var app = builder.Build();

app.UseSwaggerUI(); //for swagger 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger(); //for swagger 

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
