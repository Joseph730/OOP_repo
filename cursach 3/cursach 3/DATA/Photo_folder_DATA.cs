using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework
namespace cursach_3.DATA
{
    public class Photo_folder_DATA
    {
        internal object Photo_Folder_ID;

        public long Photo_folder_ID { get; set; }
        public string Photo_folder_Desc { get; set; }
        public string Photo_folder_Name { get; set; }
        public string Photo_folder_Path { get; set; }



        public Article_DATA Article { get; set; }

        public Author_DATA Author { get; set; }
    }
    public class PhotoMap
    {
        public PhotoMap(EntityTypeBuilder<Photo_folder_DATA> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Photo_folder_ID);
            entityTypeBuilder.Property(e => e.Photo_folder_Desc);
            entityTypeBuilder.Property(e => e.Photo_folder_Name).IsRequired();
            entityTypeBuilder.Property(e => e.Photo_folder_Path).IsRequired();
            entityTypeBuilder
                .HasOne(e => e.Author)
                .WithOne(e => e.Photo);
            entityTypeBuilder
                .HasOne(e => e.Article)
                .WithOne(e => e.Photo);
        }

    }
}
