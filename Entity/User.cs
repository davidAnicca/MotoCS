using System.Collections.Generic;

namespace Motocliclisti.Entity
{
    public class User
    {
        private string userName;
        private string passwd;

        public User(string userName, string passwd)
        {
            this.userName = userName;
            this.passwd = passwd;
        }

        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public string Passwd
        {
            get => passwd;
            set => passwd = value;
        }

        protected bool Equals(User other)
        {
            return userName == other.userName;
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
            return (userName != null ? userName.GetHashCode() : 0);
        }

        private sealed class UserNameEqualityComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.userName == y.userName;
            }

            public int GetHashCode(User obj)
            {
                return (obj.userName != null ? obj.userName.GetHashCode() : 0);
            }
        }

        public static IEqualityComparer<User> UserNameComparer { get; } = new UserNameEqualityComparer();
    }
}