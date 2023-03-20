using System.Collections.Generic;

namespace Motocliclisti.Entity
{
    public class Registration
    {
        private int _participantCode;
        private int _probeCode;

        public Registration(int participantCode, int probeCode)
        {
            _participantCode = participantCode;
            _probeCode = probeCode;
        }

        public int ParticipantCode
        {
            get => _participantCode;
            set => _participantCode = value;
        }

        public int ProbeCode
        {
            get => _probeCode;
            set => _probeCode = value;
        }

        protected bool Equals(Registration other)
        {
            return _participantCode == other._participantCode && _probeCode == other._probeCode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Registration)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_participantCode * 397) ^ _probeCode;
            }
        }

        private sealed class ParticipantCodeProbeCodeEqualityComparer : IEqualityComparer<Registration>
        {
            public bool Equals(Registration x, Registration y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._participantCode == y._participantCode && x._probeCode == y._probeCode;
            }

            public int GetHashCode(Registration obj)
            {
                unchecked
                {
                    return (obj._participantCode * 397) ^ obj._probeCode;
                }
            }
        }

        public static IEqualityComparer<Registration> ParticipantCodeProbeCodeComparer { get; } = new ParticipantCodeProbeCodeEqualityComparer();
    }
}