using cursach_3.DTO.Photo_folder;
using cursach_3.Repository.Photo_folderRepository;

namespace cursach_3.Service.Photo_folderService
{
    public class Photo_folderService(IPhoto_folderRepository Photo_folderRepository) : IPhoto_folderService
    {
        private IPhoto_folderRepository _photo_folderRepository = Photo_folderRepository; 

        public PhotoDTO GetPhoto_folder(long Photo_folder_ID) 
        {
            return _photo_folderRepository.Get(Photo_folder_ID); 
        }

        public List<PhotoDTO> GetPhoto_folders()  
        {
            return _photo_folderRepository.GetPhoto_folders(); 
        }

        public void InsertPhoto_folder(CreatePhoto dto) 
        {
            _photo_folderRepository.Insert(dto);  
        }

        public void UpdatePhoto_folder(UpdatePhoto dto)  
        {
            _photo_folderRepository.Update(dto); 
        }

        public void DeletePhoto_folder(long Photo_folder_ID) 
        {
            _photo_folderRepository.Delete(Photo_folder_ID);  
        }
    }
}
