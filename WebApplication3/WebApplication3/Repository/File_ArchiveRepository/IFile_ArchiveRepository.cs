using cursach_3.DTO.File_Archive;

namespace cursach_3.Repository.File_ArchiveRepository
{
    public interface IFile_ArchiveRepository
    {
        File_ArchiveDTO Get(long File_Archive_ID); // Описание метода для получение одной книги из БД
        List<File_ArchiveDTO> GetFile_Archives(); // Описание метода для получение всех книг из БД
        void Insert(CreateFile_Archive dto); // Описание метода вставки новой книги в БД
        void Update(UpdateFile_Archive dto); // Описание метода обновления информации о книге в БД
        void Delete(long File_Archive_ID);  // Описание метода удаления книги по указанному ID
        void SaveChanges();
    }
}
