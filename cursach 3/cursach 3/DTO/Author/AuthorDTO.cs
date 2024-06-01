using cursach_3.DATA;

namespace cursach_3.DTO.Author
{
    public class AuthorDTO
    {
        public int Author_ID { get; set; }
        public int User_ID { get; set; }
        public long Photo_folder_ID { get; set; }
        public string Author_URL { get; set; }
        public string Author_Name { get; set; }

        
        public List<Article.ArticleDTO> Article_List { get; set; }
        public List<Thread.ThreadDTO> Thread_List { get; set; }
        public Author.AuthorDTO Author { get; set; }
        public User.UserDTO User { get; set; }
        public Photo_folder.PhotoDTO Photo { get; set; }
    }
}
