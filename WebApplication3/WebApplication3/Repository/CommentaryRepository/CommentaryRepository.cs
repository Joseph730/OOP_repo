using cursach_3.DATA; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;
using cursach_3.DTO.User;
using cursach_3.DTO.Commentary;
using cursach_3.Repository.Migrations;
using Microsoft.SqlServer.Server;

namespace cursach_3.Repository.CommentaryRepository
{
    public class CommentaryRepository(ApplicationContext context) : ICommentaryRepository // Логика взаимодействий с репозиторием авторов
    {
        private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
        private DbSet<Commentary_DATA> _commentaries = context.Set<Commentary_DATA>(); // Получение списка авторов из БД

        public CommentaryDTO Get(long Commentary_ID) // Получение одного автора из БД
        {
            var commentary = _commentaries.Include(commentary => commentary.User).SingleOrDefault(f => f.Commentary_ID == Commentary_ID); // Нахождение автора по его ID в общем списке
            if (commentary == null) return null; // Если автора не существует
            var user = new UserDTO()
            {
                User_ID = commentary.User_ID,
                User_Email = commentary.User.User_Email,
                User_Password = commentary.User.User_Password = "fffuuuuss",
                User_URL = commentary.User.User_URL,
                User_NickName = commentary.User.User_NickName
            };


            return new CommentaryDTO  // Создание и вывод объекта длч передачи данных найденного автора  
            {
                Commentary_ID = commentary.Commentary_ID,
                Topic_ID = commentary.Topic_ID,
                Thread_ID = commentary.Thread_ID,
                User_ID = commentary.User_ID,
                Creation_Date = commentary.Creation_Date,
                Commentary_size = commentary.Commentary_size,
                Article_ID = commentary.Article_ID,
                User = user
            };  // Присваивание объекту для передачи данных всех свойств искомого автора
        }

        public List<CommentaryDTO> GetCommentaries()  // Получение всех авторов из БД
        {
            var commentaries = _commentaries.ToList(); // Создание общего списка авторов, содержащихся в БД
            List<CommentaryDTO> lcommentaries = new List<CommentaryDTO>(); // Создание списка объектов для транспортировки данных всех авторов из БД

            foreach (var commentary in commentaries) //  Циклическое заполнение объектов для транспортировки
            {
                lcommentaries.Add(new CommentaryDTO
                {
                    Commentary_ID = commentary.Commentary_ID,
                    Topic_ID = commentary.Topic_ID,
                    Thread_ID = commentary.Thread_ID,
                    User_ID = commentary.User_ID,
                    Creation_Date = commentary.Creation_Date,
                    Commentary_size = commentary.Commentary_size,
                    Article_ID = commentary.Article_ID
                }); // Заполнение объектов для транспортировки
            }
            return lcommentaries; // Вывод списка авторов пользователю
        }


        public void Insert(CreateCommentary dto)  // Вставка нового автора через объект для транспортировки в БД
        {
            Commentary_DATA commentary = new Commentary_DATA() // Создание нового автора в БД
            {
                Topic_ID = dto.Topic_ID,
                Thread_ID = dto.Thread_ID,
                User_ID = dto.User_ID,
                Creation_Date = dto.Creation_Date,
                Commentary_size = dto.Commentary_size,
                Article_ID = dto.Article_ID
            }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
            _commentaries.Add(commentary); // Добавление нового автора в общий список авторов в БД
            context.SaveChanges(); // Сохранение изменений, внесенных в БД
        }

        public void Update(UpdateCommentary dto) // Обновление информации о каком-либо авторе из БД
        {
            var commentary = _commentaries.SingleOrDefault(a => a.Commentary_ID == dto.Commentary_ID); // Нахождение искомого автора в общем списке авторов из БД
            if (commentary == null) return; // Если искомого автора не существует

            commentary.Topic_ID = dto.Topic_ID;
            commentary.Thread_ID = dto.Thread_ID;
            commentary.User_ID = dto.User_ID;
            commentary.Creation_Date = dto.Creation_Date;
            commentary.Commentary_size = dto.Commentary_size;
            commentary.Article_ID = dto.Article_ID;
            // Присваивание искомому автору свойств, введенных пользователем, через объект для трванспортировки

            _commentaries.Update(commentary); // Внесение изменений в общий список авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void Delete(long Commentary_ID) // Удаление автора ищ БД по указанному ID
        {
            var commentary = _commentaries.SingleOrDefault(a => a.Commentary_ID == Commentary_ID);  // Нахождение указанного автора в общем списке авторов из БД
            if (commentary == null) return; // Если искомого автора не существует
            _commentaries.Remove(commentary); // Удаление автора из общего списка авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void SaveChanges() // Сохранение внесенных изменений в БД
        {
            context.SaveChanges();  // Сохранение внесенных изменений в БД
        }
    }
}
