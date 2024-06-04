// Контроллеры находятся в папке Controllers.  Используеются для связи между внешнней средой и программой посредством http-запросов (например, через insomnia)

// DTO - Data Transfer Object -
// Объект, который используется для передачи данных из БД (в таком случае DTO временно перенимает все свойства указанного для транспортировки объекта и передается пользователю)
// или в БД (в таком случае DTO принимает все свойства, указанные пользоватиелем извне, и далее передается в БД, где эти свойства присваиваются указанному пользователем объекту (например, созданной по запросу при добавлении новой книги в БД пустышке))
// (Например, для передачи всех книг используется один DTO, для каждой отдельной книги - Другой).
// Нужны для обеспечения безопасности содержимому внутри БД. Во внешнюю среду из БД всегда будет выдаваться DTO-Версия книги

// Repository - Содержат основную логику приложения, логику взаимодействия с БД (через Migrations и ApplicationContext), интерфейсы репозиториев и сами репозитории с их логикой.
// Репозиторий исполняет заложенные в него функции по запросу, поступившему от функции Сервиса.
// Репозиторий взаимодействует напрямую с содержимым БД через созданную ссылку

// Service - Содержит бизнес-логику приложнения. Используются для обращения к репозиторию по запросу, поступившему из контроллера
// Data - Хранит модели и сущности, используемые в программе для постройки и связи с БД


//Архитектура программы выглядит следующим образом:
// 1.Внешняя среда (Отсюда поступает запрос)
// 2.Контроллер (Определяет возможность исполнения поступивего запроса)
// 3.Сервис (Задействует необходимые для исполнения запроса функции репозитория)
// 4.Репозиторий (Общается с БД через свои функции (Например, создает DTO для пердачи данных в или из БД))
// 5.ApplicationContext (EF-Прослойка между нашей программой и БД). Организует взаимодействие между ними. Содержит в себе EF-Модели, соответствующие по структуре таблицам из БД
// 5.БД (Ее содержимое дорступно только репозиторию)

using cursach_3.Repository.ArticleRepository;
using cursach_3.Repository.AuthorRepository;
using cursach_3.Repository.CommentaryRepository;
using cursach_3.Repository.File_ArchiveRepository;
using cursach_3.Repository.Migrations;
using cursach_3.Repository.Photo_folderRepository;
using cursach_3.Repository.ThreadRepository;
using cursach_3.Repository.TopicRepository;
using cursach_3.Repository.UserRepository;
using cursach_3.Service.ArticleService;
using cursach_3.Service.AuthorService;
using cursach_3.Service.CommentaryService;
using cursach_3.Service.File_ArchiveService;
using cursach_3.Service.Photo_folderService;
using cursach_3.Service.ThreadService;
using cursach_3.Service.TopicService;
using cursach_3.Service.UserService;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")); //  Постройка связи моделей с базой данных DefaultConnection
});
builder.Services.AddScoped(typeof(IArticleRepository), typeof(ArticleRepository));  // Добавление в зону видимости программы репозитория книг для возможности управлени содержимым в нем через сервис книг
builder.Services.AddTransient<IArticleService, ArticleService>(); // Добавление в зону видимости программы сервиса книг для управления содержимым репозитория книг
builder.Services.AddScoped(typeof(IAuthorRepository), typeof(AuthorRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<IAuthorService, AuthorService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(IFile_ArchiveRepository), typeof(File_ArchiveRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<IFile_ArchiveService, File_ArchiveService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(IPhoto_folderRepository), typeof(Photo_folderRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<IPhoto_folderService, Photo_folderService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(IThreadRepository), typeof(ThreadRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<IThreadService, ThreadService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(ITopicRepository), typeof(TopicRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<ITopicService, TopicService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<IUserService, UserService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(ICommentaryRepository), typeof(CommentaryRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<ICommentaryService, CommentaryService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();