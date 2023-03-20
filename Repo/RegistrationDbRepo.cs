using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Motocliclisti.Entity;

namespace Motocliclisti.Repo
{
    public class RegistrationDbRepo : IRegistrationRepo
    {
        private static readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _props;

        public RegistrationDbRepo(string props)
        {
            _props = props;
        }

        public List<Registration> GetAll()
        {
            logger.Info("getting registration from DB");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                List<Registration> registrations = new List<Registration>();
                using (SQLiteCommand command = new SQLiteCommand("select * from registrations", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int participantCode = reader.GetInt16(reader.GetOrdinal("participant_code"));
                            int probeCode = reader.GetInt16(reader.GetOrdinal("probe_code"));
                            registrations.Add(new Registration(participantCode, probeCode));
                        }
                    }
                }

                connection.Close();
                return registrations;
            }
        }

        public void Add(Registration obj)
        {
            logger.Info("adding new registration");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();

                using (SQLiteCommand command =
                       new SQLiteCommand("insert into registrations(participant_code, probe_code)" +
                                         " values(@pcode, @prname)",
                           connection))
                {
                    command.Parameters.AddWithValue("@pcode", obj.ParticipantCode);
                    command.Parameters.AddWithValue("@prname", obj.ProbeCode);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("probe added");
        }

        public void Remove(Registration obj)
        {
            logger.Info("deleting probe " + obj.ParticipantCode.ToString() + " "
                        + obj.ProbeCode.ToString());
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("delete from registrations " +
                                                                 "where participant_code = @pcode and " +
                                                                 "probe_code = @prcode", connection))
                {
                    command.Parameters.AddWithValue("@pcode", obj.ParticipantCode);
                    command.Parameters.AddWithValue("@prcode", obj.ProbeCode);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("probe deleted");
        }

        public void Modify(Registration obj)
        {
            throw new NotImplementedException("no need to use update on registration");
        }

        public Registration Search(Registration obj)
        {
            logger.Info("searching for registracion " + obj.ParticipantCode + " " + obj.ProbeCode);
            try
            {
                foreach (Registration registration in GetAll())
                {
                    if (registration.Equals(obj))
                    {
                        logger.Info("--registration found");
                        return registration;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("--RegistrationDB prepare statement error: " + e.Message);
            }

            logger.Info("--registration not found");
            return null;
        }
    }
}