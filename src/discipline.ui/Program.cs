using discipline.core;
using discipline.core.Configuration;
using discipline.core.Exceptions;
using discipline.ui.Components;
using discipline.ui.Components.Layout;
using discipline.ui.Services.Configuration;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCore(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddBlazorBootstrap();
var app = builder.Build();

app.UseExceptionHandler(options =>
{
    options.Run(context =>
    {
        var ex = context.Features.Get<IExceptionHandlerFeature>();
        var type = ex?.Error.GetType();
        if (type == typeof(UnauthorizedException))
        {
            context.Response.Redirect("/sign-in");
        }

        if (type == typeof(ForbiddenException))
        {
            context.Response.Redirect("/pick-subscription-order");
        }

        return Task.CompletedTask;
    });
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    // app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();