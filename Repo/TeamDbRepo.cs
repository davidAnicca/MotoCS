using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Motocliclisti.Entity;

namespace Motocliclisti.Repo
{
    public class TeamDbRepo : TeamRepo
    {
        
        private static readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _props;

        public TeamDbRepo(string props)
        {
            _props = props;
        }

        public List<Team> GetAll()
        {
            logger.Info("getting teams from DB");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                List<Team> teams = new List<Team>();
                using (SQLiteCommand command = new SQLiteCommand("select * from teams", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int code = reader.GetInt16(reader.GetOrdinal("code"));
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            teams.Add(new Team(code, name));
                        }
                    }
                }
                connection.Close();
                return teams;
            }
        }

        public void Add(Team obj)
        {
            logger.Info("adding new team");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();

                using (SQLiteCommand command =
                       new SQLiteCommand("insert into teams(code, name) values(@code, @name)",
                           connection))
                {
                    command.Parameters.AddWithValue("@code", obj.Code);
                    command.Parameters.AddWithValue("@name", obj.Name);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("team added");
        }

        public void Remove(Team obj)
        {
            logger.Info("deleting team " + obj.Code.ToString());
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("delete from teams where code = @code", connection))
                {
                    command.Parameters.AddWithValue("@code", obj.Code);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("team deleted");
        }

        public void Modify(Team obj)
        {
            logger.Info("updating team " + obj.Code);
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                using (SQLiteCommand command =
                       new SQLiteCommand("update teams set name=@name where code=@code",
                           connection))
                {
                    command.Parameters.AddWithValue("@name", obj.Name);
                    command.Parameters.AddWithValue("@code", obj.Code);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            logger.Info("team updated");
        }

        public Team Search(Team obj)
        {
            logger.Info("searching for team " + obj.Code);
            try
            {
                foreach (Team team in GetAll())
                {
                    if (team.Equals(obj))
                    {
                        logger.Info("--team found");
                        return team;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("--TeamDB prepare statement error: " + e.Message);
            }

            logger.Info("--team not found");
            return null;
        }
    }
}