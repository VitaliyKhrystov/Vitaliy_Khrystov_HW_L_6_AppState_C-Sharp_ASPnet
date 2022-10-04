namespace Task1
{
    public class Program
    {

        //������� 1
        //�������� MVC ����������, ������� ����� ������������ ���������� ������������� ������.
        //���������� ������������� ������ ������������ �� �������� ������ ����������.��� �������� 
        //������ ����������, ��������� ��� � ��������� ���������.���� �� �������� ���������� � ���� 
        //���������, ���������� ������������� ������ ������ ���� ������ ����.

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddMemoryCache(); // ��� �������� ������ � ������ � ��� ������������� ����������� (IMemoryCache)
            builder.Services.AddSession(); // ��� ������������� ������

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession(); // ��� ������������� ������

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