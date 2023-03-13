using System.Collections.Generic;

namespace Motocliclisti.Entity
{
    public class Proba
    {
        private int code;
        private string name;
        private List<Participant> participanti;

        public Proba(int code, string name)
        {
            this.code = code;
            this.name = name;
            participanti = new List<Participant>();
        }

        public void addP(Participant p)
        {
            participanti.Add(p);
        }

        public int Code
        {
            get => code;
            set => code = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public List<Participant> Participanti
        {
            get => participanti;
            set => participanti = value;
        }

        protected bool Equals(Proba other)
        {
            return code == other.code;
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
            return code;
        }

        private sealed class CodeEqualityComparer : IEqualityComparer<Proba>
        {
            public bool Equals(Proba x, Proba y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.code == y.code;
            }

            public int GetHashCode(Proba obj)
            {
                return obj.code;
            }
        }

        public static IEqualityComparer<Proba> CodeComparer { get; } = new CodeEqualityComparer();
    }
}