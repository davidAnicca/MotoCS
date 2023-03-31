using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Motocliclisti.Entity;
using Motocliclisti.Repo;

namespace Motocliclisti.Srv
{
    public class Service
    {
        private string _constring;
        private UserDbRepo _userRepo;
        private ProbeDbRepo _probeRepo;
        private readonly TeamDbRepo _teamRepo;
        private readonly ParticipantDbRepo _participantRepo;

        public Service(string constring)
        {
            this._constring = constring;
            this._userRepo = new UserDbRepo(constring);
            this._probeRepo = new ProbeDbRepo(constring);
            this._teamRepo = new TeamDbRepo(constring);
            this._participantRepo = new ParticipantDbRepo(constring);
        }

        public bool CheckUser(string userName, string passwd)
        {
            UserDbRepo repo = new UserDbRepo(_constring);
            User user = repo.Search(new User(userName, ""));
            if (user == null)
                return false;
            if (user.Passwd != passwd)
                return false;
            return true;
        }

        public List<Probe> getProbes()
        {
            return _probeRepo.GetAll();
        }

        public int getParticipantsCount(int probeCode)
        {
            return _probeRepo.GetParticipants(new Probe(probeCode, "")).Count;
        }

        public List<Participant> GetParticipantsByTeam(string team)
        {
            return _participantRepo.FindByTeam(new Team(0, team));
        }

        public List<Team> GetTeams()
        {
            return _teamRepo.GetAll();
        }

        public void AddParticipant(string name, string team, string capacity)
        {
            int maxCode = 0;
            maxCode = _participantRepo.MaxCode(maxCode);
            int participantCode = maxCode + 1;
            int teamCode = _teamRepo.FindByName(team).Code;
            _participantRepo.Add(new Participant(participantCode,
                teamCode,
                int.Parse(capacity),
                name));
        }
        
    }
}