using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Motocliclisti.Entity;
using Motocliclisti.Repo;

namespace Motocliclisti
{
    public partial class Form1 : Form
    {
        private log4net.ILog _logger =  log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        public Form1()
        {
            Uri configUri = new Uri("C:\\Users\\meres\\Desktop\\Fac\\MPP\\L02-Home\\Motocliclisti\\Motocliclisti\\log4net.config");
            log4net.Config.XmlConfigurator.Configure(configUri);
            _logger.Debug("Test");
            
            
            StreamReader reader = new StreamReader("bd.config");
            string constring = reader.ReadLine();
            JdbcUtils jdbcUtils = new JdbcUtils(constring);
            MessageBox.Show(jdbcUtils.GetConnection().State.ToString());
            jdbcUtils.GetConnection().Close();
            tests(constring);
        }

        private void tests(string constring)
        {
            try
            {
                _logger.Error("start test");
                //testUser(constring);
                //testTeam(constring);
                //testParticipants(constring);
                //testProbe(constring);
                //testRegistration(constring);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        private void testRegistration(string constring)
        {
            RegistrationDbRepo repo = new RegistrationDbRepo(constring);
            string str = "";
            List<Registration> registrations = repo.GetAll();
            str += "teams: " + registrations.Count.ToString();
            foreach(Registration registration in registrations)
            {
                str += "\n" + registration.ParticipantCode + " " + registration.ProbeCode;
            }
            MessageBox.Show(str);
            Registration registrationN = new Registration(23 , 22);
            repo.Add(registrationN);
            repo.Remove(registrationN);
        }

        private void testProbe(string constring)
        {
            ProbeDbRepo repo = new ProbeDbRepo(constring);
            string str = "";
            List<Probe> probes = repo.GetAll();
            str += "teams: " + probes.Count.ToString();
            foreach(Probe probe in probes)
            {
                str += "\n" + probe.Code + " " + probe.Name;
            }

            MessageBox.Show(str);
            
            Probe probeN = new Probe(DateTime.Now.Second + 30 , DateTime.Now.Second.ToString());
            repo.Add(probeN);
            Probe toDel = new Probe(DateTime.Now.Second+2 + 30, DateTime.Now.Second.ToString() + "toDel");
            repo.Add(toDel);
            repo.Remove(toDel);
            probeN.Name ="NewNameFromC#";
            repo.Modify(probeN);
        }

        private void testParticipants(string constring)
        {
            ParticipantDbRepo repo = new ParticipantDbRepo(constring);
            string str = "";
            List<Participant> participants = repo.GetAll();
            str += "participants: " + participants.Count.ToString();
            foreach(Participant participan in participants)
            {
                str += "\n" + participan.Code + " " + participan.Name;
            }

            MessageBox.Show(str);
            
            Participant participantN = new Participant(
                DateTime.Now.Second + 10, 
                48,
                100, 
                "newFromC#"
            );
            repo.Add(participantN);
            Participant toDel = new Participant(
                DateTime.Now.Second + 10 + 2, 
                59,
                100, 
                "sdnt be here"
            );
            repo.Add(toDel);
            repo.Remove(toDel);
            participantN.Name ="NewNameFromC#";
            repo.Modify(participantN);
        }

        private void testTeam(string constring)
        {
            TeamDbRepo repo = new TeamDbRepo(constring);
            string str = "";
            List<Team> teams = repo.GetAll();
            str += "teams: " + teams.Count.ToString();
            foreach(Team team in teams)
            {
                str += "\n" + team.Code + " " + team.Name;
            }

            MessageBox.Show(str);
            
            Team teamN = new Team(DateTime.Now.Second + 30 , DateTime.Now.Second.ToString());
            repo.Add(teamN);
            Team toDel = new Team(DateTime.Now.Second+2 + 30, DateTime.Now.Second.ToString() + "toDel");
            repo.Add(toDel);
            repo.Remove(toDel);
            teamN.Name ="NewNameFromC#";
            repo.Modify(teamN);
        }

        private void testUser(string constring)
        {
            UserDbRepo repo = new UserDbRepo(constring);
            string str = "";
            List<User> users = repo.GetAll();
            str += "users: " + users.Count.ToString();
            foreach(User user in users)
            {
                str += "\n" + user.UserName + " " + user.Passwd;
            }

            MessageBox.Show(str);
            
            User newUser = new User(DateTime.Now.Second.ToString(), DateTime.Now.Second.ToString());
            repo.Add(newUser);
            User userToDel = new User(DateTime.Now.Second.ToString()+2, DateTime.Now.Second.ToString() + "toDel");
            repo.Add(userToDel);
            repo.Remove(userToDel);
            newUser.Passwd ="abcC#";
            repo.Modify(newUser);
        }
    }
}