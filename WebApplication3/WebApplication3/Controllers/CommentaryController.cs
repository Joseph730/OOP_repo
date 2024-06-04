using cursach_3.DTO.Commentary; // Установка связи с объектами для транспортировки 
using cursach_3.Service.CommentaryService;
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using cursach_3.Service.CommentaryService;  // Установка связи с сервисом авторов

namespace cursach_3.Controllers
{
    [ApiController]
    [Route("Commentaries")]

    public class CommentaryController(ICommentaryService CommentaryService) : Controller // Контроллеры, передающие запрос в сервис авторов
    {
        [HttpGet]  // Тип автора
        public JsonResult GetCommentaries()   // Запрос на получение данных обо всех авторов в БД
        {
            var commentaries = CommentaryService.GetCommentaries(); // создание списка авторов на основе данных, полученных из сервиса
            return Json(commentaries);  // Возвращение списка авторов в файл Json
        }

        [Route("{Commentary_ID}")]  // Путь для запроса в Swagger
        [HttpGet]  // Тип запроса
        public IActionResult GetCommentary(long Commentary_ID)  // Запрос на получение информации об определенном авторе из БД
        {
            var commentary = CommentaryService.GetCommentary(Commentary_ID);  // Нахождение автора через обращение в сервис авторов
            if (commentary == null) return NotFound("Commentary has not found"); // Если такого автора не существует
            return Json(commentary); // Вывод информации об авторе
        }

        [Route("create")]  // Путь для запроса в Swagger
        [HttpPost]  // Тип запроса
        public JsonResult CreateCommentary(CreateCommentary dto) // Запрос на создание автора в БД
        {
            CommentaryService.InsertCommentary(dto); // Обращение к функции создания автора в сервисе авторов
            return Json("New Commentary has been created");  // Уведомление пользователя о создании автора
        }

        [Route("update")] // Путь для запроса в Swagger
        [HttpPatch] // Тип запроса
        public JsonResult UpdateCommentary(UpdateCommentary dto) // Запрос на обновление информации об авторе в БД
        {
            CommentaryService.UpdateCommentary(dto);  // Обращение к функции обновления информации  об авторе в сервисе авторов
            return Json("Commentary has been updated");
        }

        [Route("delete/{Commentary_ID}")] // Путь для запроса в Swagger
        [HttpDelete] // Тип запроса
        public JsonResult DeleteCommentary(long id)  // Запрос на удаление автора из БД
        {
            CommentaryService.DeleteCommentary(id); // Обращение к функциии удаления автора в сервисе авторов
            return Json("Commentary has been deleted");
        }
    }
}
