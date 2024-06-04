using cursach_3.DTO.File_Archive; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using cursach_3.Service.File_ArchiveService;

namespace cursach_3.Controllers
{

    [ApiController]
    [Route("File_Archives")]

    public class File_ArchiveController(IFile_ArchiveService File_ArchiveService) : Controller // Контроллеры, передающие запрос в сервис авторов
    {
        [HttpGet]  // Тип автора
        public JsonResult GetFile_Archives()   // Запрос на получение данных обо всех авторов в БД
        {
            var file_archives = File_ArchiveService.GetFile_Archives(); // создание списка авторов на основе данных, полученных из сервиса
            return Json(file_archives);  // Возвращение списка авторов в файл Json
        }

        [Route("{File_Archive_ID}")]  // Путь для запроса в Swagger
        [HttpGet]  // Тип запроса
        public IActionResult GetFile_Archive(long File_Archive_ID)  // Запрос на получение информации об определенном авторе из БД
        {
            var file_archive = File_ArchiveService.GetFile_Archive(File_Archive_ID);  // Нахождение автора через обращение в сервис авторов
            if (file_archive == null) return NotFound("File_Archive has not found"); // Если такого автора не существует
            return Json(file_archive); // Вывод информации об авторе
        }

        [Route("create")]  // Путь для запроса в Swagger
        [HttpPost]  // Тип запроса
        public JsonResult CreateFile_Archive(CreateFile_Archive dto) // Запрос на создание автора в БД
        {
            File_ArchiveService.InsertFile_Archive(dto); // Обращение к функции создания автора в сервисе авторов
            return Json("New File_Archive has been created");  // Уведомление пользователя о создании автора
        }

        [Route("update")] // Путь для запроса в Swagger
        [HttpPatch] // Тип запроса
        public JsonResult UpdateFile_Archive(UpdateFile_Archive dto) // Запрос на обновление информации об авторе в БД
        {
            File_ArchiveService.UpdateFile_Archive(dto);  // Обращение к функции обновления информации  об авторе в сервисе авторов
            return Json("File_Archive has been updated");
        }

        [Route("delete/{File_Archive_ID}")] // Путь для запроса в Swagger
        [HttpDelete] // Тип запроса
        public JsonResult DeleteFile_Archive(long File_Archive_ID)  // Запрос на удаление автора из БД
        {
            File_ArchiveService.DeleteFile_Archive(File_Archive_ID); // Обращение к функциии удаления автора в сервисе авторов
            return Json("File_Archive has been deleted");
        }
    }
}
