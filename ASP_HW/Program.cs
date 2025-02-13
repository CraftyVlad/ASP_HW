using ASP_HW;

//Завдання 1
//Додаток із налаштувань конфігурації має отримувати об'єкт Student, який містить таку інформацію:
//Name
//Surname;
//Age;
//DisciplineList.
//Налаштування конфігурації зберігати у файлах JSON (і/або XML).
//Проект за запитом на адресу /home має виводити інформацію про студента, а за адресою /academy - список дисциплін.
//Реалізувати Middleware, що обробляє кожен з даних маршрутів і отримує об'єкти через IOptions за допомогою механізму впровадження залежностей.



// Зайдіть на /home або /academy, щоб побачити дані
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Student>(builder.Configuration.GetSection("Student"));

var app = builder.Build();

app.UseMiddleware<StudentMiddleware>();

app.Run();
