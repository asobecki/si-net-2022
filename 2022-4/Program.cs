using _2022_4.di;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFirstService, FirstService>();
builder.Services.AddScoped<ISecondService, SecondService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

using(var myScope = app.Services.GetService<IServiceScopeFactory>().CreateScope()) {
  app.Use(async (context, next) => {
    await context.Response.WriteAsync("Pierwszy komunikat");
    await next.Invoke();
  });


  var firstService = myScope.ServiceProvider.GetRequiredService<IFirstService>();
  app.Use(async (c, n) => {
    firstService.FirstFunction(c);
    await n.Invoke();
  });

}

app.Run();
