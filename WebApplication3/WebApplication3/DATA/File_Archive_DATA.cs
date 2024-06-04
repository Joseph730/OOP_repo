using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework
namespace cursach_3.DATA
{
    public class File_Archive_DATA
    {
        public long File_Archive_ID { get; set; }
        public long Topic_ID {  get; set; }
        public long Thread_ID { get; set; }
        public long Commentary_ID { get; set; }
        public string Files_Archive_Desc { get; set; }
        public string File_Path { get; set; }
        public long Article_ID { get; set; }
        public Topic_DATA Topic { get; set; }
        public Thread_DATA Thread {  get; set; }
        public Commentary_DATA Commentary { get; set; }
        public Article_DATA Article { get; set; }
        
    }
    public class File_Archive_DATA_map
    {
        public File_Archive_DATA_map(EntityTypeBuilder<File_Archive_DATA> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.File_Archive_ID);
            entityTypeBuilder.Property(e => e.Files_Archive_Desc);
            entityTypeBuilder.Property(e => e.File_Path).IsRequired();
            entityTypeBuilder
                .HasOne(e => e.Topic)
                .WithMany(e => e.File_List)
                .HasForeignKey(e => e.Topic_ID);
            entityTypeBuilder
                .HasOne(e => e.Thread)
                .WithMany(e => e.File_List)
                .HasForeignKey(e => e.Thread_ID);
            
        }
    }
}
