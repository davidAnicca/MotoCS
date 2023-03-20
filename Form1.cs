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
using Motocliclisti.Entity;
using Motocliclisti.Repo;

namespace Motocliclisti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
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
                //testUser(constring);
                testTeam(constring);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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