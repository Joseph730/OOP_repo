using cursach_3.DTO.User;

namespace cursach_3.Repository.UserRepository
{
    public interface IUserRepository
    {
        UserDTO Get(long User_ID); // Описание метода для получение одной книги из БД
        List<UserDTO> GetUsers(); // Описание метода для получение всех книг из БД
        void Insert(CreateUser dto); // Описание метода вставки новой книги в БД
        void Update(UpdateUser dto); // Описание метода обновления информации о книге в БД
        void Delete(long User_ID);  // Описание метода удаления книги по указанному ID
        void SaveChanges();
    }
}
