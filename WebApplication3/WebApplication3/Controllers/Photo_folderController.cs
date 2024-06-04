using cursach_3.DTO.Photo_folder; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using cursach_3.Service.Photo_folderService;

namespace cursach_3.Controllers
{
    [ApiController]
    [Route("Photo_folders")]
    public class Photo_folderController(IPhoto_folderService Photo_folderService) : Controller // Контроллеры, передающие запрос в сервис авторов
    {
        [HttpGet]  // Тип автора
        public JsonResult GetPhoto_folders()   // Запрос на получение данных обо всех авторов в БД
        {
            var photo_folders = Photo_folderService.GetPhoto_folders(); // создание списка авторов на основе данных, полученных из сервиса
            return Json(photo_folders);  // Возвращение списка авторов в файл Json
        }

        [Route("{Photo_folder_ID}")]  // Путь для запроса в Swagger
        [HttpGet]  // Тип запроса
        public IActionResult GetPhoto_folder(long Photo_folder_ID)  // Запрос на получение информации об определенном авторе из БД
        {
            var photo_folder = Photo_folderService.GetPhoto_folder(Photo_folder_ID);  // Нахождение автора через обращение в сервис авторов
            if (photo_folder == null) return NotFound("Photo_folder has not found"); // Если такого автора не существует
            return Json(photo_folder); // Вывод информации об авторе
        }

        [Route("create")]  // Путь для запроса в Swagger
        [HttpPost]  // Тип запроса
        public JsonResult CreatePhoto_folder(CreatePhoto dto) // Запрос на создание автора в БД
        {
            Photo_folderService.InsertPhoto_folder(dto); // Обращение к функции создания автора в сервисе авторов
            return Json("New Photo_folder has been created");  // Уведомление пользователя о создании автора
        }

        [Route("update")] // Путь для запроса в Swagger
        [HttpPatch] // Тип запроса
        public JsonResult UpdatePhoto_folder(UpdatePhoto dto) // Запрос на обновление информации об авторе в БД
        {
            Photo_folderService.UpdatePhoto_folder(dto);  // Обращение к функции обновления информации  об авторе в сервисе авторов
            return Json("Photo_folder has been updated");
        }

        [Route("delete/{Photo_folder_ID}")] // Путь для запроса в Swagger
        [HttpDelete] // Тип запроса
        public JsonResult DeletePhoto_folder(long Photo_folder_ID)  // Запрос на удаление автора из БД
        {
            Photo_folderService.DeletePhoto_folder(Photo_folder_ID); // Обращение к функциии удаления автора в сервисе авторов
            return Json("Photo_folder has been deleted");
        }
    }
}
