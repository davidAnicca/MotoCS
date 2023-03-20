using System.Collections.Generic;

namespace Motocliclisti.Entity
{
    public class Proba
    {
        private int _code;
        private string _name;

        public Proba(int code, string name)
        {
            this._code = code;
            this._name = name;
        }

        public int Code
        {
            get => _code;
            set => _code = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        protected bool Equals(Proba other)
        {
            return _code == other._code;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Proba)obj);
        }

        public override int GetHashCode()
        {
            return _code;
        }

        private sealed class CodeEqualityComparer : IEqualityComparer<Proba>
        {
            public bool Equals(Proba x, Proba y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._code == y._code;
            }

            public int GetHashCode(Proba obj)
            {
                return obj._code;
            }
        }

        public static IEqualityComparer<Proba> CodeComparer { get; } = new CodeEqualityComparer();
    }
}