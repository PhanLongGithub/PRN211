internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession();

        var app = builder.Build();

        app.UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Home}/{action=Index}"
            );

        app.Run();
    }
}