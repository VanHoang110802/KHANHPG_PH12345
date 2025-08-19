using AppData.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký dịch vụ
builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();

// CORS cấu hình ở đây
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build(); // Phải build trước khi dùng app

// Middleware
app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Gọi sau khi build
app.UseAuthorization();

app.MapControllers(); // Kích hoạt các controller

app.Run();
