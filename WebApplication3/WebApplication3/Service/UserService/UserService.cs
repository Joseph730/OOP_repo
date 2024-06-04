using cursach_3.DTO.User;
using cursach_3.Repository.UserRepository;
using cursach_3.Service.UserService;

namespace cursach_3.Service.UserService
{
    public class UserService(IUserRepository UserRepository) : IUserService
    {
        private IUserRepository _userRepository = UserRepository; 

        public UserDTO GetUser(long User_ID) 
        {
            return _userRepository.Get(User_ID); 
        }

        public List<UserDTO> GetUsers()  
        {
            return _userRepository.GetUsers(); 
        }

        public void InsertUser(CreateUser dto) 
        {
            _userRepository.Insert(dto);  
        }

        public void UpdateUser(UpdateUser dto)  
        {
            _userRepository.Update(dto); 
        }

        public void DeleteUser(long User_ID)  
        {
            _userRepository.Delete(User_ID);  
        }
    }
}
