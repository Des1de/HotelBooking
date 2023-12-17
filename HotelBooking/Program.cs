using HotelBooking.DAL;
using HotelBooking.DAL.Interfaces;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entity;
using HotelBooking.Service.Implementations;
using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection"); 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connection, b => b.MigrationsAssembly("HotelBooking")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
    });


builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<IBaseRepository<UserInfo>, UserInfoRepository>();
builder.Services.AddScoped<IBaseRepository<Hotel>, HotelRepository>();
builder.Services.AddScoped<IBaseRepository<HotelAddress>, HotelAddressRepository>();
builder.Services.AddScoped<IBaseRepository<HotelPhoto>, HotelPhotoRepository>();
builder.Services.AddScoped<IBaseRepository<HotelReview>, HotelReviewRepository>();
builder.Services.AddScoped<IBaseRepository<HotelRoom>, HotelRoomRepository>();
builder.Services.AddScoped<IBaseRepository<HotelRoomPhoto>, HotelRoomPhotoRepository>();
builder.Services.AddScoped<IBaseRepository<HotelRoomReview>, HotelRoomReviewRepository>();
builder.Services.AddScoped<IBaseRepository<Reservation>, ReservationRepository>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IHotelRoomService, HotelRoomService>();  
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IHotelReviewService, HotelReviewService>();
builder.Services.AddScoped<IHotelRoomReviewService, HotelRoomReviewService>();




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