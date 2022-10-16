using _2022_3.di;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFirstService, FirstService>();
builder.Services.AddScoped<ISecondService, SecondService>();

var app = builder.Build();
using(var myScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
    app.Use(async (context, next) => {
            await context.Response.WriteAsync("Pierwszy element potoku");
            await next.Invoke();
            });

    var firstService = myScope.ServiceProvider.GetRequiredService<IFirstService>();
    app.Use(async (c, n) => {
            firstService.FirstFunction(c);
            await n.Invoke();
            });
}

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
