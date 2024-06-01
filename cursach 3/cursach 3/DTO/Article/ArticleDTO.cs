using cursach_3.DATA;

namespace cursach_3.DTO.Article
{
    public class ArticleDTO
    {
        public long Article_ID { get; set; }
        public int Author_ID { get; set; }
        public string Article_Name { get; set; }
        public string Category_Name { get; set; }
        public int Rating { get; set; }
        public DateTime Creation_Date { get; set; }
        public long Photo_Folder_ID { get; set; }

        public List<Commentary.CommentaryDTO> Commentary_List { get; set; } = [];
        public Author.AuthorDTO Author { get; set; }

        public Photo_folder.PhotoDTO Photo { get; set; }

        public File_Archive.File_ArchiveDTO File { get; set; }

    }
}

