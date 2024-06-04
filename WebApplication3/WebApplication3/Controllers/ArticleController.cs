using cursach_3.DTO.Article; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using cursach_3.Service.ArticleService;

namespace cursach_3.Controllers
{
    [ApiController]
    [Route("Articlies")] // Путь для запроса в Swagger
    public class ArticleController(IArticleService ArticleService) : Controller // Контроллеры, передающие запрос в сервис авторов
    {
        [HttpGet]  // Тип автора
        public JsonResult GetArticlies()   // Запрос на получение данных обо всех авторов в БД
        {
            var articlies = ArticleService.GetArticlies(); // создание списка авторов на основе данных, полученных из сервиса
            return Json(articlies);  // Возвращение списка авторов в файл Json
        }

        [Route("{Article_ID}")]  // Путь для запроса в Swagger
        [HttpGet]  // Тип запроса
        public IActionResult GetCity(long Article_ID)  // Запрос на получение информации об определенном авторе из БД
        {
            var article = ArticleService.GetArticle(Article_ID);  // Нахождение автора через обращение в сервис авторов
            if (article == null) return NotFound("Article not found"); // Если такого автора не существует
            return Json(article); // Вывод информации об авторе
        }

        [Route("create")]  // Путь для запроса в Swagger
        [HttpPost]  // Тип запроса
        public JsonResult CreateArticle(CreateArticle dto) // Запрос на создание автора в БД
        {
            ArticleService.InsertArticle(dto); // Обращение к функции создания автора в сервисе авторов
            return Json("New Article has been created");  // Уведомление пользователя о создании автора
        }

        [Route("update")] // Путь для запроса в Swagger
        [HttpPatch] // Тип запроса
        public JsonResult UpdateArticle(UpdateArticle dto) // Запрос на обновление информации об авторе в БД
        {
            ArticleService.UpdateArticle(dto);  // Обращение к функции обновления информации  об авторе в сервисе авторов
            return Json("Article has been updated");
        }

        [Route("delete/{Article_ID}")] // Путь для запроса в Swagger
        [HttpDelete] // Тип запроса
        public JsonResult DeleteArticle(long Article_ID)  // Запрос на удаление автора из БД
        {
            ArticleService.DeleteArticle(Article_ID); // Обращение к функциии удаления автора в сервисе авторов
            return Json("Article has been deleted");
        }
    }
}
