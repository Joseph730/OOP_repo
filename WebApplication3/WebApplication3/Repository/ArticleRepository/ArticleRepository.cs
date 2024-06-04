using cursach_3.DATA;
using Microsoft.EntityFrameworkCore;
using cursach_3.Repository.Migrations;
using cursach_3.DTO.Article;
using cursach_3.DTO.Commentary;

namespace cursach_3.Repository.ArticleRepository
{
    public class ArticleRepository(ApplicationContext context) : IArticleRepository // Логика взаимодействий с репозиторием авторов
    {
        private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
        private DbSet<Article_DATA> _articlies = context.Set<Article_DATA>(); // Получение списка авторов из БД

        public ArticleDTO Get(long Article_ID) // Получение одного автора из БД
        {
            var article = _articlies.Include(article => article.Commentary_List).SingleOrDefault(article => article.Article_ID == Article_ID); // Нахождение автора по его ID в общем списке
            if (article == null) return null; // Если автора не существует

            var commentaries = new List<CommentaryDTO>();
            foreach (var commentary in article.Commentary_List)
            {
                commentaries.Add(new CommentaryDTO()
                {
                    Commentary_ID = commentary.Commentary_ID,
                    Creation_Date = commentary.Creation_Date,
                    Commentary_size = commentary.Commentary_size
                });
            }
            return new ArticleDTO  // Создание и вывод объекта длч передачи данных найденного автора  

            {
                Article_ID = article.Article_ID,
                Author_ID = article.Author_ID,
                Article_Name = article.Article_Name,
                Category_Name = article.Category_Name,
                Rating = article.Rating,
                Creation_Date = article.Creation_Date,
                Commentary_List = commentaries
            };// Присваивание объекту для передачи данных всех свойств искомого автора  
        }
    


        public List<ArticleDTO> GetArticlies()  // Получение всех авторов из БД
        {
            var articlies = _articlies.ToList(); // Создание общего списка авторов, содержащихся в БД
            List<ArticleDTO> larticlies = new List<ArticleDTO>(); // Создание списка объектов для транспортировки данных всех авторов из БД

            foreach (var article in articlies) //  Циклическое заполнение объектов для транспортировки
            {
                larticlies.Add(new ArticleDTO
                {
                    Article_ID = article.Article_ID,
                    Author_ID = article.Author_ID,
                    Article_Name = article.Article_Name,
                    Category_Name = article.Category_Name,
                    Rating = article.Rating,
                    Creation_Date = article.Creation_Date,
                    Photo_Folder_ID = article.Photo_folder_ID
                }); // Заполнение объектов для транспортировки
            }
            return larticlies; // Вывод списка авторов пользователю
        }


        public void Insert(CreateArticle dto)  // Вставка нового автора через объект для транспортировки в БД
        {
            Article_DATA article = new Article_DATA // Создание нового автора в БД
            {
                
                Author_ID = dto.Author_ID,
                Article_Name = dto.Article_Name,
                Category_Name = dto.Category_Name,
                Rating = dto.Rating,
                Creation_Date = dto.Creation_Date,
                Photo_folder_ID = dto.Photo_Folder_ID
            }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
            _articlies.Add(article); // Добавление нового автора в общий список авторов в БД
            context.SaveChanges(); // Сохранение изменений, внесенных в БД
        }

        public void Update(UpdateArticle dto) // Обновление информации о каком-либо авторе из БД
        {
            var article = _articlies.SingleOrDefault(a => a.Article_ID == dto.Article_ID); // Нахождение искомого автора в общем списке авторов из БД
            if (article == null) return; // Если искомого автора не существует

            article.Author_ID = dto.Author_ID;
            article.Article_Name = dto.Article_Name;
            article.Category_Name = dto.Category_Name;
            article.Rating = dto.Rating;
            article.Creation_Date = dto.Creation_Date;
            article.Photo_folder_ID = dto.Photo_Folder_ID;
            // Присваивание искомому автору свойств, введенных пользователем, через объект для трванспортировки

            _articlies.Update(article); // Внесение изменений в общий список авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void Delete(long Article_ID) // Удаление автора ищ БД по указанному ID
        {
            var article = _articlies.SingleOrDefault(a => a.Article_ID == Article_ID);  // Нахождение указанного автора в общем списке авторов из БД
            if (article == null) return; // Если искомого автора не существует
            _articlies.Remove(article); // Удаление автора из общего списка авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void SaveChanges() // Сохранение внесенных изменений в БД
        {
            context.SaveChanges();  // Сохранение внесенных изменений в БД
        }
    }
}
