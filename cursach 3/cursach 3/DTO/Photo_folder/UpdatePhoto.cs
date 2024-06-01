using cursach_3.DATA;

namespace cursach_3.DTO.Photo_folder
{
    public class UpdatePhoto
    {
        internal object Photo_Folder_ID;

        public long Photo_folder_ID { get; set; }
        public string Photo_folder_Desc { get; set; }
        public string Photo_folder_Name { get; set; }
        public string Photo_folder_Path { get; set; }



        public Article_DATA Article { get; set; }

        public Author_DATA Author { get; set; }
    }
}
