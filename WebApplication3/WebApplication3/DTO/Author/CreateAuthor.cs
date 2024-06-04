using cursach_3.DATA;

namespace cursach_3.DTO.Author
{
    public class CreateAuthor
    {
        public long User_ID { get; set; }
        public long Photo_folder_ID { get; set; }
        public string Author_URL { get; set; }
        public string Author_Name { get; set; }
        
    }
}
