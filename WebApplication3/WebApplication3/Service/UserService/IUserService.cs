using cursach_3.DTO.User;

namespace cursach_3.Service.UserService
{
    public interface IUserService
    {
        UserDTO GetUser(long User_ID); 
        List<UserDTO> GetUsers(); 
        void InsertUser(CreateUser dto);  
        void UpdateUser(UpdateUser dto);  
        void DeleteUser(long User_ID);
    }
}
