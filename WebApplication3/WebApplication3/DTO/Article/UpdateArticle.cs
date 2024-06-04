using cursach_3.DATA;

namespace cursach_3.DTO.Article
{
    public class UpdateArticle
    {
        public long Article_ID { get; set; }
        public long Author_ID { get; set; }
        public string Article_Name { get; set; }
        public string Category_Name { get; set; }
        public int Rating { get; set; }
        public DateTime Creation_Date { get; set; }
        public long Photo_Folder_ID { get; set; }
        
    }
}
