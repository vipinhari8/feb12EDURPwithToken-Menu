using EduRp.Data;
using EduRp.Service.IService;
using System.Collections.Generic;
using System.Linq;

namespace EduRp.Service.Service
{
    public class UserService:IUserService
    {
        private edurp_devEntities db = new edurp_devEntities();

        public List<UserMaster> GetUserList()
        {
            return db.UserMasters.ToList();
            // Create the list of user and return           
        }
        public UserMaster GetUserById(int? id)
        {
            var userList = GetUserList();
            var user = userList.FirstOrDefault(x => x.UserId == id);
            return user;
        }

        UserMaster IUserService.ValidateUser(string email, string password)
        {
            // Here you can write the code to validate
            // User from database and return accordingly
            // To test we use dummy list here
            var userList = GetUserList();
            var user = userList.FirstOrDefault(x => x.EmailAddress == email && x.PlaintextPWD == password);
            return user;
        }
    }
}