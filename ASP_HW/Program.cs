var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");

app.UseStaticFiles();

app.UseRouting();

//app.MapControllerRoute(
//    name: "test",
//    pattern: "blog/author/{name:regex([a-zA-Z]+)}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "course",
    pattern: "Course/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "blog",
    pattern: "Blog/{action=Index}/{slug?}");

app.MapControllers();

app.Run();