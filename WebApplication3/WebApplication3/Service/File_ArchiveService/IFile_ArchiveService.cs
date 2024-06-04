
using cursach_3.DTO.File_Archive;

namespace cursach_3.Service.File_ArchiveService
{
    public interface IFile_ArchiveService
    {
        File_ArchiveDTO GetFile_Archive(long File_Archive_ID); 
        List<File_ArchiveDTO> GetFile_Archives(); 
        void InsertFile_Archive(CreateFile_Archive dto);  
        void UpdateFile_Archive(UpdateFile_Archive dto);  
        void DeleteFile_Archive(long File_Archive_ID);
    }
}
