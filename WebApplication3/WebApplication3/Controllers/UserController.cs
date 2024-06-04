using cursach_3.DTO.User; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using cursach_3.Service.UserService;

namespace cursach_3.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController(IUserService UserService) : Controller // Контроллеры, передающие запрос в сервис авторов
    {
        [HttpGet]  // Тип автора
        public JsonResult GetUsers()   // Запрос на получение данных обо всех авторов в БД
        {
            var users = UserService.GetUsers(); // создание списка авторов на основе данных, полученных из сервиса
            return Json(users);  // Возвращение списка авторов в файл Json
        }

        [Route("{User_ID}")]  // Путь для запроса в Swagger
        [HttpGet]  // Тип запроса
        public IActionResult GetUser(long User_ID)  // Запрос на получение информации об определенном авторе из БД
        {
            var user = UserService.GetUser(User_ID);  // Нахождение автора через обращение в сервис авторов
            if (user == null) return NotFound("User has not found"); // Если такого автора не существует
            return Json(user); // Вывод информации об авторе
        }

        [Route("create")]  // Путь для запроса в Swagger
        [HttpPost]  // Тип запроса
        public JsonResult CreateUser(CreateUser dto) // Запрос на создание автора в БД
        {
            UserService.InsertUser(dto); // Обращение к функции создания автора в сервисе авторов
            return Json("New User has been created");  // Уведомление пользователя о создании автора
        }

        [Route("update")] // Путь для запроса в Swagger
        [HttpPatch] // Тип запроса
        public JsonResult UpdateUser(UpdateUser dto) // Запрос на обновление информации об авторе в БД
        {
            UserService.UpdateUser(dto);  // Обращение к функции обновления информации  об авторе в сервисе авторов
            return Json("User has been updated");
        }

        [Route("delete/{User_ID}")] // Путь для запроса в Swagger
        [HttpDelete] // Тип запроса
        public JsonResult DeleteUser(long User_ID)  // Запрос на удаление автора из БД
        {
            UserService.DeleteUser(User_ID); // Обращение к функциии удаления автора в сервисе авторов
            return Json("User has been deleted");
        }
    }
}
