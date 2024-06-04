using cursach_3.DATA;

namespace cursach_3.DTO.User
{
    public class UserDTO
    {
        public long User_ID { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public string User_URL { get; set; }
        public string User_NickName { get; set; }

        public List<Commentary.CommentaryDTO> Commentary_List { get; set; } = [];

        public Author.AuthorDTO Author { get; set; }
    }
}
