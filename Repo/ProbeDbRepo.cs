using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Motocliclisti.Entity;

namespace Motocliclisti.Repo
{
    public class ProbeDbRepo : IProbeRepo
    {
        private static readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _props;

        public ProbeDbRepo(string props)
        {
            _props = props;
        }

        public List<Probe> GetAll()
        {
            logger.Info("getting probes from DB");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                List<Probe> probes = new List<Probe>();
                using (SQLiteCommand command = new SQLiteCommand("select * from probes", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int code = reader.GetInt16(reader.GetOrdinal("code"));
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            probes.Add(new Probe(code, name));
                        }
                    }
                }

                connection.Close();
                return probes;
            }
        }

        public void Add(Probe obj)
        {
            logger.Info("adding new probe");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();

                using (SQLiteCommand command =
                       new SQLiteCommand("insert into probes(code, name) values(@code, @name)",
                           connection))
                {
                    command.Parameters.AddWithValue("@code", obj.Code);
                    command.Parameters.AddWithValue("@name", obj.Name);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("probe added");
        }

        public void Remove(Probe obj)
        {
            logger.Info("deleting probe " + obj.Code.ToString());
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("delete from probes where code = @code", connection))
                {
                    command.Parameters.AddWithValue("@code", obj.Code);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("probe deleted");
        }

        public void Modify(Probe obj)
        {
            logger.Info("updating probe " + obj.Code);
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                using (SQLiteCommand command =
                       new SQLiteCommand("update probes set name=@name where code=@code",
                           connection))
                {
                    command.Parameters.AddWithValue("@name", obj.Name);
                    command.Parameters.AddWithValue("@code", obj.Code);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            logger.Info("probe updated");
        }

        public Probe Search(Probe obj)
        {
            logger.Info("searching for probe " + obj.Code);
            try
            {
                foreach (Probe probe in GetAll())
                {
                    if (probe.Equals(obj))
                    {
                        logger.Info("--probe found");
                        return probe;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("--ProbeDB prepare statement error: " + e.Message);
            }
            logger.Info("--probe not found");
            return null;
        }
    }
}