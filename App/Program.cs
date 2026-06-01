using BLL.Services;
using DAL.EF;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Repos
builder.Services.AddScoped<BookRepo>();
builder.Services.AddScoped<StudentRepo>();
builder.Services.AddScoped<BorrowRepo>();
builder.Services.AddScoped<AuthRepo>();
builder.Services.AddScoped<ReportRepo>();

// Services
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<BorrowService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ReportService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapStaticAssets();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();