namespace Task1
{
    public class Program
    {

        //«адание 1
        //—оздайте MVC приложение, которое будет подсчитывать количество пользователей онлайн.
        // оличество пользователей должно отображатьс€ на странице вашего приложени€.ƒл€ проверки 
        //работы приложени€, запустите его в несколько браузерах.≈сли вы откроете приложение в трех 
        //браузерах, количество пользователей онлайн должно быть равное трем.

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddMemoryCache(); // дл€ хранени€ сессии в пам€ти и дл€ использовани€ кэшировани€ (IMemoryCache)
            builder.Services.AddSession(); // дл€ использовани€ сессии

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession(); // дл€ использовани€ сессии

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{data?}");

            app.Run();
        }
    }
}