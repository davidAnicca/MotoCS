using System.Collections;
using System.Collections.Generic;
using Motocliclisti.Entity;

namespace Motocliclisti.Repo
{
    public class UserRepo : Repo<User>
    {
        private List<User> _users;

        public UserRepo()
        {
            _users = new List<User>();
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public void Add(User obj)
        {
            if(_users.Contains(obj))
                return;
            _users.Add(obj);
        }

        public void Remove(User obj)
        {
            if(!_users.Contains(obj))
                return;
            _users.Remove(obj);
        }

        public void Modify(User obj)
        {
            if(!_users.Contains(obj))
                return;
            User real = Search(obj);
            real.UserName = obj.UserName;
            real.Passwd = obj.Passwd;
        }

        public User Search(User obj)
        {
            foreach (var user in _users)
            {
                if (user.Equals(obj))
                    return user;
            }
            return null;
        }
    }
}