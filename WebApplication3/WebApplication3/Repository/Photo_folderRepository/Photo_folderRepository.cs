using cursach_3.DATA;
using cursach_3.DTO.Photo_folder; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;
using cursach_3.Repository.Migrations;
using Microsoft.SqlServer.Server;
using cursach_3.DTO.Author;
using cursach_3.DTO.Article;

namespace cursach_3.Repository.Photo_folderRepository
{
    public class Photo_folderRepository(ApplicationContext context) : IPhoto_folderRepository // Логика взаимодействий с репозиторием авторов
    {
        private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
        private DbSet<Photo_folder_DATA> _photo_folders = context.Set<Photo_folder_DATA>(); // Получение списка авторов из БД

        public PhotoDTO Get(long Photo_folder_ID) // Получение одного автора из БД
        {
            var photo_folder = _photo_folders
                .Include(photo_folder => photo_folder.Author)
                .Include(photo_folder => photo_folder.Article)
                .SingleOrDefault(f => f.Photo_folder_ID == Photo_folder_ID); // Нахождение автора по его ID в общем списке
            if (photo_folder == null) return null; // Если автора не существует
            var author = new AuthorDTO()
            {
                Author_ID = photo_folder.Author.Author_ID,
                User_ID = photo_folder.Author.User_ID,
                Photo_folder_ID = photo_folder.Author.Photo_folder_ID,
                Author_URL = photo_folder.Author.Author_URL,
                Author_Name = photo_folder.Author.Author_Name
            };
            var article = new ArticleDTO()
            {
                Article_ID = photo_folder.Article.Article_ID,
                Author_ID = photo_folder.Article.Author_ID,
                Article_Name = photo_folder.Article.Article_Name,
                Category_Name = photo_folder.Article.Category_Name,
                Rating = photo_folder.Article.Rating,
                Creation_Date = photo_folder.Article.Creation_Date,
                Photo_Folder_ID = photo_folder.Article.Photo_folder_ID
            };
            



            return new PhotoDTO  // Создание и вывод объекта длч передачи данных найденного автора  
            {
                Photo_folder_ID = photo_folder.Photo_folder_ID,
                Photo_folder_Desc = photo_folder.Photo_folder_Desc,
                Photo_folder_Name = photo_folder.Photo_folder_Name,
                Photo_folder_Path = photo_folder.Photo_folder_Path,
                Article = article,
                Author = author
                
            };  // Присваивание объекту для передачи данных всех свойств искомого автора
        }

        public List<PhotoDTO> GetPhoto_folders()  // Получение всех авторов из БД
        {
            var photo_folders = _photo_folders.ToList(); // Создание общего списка авторов, содержащихся в БД
            List<PhotoDTO> lphoto_folders = new List<PhotoDTO>(); // Создание списка объектов для транспортировки данных всех авторов из БД

            foreach (var photo_folder in photo_folders) //  Циклическое заполнение объектов для транспортировки
            {
                lphoto_folders.Add(new PhotoDTO
                {
                    Photo_folder_ID = photo_folder.Photo_folder_ID,
                    Photo_folder_Desc = photo_folder.Photo_folder_Desc,
                    Photo_folder_Name = photo_folder.Photo_folder_Name,
                    Photo_folder_Path = photo_folder.Photo_folder_Path
                }); // Заполнение объектов для транспортировки
            }
            return lphoto_folders; // Вывод списка авторов пользователю
        }


        public void Insert(CreatePhoto dto)  // Вставка нового автора через объект для транспортировки в БД
        {
            Photo_folder_DATA photo_folder = new Photo_folder_DATA() // Создание нового автора в БД
            {
                Photo_folder_Desc = dto.Photo_folder_Desc,
                Photo_folder_Name = dto.Photo_folder_Name,
                Photo_folder_Path = dto.Photo_folder_Path
            }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
            _photo_folders.Add(photo_folder); // Добавление нового автора в общий список авторов в БД
            context.SaveChanges(); // Сохранение изменений, внесенных в БД
        }

        public void Update(UpdatePhoto dto) // Обновление информации о каком-либо авторе из БД
        {
            var photo_folder = _photo_folders.SingleOrDefault(a => a.Photo_folder_ID == dto.Photo_folder_ID); // Нахождение искомого автора в общем списке авторов из БД
            if (photo_folder == null) return; // Если искомого автора не существует

            photo_folder.Photo_folder_Desc = dto.Photo_folder_Desc;
            photo_folder.Photo_folder_Name = dto.Photo_folder_Name;
            photo_folder.Photo_folder_Path = dto.Photo_folder_Path;
            // Присваивание искомому автору свойств, введенных пользователем, через объект для трванспортировки

            _photo_folders.Update(photo_folder); // Внесение изменений в общий список авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void Delete(long Photo_folder_ID) // Удаление автора ищ БД по указанному ID
        {
            var photo_folder = _photo_folders.SingleOrDefault(a => a.Photo_folder_ID == Photo_folder_ID);  // Нахождение указанного автора в общем списке авторов из БД
            if (photo_folder == null) return; // Если искомого автора не существует
            _photo_folders.Remove(photo_folder); // Удаление автора из общего списка авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void SaveChanges() // Сохранение внесенных изменений в БД
        {
            context.SaveChanges();  // Сохранение внесенных изменений в БД
        }
    }
}
