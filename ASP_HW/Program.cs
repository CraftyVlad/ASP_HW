using ASP_HW.Middleware;
using ASP_HW.Models;

//За допомогою патерну Dependency Injection реалізувати таке завдання.
//Створити інтерфейс IWeapon з методом Kill, а також класи реалізації (наприклад, Bazuka і Sword), і клас Warrior, який користується зброєю.
//Воїн (Warrior) не знає, чи є в нього зброя, і видачею зброї займається окремий модуль, а не головна програма. Використання фреймворка Ninject або Autofac рідного контейнера DI має забезпечити можливість централізованої заміни класу реалізації.
//У подання вивести результат виклику методу Kill(), який повертає рядок з описом способу дії встановленої як реалізація зброї. Для виводу використовувати клас middleware.

var builder = WebApplication.CreateBuilder(args);

// Тут можна вибрати bazuka або sword
builder.Services.AddTransient<IWeapon, Bazuka>();
builder.Services.AddTransient<Warrior>();

var app = builder.Build();

app.UseMiddleware<WarriorMiddleware>();

app.Run();
