using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework

namespace cursach_3.DATA
{
    public class Author_DATA
    {
        public long Author_ID {  get; set; }
        public long User_ID { get; set; }
        public long Photo_folder_ID { get; set; }
        public string Author_URL { get; set; }
        public string Author_Name { get; set; }
        public User_DATA User { get; set; }
        public List<Article_DATA> Article_List { get; set; }
        public Photo_folder_DATA Photo {get; set; }
        public List<Thread_DATA> Thread_List { get; set; }

    }
    public class AuthorMap  // Разметка сущности класса города для Entity Framework. В данном случае для классп города City
    {
        public AuthorMap(EntityTypeBuilder<Author_DATA> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Author_ID);  // Установка первичного ключа - ID города
            entityTypeBuilder.Property(e => e.Author_URL).IsRequired(); // Обязательное Поле для БД
            entityTypeBuilder.Property(e => e.Author_Name).IsRequired(); // Обязательное Поле для БД
                        //// Прописывание отношений ОДИН КО МНОГИМ между городом и уведомлениями
            entityTypeBuilder
                .HasMany(e => e.Thread_List)
                .WithOne(e => e.Author);
            entityTypeBuilder
                .HasMany(e => e.Article_List)
                .WithOne(e => e.Author);
           

        }
    }
}
