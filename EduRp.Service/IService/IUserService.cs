using EduRp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduRp.Service.IService
{
    public interface IUserService
    {
        UserMaster ValidateUser(string email, string password);

        UserMaster GetUserById(int? id);

        List<UserMaster> GetUserList();
    }
}
