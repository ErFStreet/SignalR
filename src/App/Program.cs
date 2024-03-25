namespace App;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllersWithViews();

        // Add SignalR 

        builder.Services.AddSignalR();

        var app = builder.Build();

        // route for chat 

        app.MapHub<ChatHub>("/chatHub");

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Hub}/{action=ChatRoom}/{id?}");

        app.Run();
    }
}

