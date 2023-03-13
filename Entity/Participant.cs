using System.Collections.Generic;

namespace Motocliclisti.Entity
{
    public class Participant
    {
        public int Code
        {
            get => code;
            set => code = value;
        }

        public int Team
        {
            get => team;
            set => team = value;
        }

        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        private int code;
        private int team;
        private int capacity;
        private string name;

        public Participant(int code, int team, int capacity, string name)
        {
            this.code = code;
            this.team = team;
            this.capacity = capacity;
            this.name = name;
        }

        protected bool Equals(Participant other)
        {
            return code == other.code;
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
            return code;
        }

        private sealed class CodeEqualityComparer : IEqualityComparer<Participant>
        {
            public bool Equals(Participant x, Participant y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.code == y.code;
            }

            public int GetHashCode(Participant obj)
            {
                return obj.code;
            }
        }

        public static IEqualityComparer<Participant> CodeComparer { get; } = new CodeEqualityComparer();
    }
}