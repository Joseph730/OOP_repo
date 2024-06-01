using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework
namespace cursach_3.DATA
{
    public class Article_DATA
    {
        public long Article_ID { get; set; }
        public int Author_ID { get; set; }
        public string Article_Name { get; set; }
        public string Category_Name { get; set; }
        public int Rating { get; set; }
        public DateTime Creation_Date {  get; set; }
        public long Photo_Folder_ID { get; set; }

        public List<Commentary_DATA> Commentary_List { get; set; } = [];

        public Author_DATA Author { get; set; }

        public Photo_folder_DATA Photo { get; set; }

        public File_Archive_DATA File { get; set; }




    }
    public class ArticleMap
    {
        public ArticleMap(EntityTypeBuilder<Article_DATA> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Article_ID);
            entityTypeBuilder.Property(e => e.Article_Name).IsRequired();
            entityTypeBuilder.Property(e => e.Category_Name);
            entityTypeBuilder
                .HasOne(e => e.Author)
                .WithMany(e => e.Article_List)
                .HasForeignKey(e => e.Author_ID);
            entityTypeBuilder
                .HasOne(e => e.Photo)
                .WithOne(e => e.Article)
                .HasForeignKey<Photo_folder_DATA>(e => e.Photo_Folder_ID);
            entityTypeBuilder
                .HasOne(e => e.File)
                .WithOne(e => e.Article);
            entityTypeBuilder
                .HasMany(e => e.Commentary_List)
                .WithOne(e => e.Article);
        }
    }
}
