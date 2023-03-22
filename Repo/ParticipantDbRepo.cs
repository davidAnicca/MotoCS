using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using Motocliclisti.Entity;

namespace Motocliclisti.Repo
{
    public class ParticipantDbRepo : IParticipantsRepo
    {
        private static readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _props;

        public ParticipantDbRepo(string properties)
        {
            logger.Info("creating TeamDBRepo");
            _props = properties;
        }

        public List<Participant> GetAll()
        {
            logger.Info("getting participants from DB");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                List<Participant> participants = new List<Participant>();
                using (SQLiteCommand command = new SQLiteCommand("select * from participants", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int code = reader.GetInt16(reader.GetOrdinal("code"));
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            int teamCode = reader.GetInt16(reader.GetOrdinal("team_code"));
                            int capacity = reader.GetInt16(reader.GetOrdinal("capacity"));
                            participants.Add(new Participant(code, teamCode, capacity, name));
                        }
                    }
                }

                connection.Close();
                return participants;
            }
        }

        public void Add(Participant obj)
        {
            logger.Info("adding new participant");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();

                using (SQLiteCommand command =
                       new SQLiteCommand("insert into participants(code, team_code, capacity, name) " +
                                         "values(@code, @team_code, @capacity, @name)",
                           connection))
                {
                    command.Parameters.AddWithValue("@code", obj.Code);
                    command.Parameters.AddWithValue("@team_code", obj.Team);
                    command.Parameters.AddWithValue("@capacity", obj.Capacity);
                    command.Parameters.AddWithValue("@name", obj.Name);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("participant added");
        }

        public void Remove(Participant obj)
        {
            logger.Info("deleting participant " + obj.Code);
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                using (SQLiteCommand command =
                       new SQLiteCommand("delete from participants where code = @code", connection))
                {
                    command.Parameters.AddWithValue("@code", obj.Code);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("participant deleted");
        }

        public void Modify(Participant obj)
        {
            logger.Info("updating participant " + obj.Code);
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                using (SQLiteCommand command =
                       new SQLiteCommand("update participants set " +
                                         "name=@name, team_code=@team_code, capacity=@capacity" +
                                         " where code=@code",
                           connection))
                {
                    command.Parameters.AddWithValue("@code", obj.Code);
                    command.Parameters.AddWithValue("@name", obj.Name);
                    command.Parameters.AddWithValue("@team_code", obj.Team);
                    command.Parameters.AddWithValue("@capacity", obj.Capacity);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("participant updated");
        }

        public Participant Search(Participant obj)
        {
            logger.Info("searching for participant " + obj.Code);
            try
            {
                foreach (Participant participant in GetAll())
                {
                    if (participant.Equals(obj))
                    {
                        logger.Info("--participant found");
                        return participant;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("--ParticipantDB prepare statement error: " + e.Message);
            }

            logger.Info("--participant not found");
            return null;
        }

        public List<Participant> FindByTeam(Team team)
        {
            logger.Info("getting participants by team");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                List<Participant> participants = new List<Participant>();
                using (SQLiteCommand command = new SQLiteCommand(
                           "select * from participants where team_code = @teamCode",
                           connection))
                {
                    command.Parameters.AddWithValue("@teamCode", team.Code);
                    GetParticipantInfo(participants, command);
                }

                return participants;
            }
        }

        private void GetParticipantInfo(List<Participant> participants, SQLiteCommand command)
        {
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                GetInfo(participants, reader);
            }
        }

        static void GetInfo(List<Participant> participants, SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                int code = reader.GetInt32(reader.GetOrdinal("code"));
                string name = reader.GetString(reader.GetOrdinal("name"));
                int teamCode = reader.GetInt32(reader.GetOrdinal("team_code"));
                int capacity = reader.GetInt32(reader.GetOrdinal("capacity"));
                participants.Add(new Participant(code, teamCode, capacity, name));
            }
        }
    }
}