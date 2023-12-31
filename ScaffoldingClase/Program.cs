var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// El ciclo de vida de los servicios aqu� definido se gestionan
// de forma autom�tica junto a la sesi�n https.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();