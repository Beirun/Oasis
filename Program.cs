using Oasis.Components;
using Microsoft.EntityFrameworkCore;
using System;

using Sysinfocus.AspNetCore.Components;
using Oasis.Data;
using Oasis.State;


using Oasis.Library;
using Blazored.LocalStorage;
var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddRazorComponents()
//    .AddInteractiveWebAssemblyRenderMode();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddRazorPages()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddScoped<GuestServices>();
builder.Services.AddScoped<SignInServices>();
builder.Services.AddScoped<StaffServices>();
builder.Services.AddScoped<RoomServices>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<UserState>();
builder.Services.AddScoped<CheckInState>();
 builder.Services.AddSysinfocus(false);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
