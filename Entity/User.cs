using System.Collections.Generic;

namespace Motocliclisti.Entity
{
    public class User
    {
        private string _userName;
        private string _passwd;

        public User(string userName, string passwd)
        {
            this._userName = userName;
            this._passwd = passwd;
        }

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string Passwd
        {
            get => _passwd;
            set => _passwd = value;
        }

        protected bool Equals(User other)
        {
            return _userName == other._userName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        public override int GetHashCode()
        {
            return (_userName != null ? _userName.GetHashCode() : 0);
        }

        private sealed class UserNameEqualityComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._userName == y._userName;
            }

            public int GetHashCode(User obj)
            {
                return (obj._userName != null ? obj._userName.GetHashCode() : 0);
            }
        }

        public static IEqualityComparer<User> UserNameComparer { get; } = new UserNameEqualityComparer();
    }
}