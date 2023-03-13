using System.Collections.Generic;
using Motocliclisti.Entity;

namespace Motocliclisti.Repo
{
    public class TeamsRepo: Repo<Team>
    {
        public TeamsRepo()
        {
            _teams = new List<Team>();
        }

        private List<Team> _teams;

        public List<Team> GetAll()
        {
            return _teams;
        }

        public void Add(Team obj)
        {
            if(_teams.Contains(obj))
                return;
            _teams.Add(obj);
        }

        public void Remove(Team obj)
        { 
            if(!_teams.Contains(obj))
                return;
            _teams.Remove(obj);
        }

        public void Modify(Team obj)
        {
            Team real = Search(obj);
            if(real == null)
                return;
            real.Code = obj.Code;
            real.Name = obj.Name;
        }

        public Team Search(Team obj)
        {
            foreach (var variablTeam in _teams)
            {
                if (variablTeam.Equals(obj))
                    return variablTeam;
            }

            return null;
        }
    }
}