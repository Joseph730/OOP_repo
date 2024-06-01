using cursach_3.DATA;

namespace cursach_3.DTO.Article
{
    public class CreateArticle
    {
        
        public int Author_ID { get; set; }
        public string Article_Name { get; set; }
        public string Category_Name { get; set; }
        public int Rating { get; set; }
        public DateTime Creation_Date { get; set; }
        public long Photo_Folder_ID { get; set; }
        public Author_DATA Author { get; set; }

        public Photo_folder_DATA Photo { get; set; }

        public File_Archive_DATA File { get; set; }
    }
}
