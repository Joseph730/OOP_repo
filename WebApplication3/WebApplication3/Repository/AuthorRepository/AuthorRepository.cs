using cursach_3.DATA;
using cursach_3.DTO.Author; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;
using cursach_3.DTO.Thread;
using cursach_3.DTO.Article;

using cursach_3.Repository.Migrations;
using System.Diagnostics.Metrics;

namespace cursach_3.Repository.AuthorRepository
{
    public class AuthorRepository(ApplicationContext context) : IAuthorRepository // Логика взаимодействий с репозиторием авторов
    {
        private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
        private DbSet<Author_DATA> _authors = context.Set<Author_DATA>(); // Получение списка авторов из БД

        public AuthorDTO Get(long Author_ID) // Получение одного автора из БД
        {
            var author = _authors
                .Include(c => c.Article_List) // Обращение к списку авторов книги (Вывод списка через запрос)
                .Include(c => c.Thread_List)
                .SingleOrDefault(c => c.Author_ID == Author_ID); // Нахождение автора по его ID в общем списке

            if (author == null) return null; // Если автора не существует

            var Articles = new List<ArticleDTO>();
            foreach (var article in author.Article_List)
            {
                Articles.Add(new ArticleDTO()
                {
                    Article_ID = article.Article_ID,
                    Article_Name = article.Article_Name,
                    Category_Name = article.Category_Name,
                    Rating = article.Rating,
                    Creation_Date = article.Creation_Date
                });
            }
            var Threads = new List<ThreadDTO>();
            foreach (var thread in author.Thread_List)
            {
                Threads.Add(new ThreadDTO()
                {
                    Thread_ID = thread.Thread_ID,
                    Thread_Desc = thread.Thread_Desc,
                    Thread_Name = thread.Thread_Name,
                    Rating = thread.Rating,
                    Thread_URL = thread.Thread_URL
                });
            }
            return new AuthorDTO  // Создание и вывод объекта длч передачи данных найденного автора  

            {
                Author_ID = author.Author_ID,
                User_ID = author.User_ID,
                Photo_folder_ID = author.Photo_folder_ID,
                Author_URL = author.Author_URL,
                Author_Name = author.Author_Name,
                Article_List = Articles,
                Thread_List = Threads
            };  // Присваивание объекту для передачи данных всех свойств искомого автора

        }









        public List<AuthorDTO> GetAuthors()  // Получение всех авторов из БД
        {
            var authors = _authors.ToList(); // Создание общего списка авторов, содержащихся в БД
            List<AuthorDTO> lauthors = new List<AuthorDTO>(); // Создание списка объектов для транспортировки данных всех авторов из БД
            foreach (var author in authors) //  Циклическое заполнение объектов для транспортировки
            {
                lauthors.Add(new AuthorDTO
                {
                    Author_ID = author.Author_ID,
                    User_ID = author.User_ID,
                    Photo_folder_ID = author.Photo_folder_ID,
                    Author_URL = author.Author_URL,
                    Author_Name = author.Author_Name

                }); // Заполнение объектов для транспортировки
            }


            return lauthors; // Вывод списка авторов пользователю
        }


        public void Insert(CreateAuthor dto)  // Вставка нового автора через объект для транспортировки в БД
        {
            Author_DATA author = new Author_DATA // Создание нового автора в БД
            {
                Author_Name = dto.Author_Name,
                User_ID = dto.User_ID,
                Photo_folder_ID = dto.Photo_folder_ID,
                Author_URL = dto.Author_URL,
            }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
            _authors.Add(author); // Добавление нового автора в общий список авторов в БД
            context.SaveChanges(); // Сохранение изменений, внесенных в БД
        }

        public void Update(UpdateAuthor dto) // Обновление информации о каком-либо авторе из БД
        {
            var author = _authors.SingleOrDefault(a => a.Author_ID == dto.Author_ID); // Нахождение искомого автора в общем списке авторов из БД
            if (author == null) return; // Если искомого автора не существует

            author.Author_Name = dto.Author_Name;
            author.User_ID = dto.User_ID;
            author.Photo_folder_ID = dto.Photo_folder_ID;
            author.Author_URL = dto.Author_URL;
            // Присваивание искомому автору свойств, введенных пользователем, через объект для трванспортировки

            _authors.Update(author); // Внесение изменений в общий список авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void Delete(long Author_ID) // Удаление автора ищ БД по указанному ID
        {
            var author = _authors.SingleOrDefault(a => a.Author_ID == Author_ID);  // Нахождение указанного автора в общем списке авторов из БД
            if (author == null) return; // Если искомого автора не существует
            _authors.Remove(author); // Удаление автора из общего списка авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void SaveChanges() // Сохранение внесенных изменений в БД
        {
            context.SaveChanges();  // Сохранение внесенных изменений в БД
        }
    }
}
