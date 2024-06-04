using cursach_3.DATA;
using cursach_3.DTO.User; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;
using cursach_3.DTO.Commentary;
using cursach_3.Repository.UserRepository;
using cursach_3.Repository.Migrations;

namespace cursach_3.Repository.UserRepository
{
    public class UserRepository(ApplicationContext context) : IUserRepository // Логика взаимодействий с репозиторием авторов
    {
        private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
        private DbSet<User_DATA> _users = context.Set<User_DATA>(); // Получение списка авторов из БД

        public UserDTO Get(long User_ID) // Получение одного автора из БД
        {
            var user = _users.SingleOrDefault(f => f.User_ID == User_ID); // Нахождение автора по его ID в общем списке
            if (user == null) return null; // Если автора не существует
            return new UserDTO  // Создание и вывод объекта длч передачи данных найденного автора  
            {
                User_ID = user.User_ID,
                User_Email = user.User_Email,
                User_Password = user.User_Password,
                User_URL = user.User_URL,
                User_NickName = user.User_NickName
            };  // Присваивание объекту для передачи данных всех свойств искомого автора
        }

        public List<UserDTO> GetUsers()  // Получение всех авторов из БД
        {
            var users = _users.ToList(); // Создание общего списка авторов, содержащихся в БД
            List<UserDTO> lusers = new List<UserDTO>(); // Создание списка объектов для транспортировки данных всех авторов из БД

            foreach (var user in users) //  Циклическое заполнение объектов для транспортировки
            {
                lusers.Add(new UserDTO
                {
                    User_ID = user.User_ID,
                    User_Email = user.User_Email,
                    User_Password = user.User_Password,
                    User_URL = user.User_URL,
                    User_NickName = user.User_NickName
                }); // Заполнение объектов для транспортировки
            }
            return lusers; // Вывод списка авторов пользователю
        }


        public void Insert(CreateUser dto)  // Вставка нового автора через объект для транспортировки в БД
        {
            User_DATA user = new User_DATA() // Создание нового автора в БД
            {
                User_Email = dto.User_Email,
                User_Password = dto.User_Password,
                User_URL = dto.User_URL,
                User_NickName = dto.User_NickName
            }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
            _users.Add(user); // Добавление нового автора в общий список авторов в БД
            context.SaveChanges(); // Сохранение изменений, внесенных в БД
        }

        public void Update(UpdateUser dto) // Обновление информации о каком-либо авторе из БД
        {
            var user = _users.SingleOrDefault(a => a.User_ID == dto.User_ID); // Нахождение искомого автора в общем списке авторов из БД
            if (user == null) return; // Если искомого автора не существует

            user.User_Email = dto.User_Email;
            user.User_Password = dto.User_Password;
            user.User_URL = dto.User_URL;
            user.User_NickName = dto.User_NickName;
            // Присваивание искомому автору свойств, введенных пользователем, через объект для трванспортировки

            _users.Update(user); // Внесение изменений в общий список авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void Delete(long User_ID) // Удаление автора ищ БД по указанному ID
        {
            var user = _users.SingleOrDefault(a => a.User_ID == User_ID);  // Нахождение указанного автора в общем списке авторов из БД
            if (user == null) return; // Если искомого автора не существует
            _users.Remove(user); // Удаление автора из общего списка авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void SaveChanges() // Сохранение внесенных изменений в БД
        {
            context.SaveChanges();  // Сохранение внесенных изменений в БД
        }
    }
}
