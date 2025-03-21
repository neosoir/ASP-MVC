using ASP.app.Models; // Asegúrate de importar tu DbContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Leer la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar AppDbContext con MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Probar la conexión a la base de datos en tiempo de inicio
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        dbContext.Database.OpenConnection(); // Intenta abrir la conexión
        Console.WriteLine("✅ Conexión a la base de datos exitosa.");
        dbContext.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ Error al conectar a la base de datos:");
        Console.WriteLine(ex.Message);
    }
}

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run("http://0.0.0.0:80");
