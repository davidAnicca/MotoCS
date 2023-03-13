using System.Collections.Generic;
using Motocliclisti.Entity;

namespace Motocliclisti.Repo
{
    public class ParticipantsRepo : Repo<Participant>
    {
        private List<Participant> _participants;

        public ParticipantsRepo()
        {
            _participants = new List<Participant>();
        }

        public List<Participant> GetAll()
        {
            return _participants;
        }

        public void Add(Participant obj)
        {
            if (_participants.Contains(obj))
                return;
            _participants.Add(obj);
        }

        public void Remove(Participant obj)
        {
            if (!_participants.Contains(obj))
                return;
            _participants.Remove(obj);
        }

        public void Modify(Participant obj)
        {
            Participant real = Search(obj);
            if (real == null) return;
            real.Capacity = obj.Capacity;
            real.Name = obj.Name;
            real.Team = obj.Team;
        }

        public Participant Search(Participant obj)
        {
            foreach (var vaParticipant in _participants)
            {
                if (vaParticipant.Equals(obj))
                    return vaParticipant;
            }

            return null;
        }
    }
}