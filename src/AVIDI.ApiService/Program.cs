using AVIDI.ApiService.Constants;
using AVIDI.ApiService.Data.DbContexts;
using AVIDI.ApiService.Data.Repository;
using AVIDI.ApiService.Data.Repository.Interfaces;
using AVIDI.ApiService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AVIDIDbContext>(option =>
   option.UseNpgsql(builder.Configuration.GetConnectionString(ConnectionName.EventConnection)));

builder.Services.AddScoped<IDataEventRepository<DateEvent>, DataEventRepository>();

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
