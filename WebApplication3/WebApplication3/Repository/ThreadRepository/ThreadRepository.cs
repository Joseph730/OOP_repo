using cursach_3.DATA;
using cursach_3.DTO.Topic; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;
using cursach_3.DTO.Thread;
using cursach_3.DTO.Article;
using cursach_3.DTO.Commentary;
using cursach_3.DTO.File_Archive;

using cursach_3.Repository.Migrations;
using cursach_3.DTO.Author;
using cursach_3.Repository.AuthorRepository;

namespace cursach_3.Repository.ThreadRepository;

    public class ThreadRepository(ApplicationContext context) : IThreadRepository // Логика взаимодействий с репозиторием авторов
    {
        private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
        private DbSet<Thread_DATA> _threads = context.Set<Thread_DATA>(); // Получение списка авторов из БД

        public ThreadDTO Get(long Thread_ID) // Получение одного автора из БД
        {
            var thread = _threads
                .Include(c => c.Commentary_List) // Обращение к списку авторов книги (Вывод списка через запрос)
                .Include(c => c.Topic_List)
                .Include(c => c.File_List)
                .SingleOrDefault(c => c.Thread_ID == Thread_ID); // Нахождение автора по его ID в общем списке


            if (thread == null) return null; // Если автора не существует

            var Commentaries = new List<CommentaryDTO>();
            foreach (var commentary in thread.Commentary_List)
            {
                Commentaries.Add(new CommentaryDTO()
                {
                    Commentary_ID = commentary.Commentary_ID,
                    Topic_ID = commentary.Topic_ID,
                    Thread_ID = commentary.Thread_ID,
                    User_ID = commentary.User_ID,
                    Creation_Date = commentary.Creation_Date,
                    Commentary_size = commentary.Commentary_size,
                    Article_ID = commentary.Article_ID
                });
            }

            var Topic_Lists = new List<TopicDTO>();
            foreach (var topic_list in thread.Topic_List)
            {
                Topic_Lists.Add(new TopicDTO()
                {
                    Topic_ID = topic_list.Topic_ID,
                    Topic_Name = topic_list.Topic_Name,
                    Thread_ID = topic_list.Thread_ID,
                    Topic_URL = topic_list.Topic_URL,
                    Topic_Desc = topic_list.Topic_Desc

                });
            }

            var File_Lists = new List<File_ArchiveDTO>();
            foreach (var file_list in thread.File_List)
            {
                File_Lists.Add(new File_ArchiveDTO()
                {
                    File_Archive_ID = file_list.File_Archive_ID,
                    Topic_ID = file_list.Topic_ID,
                    Thread_ID = file_list.Thread_ID,
                    Commentary_ID = file_list.Commentary_ID,
                    Files_Archive_Desc = file_list.Files_Archive_Desc,
                    File_Path = file_list.File_Path
                });
            }
            return new ThreadDTO  // Создание и вывод объекта длч передачи данных найденного автора  

            {
                Thread_ID  = thread.Thread_ID,
                Thread_Desc = thread.Thread_Desc,
                Thread_Name = thread.Thread_Name,
                Author_ID = thread.Author_ID,
                Rating = thread.Rating,
                Thread_URL = thread.Thread_URL,
                Commentary_List = Commentaries,
                File_List = File_Lists,
                Topic_List = Topic_Lists
                 
            };  // Присваивание объекту для передачи данных всех свойств искомого автора

        }


        

        public List<ThreadDTO> GetThreads()  // Получение всех авторов из БД
        {
            var threads = _threads.ToList(); // Создание общего списка авторов, содержащихся в БД
            List<ThreadDTO> lthreads = new List<ThreadDTO>(); // Создание списка объектов для транспортировки данных всех авторов из БД
            foreach (var thread in threads) //  Циклическое заполнение объектов для транспортировки
            {
                lthreads.Add(new ThreadDTO
                {
                    Thread_ID = thread.Thread_ID,
                    Thread_Desc = thread.Thread_Desc,
                    Thread_Name = thread.Thread_Name,
                    Author_ID = thread.Author_ID,
                    Rating = thread.Rating,
                    Thread_URL = thread.Thread_URL

                }); // Заполнение объектов для транспортировки
            }


            return lthreads; // Вывод списка авторов пользователю
        }


        public void Insert(CreateThread dto)  // Вставка нового автора через объект для транспортировки в БД
        {
            Thread_DATA thread = new Thread_DATA // Создание нового автора в БД
            {
                Thread_Desc = dto.Thread_Desc,
                Thread_Name = dto.Thread_Name,
                Author_ID = dto.Author_ID,
                Rating = dto.Rating,
                Thread_URL = dto.Thread_URL
            }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
            _threads.Add(thread); // Добавление нового автора в общий список авторов в БД
            context.SaveChanges(); // Сохранение изменений, внесенных в БД
        }

        public void Update(UpdateThread dto) // Обновление информации о каком-либо авторе из БД
        {
            var thread = _threads.SingleOrDefault(a => a.Thread_ID == dto.Thread_ID); // Нахождение искомого автора в общем списке авторов из БД
            if (thread == null) return; // Если искомого автора не существует

            thread.Thread_Desc = dto.Thread_Desc;
            thread.Thread_Name = dto.Thread_Name;
            thread.Author_ID = dto.Author_ID;
            thread.Rating = dto.Rating;
            thread.Thread_URL = dto.Thread_URL;
            // Присваивание искомому автору свойств, введенных пользователем, через объект для трванспортировки

            _threads.Update(thread); // Внесение изменений в общий список авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void Delete(long Thread_ID) // Удаление автора ищ БД по указанному ID
        {
            var thread = _threads.SingleOrDefault(a => a.Thread_ID == Thread_ID);  // Нахождение указанного автора в общем списке авторов из БД
            if (thread == null) return; // Если искомого автора не существует
            _threads.Remove(thread); // Удаление автора из общего списка авторов в БД
            context.SaveChanges(); // Сохранение внесенных изменений в БД
        }

        public void SaveChanges() // Сохранение внесенных изменений в БД
        {
            context.SaveChanges();  // Сохранение внесенных изменений в БД
        }
    }

