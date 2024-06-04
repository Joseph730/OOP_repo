using cursach_3.DATA;
using cursach_3.DTO.Author; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;
using cursach_3.DTO.Thread;
using cursach_3.DTO.Article;
using cursach_3.DTO.File_Archive;
using cursach_3.DTO.Commentary;
using cursach_3.Repository.Migrations;
using cursach_3.Repository.AuthorRepository;
using cursach_3.DTO.Topic;

namespace cursach_3.Repository.TopicRepository
{
    public class TopicRepository(ApplicationContext context) : ITopicRepository // Логика взаимодействий с репозиторием авторов
    {
        private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
        private DbSet<Topic_DATA> _topics = context.Set<Topic_DATA>(); // Получение списка авторов из БД

        public TopicDTO Get(long Topic_ID) // Получение одного автора из БД
        {
            var topic = _topics
                .Include(c => c.File_List) // Обращение к списку авторов книги (Вывод списка через запрос)
                .Include(c => c.Commentary_List)
                .SingleOrDefault(c => c.Topic_ID == Topic_ID); // Нахождение автора по его ID в общем списке

            if (topic == null) return null; // Если автора не существует

            var File_Lists = new List<File_ArchiveDTO>();
            foreach (var file_list in topic.File_List)
            {
                File_Lists.Add(new File_ArchiveDTO()
                {
                    File_Archive_ID = file_list.File_Archive_ID,
                    Topic_ID = file_list.Topic_ID,
                    Thread_ID = file_list.Thread_ID,
                    Commentary_ID = file_list.Commentary_ID,
                    Files_Archive_Desc = file_list.Files_Archive_Desc,
                    File_Path = file_list.File_Path,
                    Article_ID = file_list.Article_ID
                });
            }

            var Commentary_Lists = new List<CommentaryDTO>();
            foreach (var commentary_list in topic.Commentary_List)
            {
                Commentary_Lists.Add(new CommentaryDTO()
                {
                    Commentary_ID = commentary_list.Commentary_ID,
                    Topic_ID = commentary_list.Topic_ID,
                    Thread_ID = commentary_list.Thread_ID,
                    User_ID = commentary_list.User_ID,
                    Creation_Date = commentary_list.Creation_Date,
                    Commentary_size = commentary_list.Commentary_size,
                    Article_ID = commentary_list.Article_ID
                });
            }
            return new TopicDTO  // Создание и вывод объекта длч передачи данных найденного автора  

            {
                Topic_ID = topic.Topic_ID,
                Topic_Name = topic.Topic_Name,
                Thread_ID = topic.Thread_ID,
                Topic_URL = topic.Topic_URL,
                Topic_Desc = topic.Topic_Desc,
                File_List = File_Lists,
                Commentary_List = Commentary_Lists
            };  // Присваивание объекту для передачи данных всех свойств искомого автора

        }









        public List<TopicDTO> GetTopics()  // Получение всех авторов из БД
        {
            var topics = _topics.ToList(); // Создание общего списка авторов, содержащихся в БД
            List<TopicDTO> ltopics = new List<TopicDTO>(); // Создание списка объектов для транспортировки данных всех авторов из БД
            foreach (var topic in topics) //  Циклическое заполнение объектов для транспортировки
            {
                ltopics.Add(new TopicDTO
                {
                    Topic_ID = topic.Topic_ID,
                    Topic_Name = topic.Topic_Name,
                    Thread_ID = topic.Thread_ID,
                    Topic_URL = topic.Topic_URL,
                    Topic_Desc = topic.Topic_Desc

                }); // Заполнение объектов для транспортировки
            }


            return ltopics; // Вывод списка авторов пользователю
        }


        public void Insert( CreateTopic dto)  // Вставка нового автора через объект для транспортировки в БД
        {
            Topic_DATA topic = new Topic_DATA() // Создание нового автора в БД
            {
                Topic_Name = dto.Topic_Name,
                Thread_ID = dto.Thread_ID,
                Topic_URL = dto.Topic_URL,
                Topic_Desc = dto.Topic_Desc
            }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
            _topics.Add(topic); // Добавление нового автора в общий список авторов в БД
            context.SaveChanges(); // Сохранение изменений, внесенных в БД
        }
        
        
        public void Update(UpdateTopic dto) // Обновление информации о каком-либо авторе из БД
        {
            var topic = _topics.SingleOrDefault(a => a.Topic_ID == dto.Topic_ID); // Нахождение искомого автора в общем списке авторов из БД
            if (topic == null) return; // Если искомого автора не существует

            topic.Topic_Name = dto.Topic_Name;
            topic.Thread_ID = dto.Thread_ID;
            topic.Topic_URL = dto.Topic_URL;
            topic.Topic_Desc = dto.Topic_Desc;
            // Присваивание искомому автору свойств, введенных пользователем, через объект для трванспортировки

            _topics.Update(topic); // Внесение изменений в общий список авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void Delete(long Topic_ID) // Удаление автора ищ БД по указанному ID
        {
            var topic = _topics.SingleOrDefault(a => a.Topic_ID == Topic_ID);  // Нахождение указанного автора в общем списке авторов из БД
            if (topic == null) return; // Если искомого автора не существует
            _topics.Remove(topic); // Удаление автора из общего списка авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void SaveChanges() // Сохранение внесенных изменений в БД
        {
            context.SaveChanges();  // Сохранение внесенных изменений в БД
        }
    }
}
