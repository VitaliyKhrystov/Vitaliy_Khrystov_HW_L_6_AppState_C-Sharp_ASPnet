using System.Net;

namespace Task2
{
    //«адание 2
    //—оздайте MVC приложение форму, на которой будет находитьс€ два пол€ ввода, одно поле
    //ввода дл€ значени€, а второе поле ввода дл€ установки даты и времени(можете использовать
    //HTML элемент управлени€) и кнопка, котора€ отправит данные на сервер.Ќа сервере
    //полученна€ информаци€ должна быть записана в Cookies с установкой даты устаревани€
    //равной той, котора€ была установлена во втором поле ввода в форме.—делайте страницу,
    //котора€ будет использоватьс€ дл€ проверки наличи€ значени€ в Cookies

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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
        }
    }
}