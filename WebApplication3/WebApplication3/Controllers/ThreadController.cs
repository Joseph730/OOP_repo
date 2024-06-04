using cursach_3.DTO.Thread; // Установка связи с объектами для транспортировки 
using cursach_3.Service.ThreadService;
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using cursach_3.Service.ThreadService;
using System.Threading;

namespace cursach_3.Controllers
{
    [ApiController]
    [Route("Threads")]
    public class ThreadController(IThreadService ThreadService) : Controller // Контроллеры, передающие запрос в сервис авторов
    {
        [HttpGet]  // Тип автора
        public JsonResult GetThreads()   // Запрос на получение данных обо всех авторов в БД
        {
            var threads = ThreadService.GetThreads(); // создание списка авторов на основе данных, полученных из сервиса
            return Json(threads);  // Возвращение списка авторов в файл Json
        }

        [Route("{Thread_ID}")]  // Путь для запроса в Swagger
        [HttpGet]  // Тип запроса
        public IActionResult GetThread(long Thread_ID)  // Запрос на получение информации об определенном авторе из БД
        {
            var thread = ThreadService.GetThread(Thread_ID);  // Нахождение автора через обращение в сервис авторов
            if (thread == null) return NotFound("Thread has not found"); // Если такого автора не существует
            return Json(thread); // Вывод информации об авторе
        }

        [Route("create")]  // Путь для запроса в Swagger
        [HttpPost]  // Тип запроса
        public JsonResult CreateThread(CreateThread dto) // Запрос на создание автора в БД
        {
            ThreadService.InsertThread(dto); // Обращение к функции создания автора в сервисе авторов
            return Json("New Thread has been created");  // Уведомление пользователя о создании автора
        }

        [Route("update")] // Путь для запроса в Swagger
        [HttpPatch] // Тип запроса
        public JsonResult UpdateThread(UpdateThread dto) // Запрос на обновление информации об авторе в БД
        {
            ThreadService.UpdateThread(dto);  // Обращение к функции обновления информации  об авторе в сервисе авторов
            return Json("Thread has been updated");
        }

        [Route("delete/{Thread_ID}")] // Путь для запроса в Swagger
        [HttpDelete] // Тип запроса
        public JsonResult DeleteThread(long Thread_ID)  // Запрос на удаление автора из БД
        {
            ThreadService.DeleteThread(Thread_ID); // Обращение к функциии удаления автора в сервисе авторов
            return Json("Thread has been deleted");
        }
    }
}
