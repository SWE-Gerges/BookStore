using BookStore.Models;
using BookStore.Models.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string ConnectionString = builder.Configuration.GetConnectionString("BookStoreDB");
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookStoreRepository<Author>, AuthorDbRepo>();
builder.Services.AddScoped<IBookStoreRepository<Book>, BookDbRepo>();
builder.Services.AddDbContext<DataContext>(options => 
options.UseMySql(ConnectionString,ServerVersion.AutoDetect(ConnectionString)));
builder.Services.AddMvc().AddRazorRuntimeCompilation();

//builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
