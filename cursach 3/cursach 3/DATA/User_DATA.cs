using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework
namespace cursach_3.DATA
{
    public class User_DATA
    {
        public long User_ID { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public string User_URL { get; set; }
        public string User_NickName { get; set; }

        public List<Commentary_DATA> Commentary_List { get; set; } =  [];

        public Author_DATA Author {  get; set; }
        
    }
    public class UserMap  // Разметка сущности класса города для Entity Framework. В данном случае для классп города City
    {
        public UserMap(EntityTypeBuilder<User_DATA> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.User_ID);  // Установка первичного ключа - ID города
            entityTypeBuilder.Property(e => e.User_Email).IsRequired(); // Обязательное Поле для БД
            entityTypeBuilder.Property(e => e.User_Password).IsRequired(); // Обязательное Поле для БД
            entityTypeBuilder.Property(e => e.User_NickName).IsRequired(); // Обязательное Поле для БД

            entityTypeBuilder    // Прописывание отношений ОДИН К ОДНОМУ между городом и уведомлениями
                .HasOne(e => e.Author)
                .WithOne(e => e.User);
            entityTypeBuilder 
                .HasMany(e => e.Commentary_List)
                .WithOne(e => e.User);
            

        }
    }
}
