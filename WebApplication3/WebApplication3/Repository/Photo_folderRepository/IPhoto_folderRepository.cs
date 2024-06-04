using cursach_3.DTO.Photo_folder;

namespace cursach_3.Repository.Photo_folderRepository
{
    public interface IPhoto_folderRepository
    {
        PhotoDTO Get(long Photo_folder_ID); // Описание метода для получение одной книги из БД
        List<PhotoDTO> GetPhoto_folders(); // Описание метода для получение всех книг из БД
        void Insert(CreatePhoto dto); // Описание метода вставки новой книги в БД
        void Update(UpdatePhoto dto); // Описание метода обновления информации о книге в БД
        void Delete(long Photo_folder_ID);  // Описание метода удаления книги по указанному ID
        void SaveChanges();
    }
}
