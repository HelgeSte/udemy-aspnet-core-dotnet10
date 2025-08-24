var builder = WebApplication.CreateBuilder(args);

// Required for activating the HomeController and other controllers
//builder.Services.AddTransient<HomeController>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles(); // default webroot = wwwroot

// Required for activating the HomeController and other controllers
app.MapControllers();

app.Run();