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

        app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Category}/{action=Delete}/{Id=0}"
            );

        app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Category}/{action=List}/{Id=0}/{Page=1}"
            );
        app.Run();
    }
}