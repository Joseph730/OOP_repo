
using cursach_3.DTO.Photo_folder;
using cursach_3.Service.Photo_folderService;

namespace cursach_3.Service.Photo_folderService
{
    public interface IPhoto_folderService
    {
        PhotoDTO GetPhoto_folder(long Photo_folder_ID);  
        List<PhotoDTO> GetPhoto_folders(); 
        void InsertPhoto_folder(CreatePhoto dto);  
        void UpdatePhoto_folder(UpdatePhoto dto);  
        void DeletePhoto_folder(long Photo_folder_ID);
    }
}
