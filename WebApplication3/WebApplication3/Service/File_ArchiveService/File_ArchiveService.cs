
using cursach_3.DTO.File_Archive;
using cursach_3.Repository.File_ArchiveRepository;
using cursach_3.Service.File_ArchiveService;

namespace cursach_3.Service.File_ArchiveService
{
    public class File_ArchiveService(IFile_ArchiveRepository File_ArchiveRepository) : IFile_ArchiveService
    {
        private IFile_ArchiveRepository _file_archiveRepository = File_ArchiveRepository; 

        public File_ArchiveDTO GetFile_Archive(long File_Archive_ID) 
        {
            return _file_archiveRepository.Get(File_Archive_ID); 
        }

        public List<File_ArchiveDTO> GetFile_Archives()  
        {
            return _file_archiveRepository.GetFile_Archives(); 
        }

        public void InsertFile_Archive(CreateFile_Archive dto) 
        {
            _file_archiveRepository.Insert(dto); 
        }

        public void UpdateFile_Archive(UpdateFile_Archive dto)  
        {
            _file_archiveRepository.Update(dto); 
        }

        public void DeleteFile_Archive(long File_Archive_ID)  
        {
            _file_archiveRepository.Delete(File_Archive_ID);  
        }
    }
}
