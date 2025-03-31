using Data.Context;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DATAConnection")));
            builder.Services.AddTransient<CompanyRepository>();
            builder.Services.AddTransient<SearchesRepository>();
            builder.Services.AddTransient<ContactTypeRepository>();
            builder.Services.AddTransient<ResponseRepository>();
            var app = builder.Build();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.Run();
        }
    }
}
