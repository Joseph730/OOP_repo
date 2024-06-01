using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework
namespace cursach_3.DATA
{
    public class Topic_DATA
    {
        public int Topic_ID;
        public string Topic_Name;
        public int Thread_ID;
        public string Topic_URL;
        public string Topic_Desc;
        public int Event_ID;
        public Thread_DATA Thread;
        public Event_DATA Event;
        public List<Commentary_DATA> Commentary_List { get; set; } = [];
        public List<File_Archive_DATA> File_List { get; set; } = [];
    }
    public class Topic_DATA_map
    {
        public Topic_DATA_map(EntityTypeBuilder<Topic_DATA> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Topic_ID);
            entityTypeBuilder
                .HasMany(e => e.File_List)
                .WithOne(e => e.Topic);
            entityTypeBuilder
                .HasOne(e => e.Thread)
                .WithMany(e => e.Topic_List)
                .HasForeignKey(e => e.Topic_ID);
            entityTypeBuilder
                .HasMany(e => e.Commentary_List)
                .WithOne(e => e.Topic);

        }
    }
}
