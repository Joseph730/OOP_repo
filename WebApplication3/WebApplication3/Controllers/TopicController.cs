using cursach_3.DTO.Topic; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using cursach_3.Service.TopicService;

namespace cursach_3.Controllers
{
    [ApiController]
    [Route("Topics")]
    public class TopicController(ITopicService TopicService) : Controller // Контроллеры, передающие запрос в сервис авторов
    {
        [HttpGet]  // Тип автора
        public JsonResult GetTopics()   // Запрос на получение данных обо всех авторов в БД
        {
            var topics = TopicService.GetTopics(); // создание списка авторов на основе данных, полученных из сервиса
            return Json(topics);  // Возвращение списка авторов в файл Json
        }

        [Route("{Topic_ID}")]  // Путь для запроса в Swagger
        [HttpGet]  // Тип запроса
        public IActionResult GetTopic(long Topic_ID)  // Запрос на получение информации об определенном авторе из БД
        {
            var topic = TopicService.GetTopic(Topic_ID);  // Нахождение автора через обращение в сервис авторов
            if (topic == null) return NotFound("Topic has not found"); // Если такого автора не существует
            return Json(topic); // Вывод информации об авторе
        }

        [Route("create")]  // Путь для запроса в Swagger
        [HttpPost]  // Тип запроса
        public JsonResult CreateTopic( CreateTopic dto) // Запрос на создание автора в БД
        {
            TopicService.InsertTopic(dto); // Обращение к функции создания автора в сервисе авторов
            return Json("New Topic has been created");  // Уведомление пользователя о создании автора
        }

        [Route("update")] // Путь для запроса в Swagger
        [HttpPatch] // Тип запроса
        public JsonResult UpdateTopic(UpdateTopic dto) // Запрос на обновление информации об авторе в БД
        {
            TopicService.UpdateTopic(dto);  // Обращение к функции обновления информации  об авторе в сервисе авторов
            return Json("Topic has been updated");
        }

        [Route("delete/{Topic_ID}")] // Путь для запроса в Swagger
        [HttpDelete] // Тип запроса
        public JsonResult DeleteTopic(long Topic_ID)  // Запрос на удаление автора из БД
        {
            TopicService.DeleteTopic(Topic_ID); // Обращение к функциии удаления автора в сервисе авторов
            return Json("Topic has been deleted");
        }
    }
}
