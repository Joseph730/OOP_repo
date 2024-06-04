using cursach_3.DATA;
using cursach_3.DTO.File_Archive; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;
using cursach_3.Repository.Migrations;
using Microsoft.SqlServer.Server;
using cursach_3.DTO.Topic;
using cursach_3.DTO.Thread;
using cursach_3.DTO.Commentary;
using cursach_3.DTO.Article;


namespace cursach_3.Repository.File_ArchiveRepository
{
    public class File_ArchiveRepository(ApplicationContext context) : IFile_ArchiveRepository // Логика взаимодействий с репозиторием авторов
    {
        private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
        private DbSet<File_Archive_DATA> _file_archives = context.Set<File_Archive_DATA>(); // Получение списка авторов из БД

        public File_ArchiveDTO Get(long File_Archive_ID) // Получение одного автора из БД
        {
            var file_archive = _file_archives
                .Include(file_archive => file_archive.Topic)
                .Include(file_archive => file_archive.Thread)
                .Include(file_archive => file_archive.Commentary)
                .Include(file_archive => file_archive.Article)
                .SingleOrDefault(f => f.File_Archive_ID == File_Archive_ID); // Нахождение автора по его ID в общем списке
            if (file_archive == null) return null; // Если автора не существует
            var topic = new TopicDTO()
            {
                Topic_ID = file_archive.Topic.Topic_ID,
                Topic_Name = file_archive.Topic.Topic_Name,
                Thread_ID = file_archive.Topic.Thread_ID,
                Topic_URL = file_archive.Topic.Topic_URL,
                Topic_Desc = file_archive.Topic.Topic_Desc
            };
            var thread = new ThreadDTO()
            {
                Thread_ID = file_archive.Thread.Thread_ID,
                Thread_Desc = file_archive.Thread.Thread_Desc,
                Thread_Name = file_archive.Thread.Thread_Name,
                Author_ID = file_archive.Thread.Author_ID,
                Rating = file_archive.Thread.Rating,
                Thread_URL = file_archive.Thread.Thread_URL
            };
            var commentary = new CommentaryDTO()
            {
                Commentary_ID = file_archive.Commentary.Commentary_ID,
                Topic_ID = file_archive.Commentary.Topic_ID,
                Thread_ID = file_archive.Commentary.Thread_ID,
                User_ID = file_archive.Commentary.User_ID,
                Creation_Date = file_archive.Commentary.Creation_Date,
                Commentary_size = file_archive.Commentary.Commentary_size,
                Article_ID = file_archive.Commentary.Article_ID
            };
            var article = new ArticleDTO()
            {
                Article_ID = file_archive.Article.Article_ID,
                Author_ID = file_archive.Article.Author_ID,
                Article_Name = file_archive.Article.Article_Name,
                Category_Name = file_archive.Article.Category_Name,
                Rating = file_archive.Article.Rating,
                Creation_Date = file_archive.Article.Creation_Date,
                Photo_Folder_ID = file_archive.Article.Photo_folder_ID
            };



            return new File_ArchiveDTO  // Создание и вывод объекта длч передачи данных найденного автора  
            {
                File_Archive_ID = file_archive.File_Archive_ID,
                Topic_ID = file_archive.Topic_ID,
                Thread_ID = file_archive.Thread_ID,
                Commentary_ID = file_archive.Commentary_ID,
                Files_Archive_Desc = file_archive.Files_Archive_Desc,
                File_Path = file_archive.File_Path,
                Article_ID = file_archive.Article_ID,
                Article = article,
                Commentary = commentary,
                Thread = thread
            };  // Присваивание объекту для передачи данных всех свойств искомого автора
        }

        public List<File_ArchiveDTO> GetFile_Archives()  // Получение всех авторов из БД
        {
            var file_archives = _file_archives.ToList(); // Создание общего списка авторов, содержащихся в БД
            List<File_ArchiveDTO> lfile_archives = new List<File_ArchiveDTO>(); // Создание списка объектов для транспортировки данных всех авторов из БД

            foreach (var file_archive in file_archives) //  Циклическое заполнение объектов для транспортировки
            {
                lfile_archives.Add(new File_ArchiveDTO
                {
                    File_Archive_ID = file_archive.File_Archive_ID,
                    Topic_ID = file_archive.Topic_ID,
                    Thread_ID = file_archive.Thread_ID,
                    Commentary_ID = file_archive.Commentary_ID,
                    Files_Archive_Desc = file_archive.Files_Archive_Desc,
                    File_Path = file_archive.File_Path,
                    Article_ID = file_archive.Article_ID
                }); // Заполнение объектов для транспортировки
            }
            return lfile_archives; // Вывод списка авторов пользователю
        }


        public void Insert(CreateFile_Archive dto)  // Вставка нового автора через объект для транспортировки в БД
        {
            File_Archive_DATA file_archive = new File_Archive_DATA() // Создание нового автора в БД
            {
                Topic_ID = dto.Topic_ID,
                Thread_ID = dto.Thread_ID,
                Commentary_ID = dto.Commentary_ID,
                Files_Archive_Desc = dto.Files_Archive_Desc,
                File_Path = dto.File_Path,
                Article_ID = dto.Article_ID
            }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
            _file_archives.Add(file_archive); // Добавление нового автора в общий список авторов в БД
            context.SaveChanges(); // Сохранение изменений, внесенных в БД
        }

        public void Update(UpdateFile_Archive dto) // Обновление информации о каком-либо авторе из БД
        {
            var file_archive = _file_archives.SingleOrDefault(a => a.File_Archive_ID == dto.File_Archive_ID); // Нахождение искомого автора в общем списке авторов из БД
            if (file_archive == null) return; // Если искомого автора не существует

            file_archive.Topic_ID = dto.Topic_ID;
            file_archive.Thread_ID = dto.Thread_ID;
            file_archive.Commentary_ID = dto.Commentary_ID;
            file_archive.Files_Archive_Desc = dto.Files_Archive_Desc;
            file_archive.File_Path = dto.File_Path;
            file_archive.Article_ID = dto.Article_ID;
            // Присваивание искомому автору свойств, введенных пользователем, через объект для трванспортировки

            _file_archives.Update(file_archive); // Внесение изменений в общий список авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void Delete(long File_Archive_ID) // Удаление автора ищ БД по указанному ID
        {
            var file_archive = _file_archives.SingleOrDefault(a => a.File_Archive_ID == File_Archive_ID);  // Нахождение указанного автора в общем списке авторов из БД
            if (file_archive == null) return; // Если искомого автора не существует
            _file_archives.Remove(file_archive); // Удаление автора из общего списка авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void SaveChanges() // Сохранение внесенных изменений в БД
        {
            context.SaveChanges();  // Сохранение внесенных изменений в БД
        }
    }
}
