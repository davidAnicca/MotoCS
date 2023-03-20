using System.Collections.Generic;

namespace Motocliclisti.Entity
{
    public class Participant
    {
        public int Code
        {
            get => _code;
            set => _code = value;
        }

        public int Team
        {
            get => _team;
            set => _team = value;
        }

        public int Capacity
        {
            get => _capacity;
            set => _capacity = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private int _code;
        private int _team;
        private int _capacity;
        private string _name;

        public Participant(int code, int team, int capacity, string name)
        {
            this._code = code;
            this._team = team;
            this._capacity = capacity;
            this._name = name;
        }

        protected bool Equals(Participant other)
        {
            return _code == other._code;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Participant)obj);
        }

        public override int GetHashCode()
        {
            return _code;
        }

        private sealed class CodeEqualityComparer : IEqualityComparer<Participant>
        {
            public bool Equals(Participant x, Participant y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._code == y._code;
            }

            public int GetHashCode(Participant obj)
            {
                return obj._code;
            }
        }

        public static IEqualityComparer<Participant> CodeComparer { get; } = new CodeEqualityComparer();
    }
}