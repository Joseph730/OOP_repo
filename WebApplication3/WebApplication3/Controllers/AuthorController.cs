using cursach_3.DTO.Author; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using cursach_3.Service.AuthorService;  // Установка связи с сервисом авторов

namespace cursach_3.Controllers
{
    [ApiController]
    [Route("Authors")] // Путь для запроса в Swagger
    public class AuthorController(IAuthorService AuthorService) : Controller // Контроллеры, передающие запрос в сервис авторов
    {
        [HttpGet]  // Тип автора
        public JsonResult GetAuthors()   // Запрос на получение данных обо всех авторов в БД
        {
            var authors = AuthorService.GetAuthors(); // создание списка авторов на основе данных, полученных из сервиса
            return Json(authors);  // Возвращение списка авторов в файл Json
        }

        [Route("{Author_ID}")]  // Путь для запроса в Swagger
        [HttpGet]  // Тип запроса
        public IActionResult GetAuthor(long Author_ID)  // Запрос на получение информации об определенном авторе из БД
        {
            var author = AuthorService.GetAuthor(Author_ID);  // Нахождение автора через обращение в сервис авторов
            if (author == null) return NotFound("Author has not found"); // Если такого автора не существует
            return Json(author); // Вывод информации об авторе
        }

        [Route("create")]  // Путь для запроса в Swagger
        [HttpPost]  // Тип запроса
        public JsonResult CreateAuthor(CreateAuthor dto) // Запрос на создание автора в БД
        {
            AuthorService.InsertAuthor(dto); // Обращение к функции создания автора в сервисе авторов
            return Json("New Author has been created");  // Уведомление пользователя о создании автора
        }

        [Route("update")] // Путь для запроса в Swagger
        [HttpPatch] // Тип запроса
        public JsonResult UpdateAuthor(UpdateAuthor dto) // Запрос на обновление информации об авторе в БД
        {
            AuthorService.UpdateAuthor(dto);  // Обращение к функции обновления информации  об авторе в сервисе авторов
            return Json("Author has been updated");
        }

        [Route("delete/{Author_ID}")] // Путь для запроса в Swagger
        [HttpDelete] // Тип запроса
        public JsonResult DeleteAuthor(int Author_ID)  // Запрос на удаление автора из БД
        {
            AuthorService.DeleteAuthor(Author_ID); // Обращение к функциии удаления автора в сервисе авторов
            return Json("Author has been deleted");
        }
    }
}
