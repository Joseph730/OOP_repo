using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework
namespace cursach_3.DATA
{
    public class Commentary_DATA
    {
        public long Commentary_ID { get; set; }
        public int Topic_ID { get; set; }
        public int Thread_ID { get; set; }
        public int User_ID { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Commentary_size { get; set; }
        public int Article_ID { get; set; }
        public User_DATA User { get; set; }

        public Thread_DATA Thread { get; set; }
        public Topic_DATA Topic { get; set; }

        public Article_DATA Article { get; set; }

        public File_Archive_DATA File { get; set; }
    }
    public class CommentaryMap
    {
        public CommentaryMap(EntityTypeBuilder<Commentary_DATA> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Commentary_ID);
            entityTypeBuilder.Property(e => e.Creation_Date);
            entityTypeBuilder.Property(e => e.Commentary_size).IsRequired();
            entityTypeBuilder
                .HasOne(e => e.User)

                .WithMany(e => e.Commentary_List)
                .HasForeignKey(e => e.User_ID);
            entityTypeBuilder
                .HasOne(e => e.File)
                .WithOne(e => e.Commentary);
            entityTypeBuilder
                .HasOne(e => e.Article)
                .WithMany(e => e.Commentary_List)
                .HasForeignKey(e => e.Article_ID);
            entityTypeBuilder
                .HasOne(e => e.Topic)
                .WithMany(e => e.Commentary_List)
                .HasForeignKey(e => e.Topic_ID);
            entityTypeBuilder
                .HasOne(e => e.Thread)
                .WithMany(e => e.Commentary_List)
                .HasForeignKey(e => e.Thread_ID);

        }
    }
}   
