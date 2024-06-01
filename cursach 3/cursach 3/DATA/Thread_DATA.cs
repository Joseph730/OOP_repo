using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework
namespace cursach_3.DATA
{
    public class Thread_DATA
    {
        public int Thread_ID { get; set; }
        public string Thread_Desc {  get; set; }
        public string Thread_Name { get; set; }
        public int Author_ID { get; set; }
        public int Rating {  get; set; }
        public string Thread_URL {  get; set; }
        public List<Commentary_DATA> Commentary_List { get; set; }
        public List<Topic_DATA> Topic_List { get; set; }
        public List<File_Archive_DATA> File_List { get; set; }
        public Author_DATA Author {  get; set; }
    }
    public class ThreadMap
    {
        public ThreadMap(EntityTypeBuilder<Thread_DATA> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e =>  e.Thread_ID);
            entityTypeBuilder.Property(e => e.Thread_Desc);
            entityTypeBuilder.Property(e => e.Thread_Name).IsRequired();
            entityTypeBuilder.Property(e => e.Thread_URL).IsRequired();
            entityTypeBuilder
                .HasMany(e => e.Commentary_List)
                .WithOne(e => e.Thread);
            entityTypeBuilder
                .HasMany(e => e.Topic_List)
                .WithOne(e => e.Thread);
            entityTypeBuilder
                .HasMany(e => e.File_List)
                .WithOne(e => e.Thread);
            entityTypeBuilder
                .HasOne(e => e.Author)
                .WithMany(e => e.Thread_List)
                .HasForeignKey(e => e.Author_ID);
        }
    }
}
