using IstanbulUni.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.BAL.Abstract
{
    public interface IUserService
    {
        List<User> GetListBl();
        bool UserAddBl(User user);
        bool UserLogin(User user);
        List<User> getByLast(DateTime last);
        User getUserInfo(int id);
        bool getUserMail(string email);
        bool getUserPass(string passwod);
    }
}
