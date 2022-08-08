using IstanbulUni.BAL.Abstract;
using IstanbulUni.DAL.Abstract;
using IstanbulUni.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.BAL.Concrate
{
    public class UserManager : IUserService
    {
        IUser _user;
        public int userID;
        public UserManager(IUser user)
        {
            _user = user;
        }

        public List<User> GetListBl()
        {
            return _user.GetAll();
        }

        public bool UserAddBl(User user)
        {
            var _userInfo = _user.get(t => t.Email == user.Email && t.Password == user.Password);
            if (_userInfo != null)
            {
                return true;
            }
            else { user.lastActivity = DateTime.Now; _user.Insert(user); return false; }
        }
        public IEnumerable<User> Read()
        {
            return GetListBl();
        }
        public bool UserLogin(User user)
        {
            User userInfo = _user.get(t => t.Email == user.Email && t.Password == user.Password);

            if (userInfo != null)
            {

                userInfo.lastActivity = DateTime.Now;
                _user.Update(userInfo);
                return true;
            }
            else return false;

        }
        public int getUserId(User user)
        {
            User userInfo = _user.get(t => t.Email == user.Email && t.Password == user.Password);
            return userInfo.userID;
        }

        public List<User> getByLast(DateTime last)
        {
            var data = _user.List(l => l.lastActivity > last);
            return data;
        }

        public User getUserInfo(int id)
        {
            return _user.get(x=>x.userID == id);
        }

        public bool getUserMail(string email)
        {
            var mail = _user.get(x => x.Email == email);
            if (mail != null)
            {
                return true;
            }
            else return false;
        }

        public bool getUserPass(string passwod)
        {
            var pass =  _user.get(x => x.Password == passwod);
            if (pass!=null)
            {
                return true;
            }
            else return false;
        }

        //public User userLoginInfo(User user)
        //{
        //    User userInfo = _user.get(t => t.Email == user.Email || t.Password == user.Password);
        //    if (userInfo!=null)
        //    {
        //        userInfo.lastActivity = DateTime.Now;
        //        _user.Update(userInfo);
        //    }

        //    return userInfo;
        //}
    }
}
