using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework
namespace cursach_3.DATA
{
    public class Topic_DATA
    {
        public long Topic_ID;
        public string Topic_Name;
        public long Thread_ID;
        public string Topic_URL;
        public string Topic_Desc;
        public Thread_DATA Thread;
        public List<Commentary_DATA> Commentary_List { get; set; } = [];
        public List<File_Archive_DATA> File_List { get; set; } = [];
    }
    public class Topic_DATA_map
    {
        public Topic_DATA_map(EntityTypeBuilder<Topic_DATA> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Topic_ID);
            entityTypeBuilder.Property(e => e.Topic_Name);
            entityTypeBuilder.Property(e => e.Topic_URL);
            entityTypeBuilder.Property(e => e.Topic_Desc);
            entityTypeBuilder
                .HasMany(e => e.File_List)
                .WithOne(e => e.Topic);
            entityTypeBuilder
                .HasOne(e => e.Thread)
                .WithMany(e => e.Topic_List)
                .HasForeignKey(e => e.Thread_ID);
            entityTypeBuilder
                .HasMany(e => e.Commentary_List)
                .WithOne(e => e.Topic);

        }
    }
}
