using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Motocliclisti.Entity;

namespace Motocliclisti.Repo
{
    public class UserDbRepo : UserRepo
    {
        private static readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _props;

        public UserDbRepo(string properties)
        {
            logger.Info("creating UserDBRepo");
            _props = properties;
        }

        public List<User> GetAll()
        {
            logger.Info("getting users from DB");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                List<User> users = new List<User>();
                using (SQLiteCommand command = new SQLiteCommand("select * from users", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userName = reader.GetString(reader.GetOrdinal("name"));
                            string passwd = reader.GetString(reader.GetOrdinal("passwd"));
                            users.Add(new User(userName, passwd));
                        }
                    }
                }
                connection.Close();
                return users;
            }
        }

        public void Add(User obj)
        {
            logger.Info("adding new user");
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();

                using (SQLiteCommand command =
                       new SQLiteCommand("insert into users(name, passwd) values(@name, @passwd)",
                           connection))
                {
                    command.Parameters.AddWithValue("@name", obj.UserName);
                    command.Parameters.AddWithValue("@passwd", obj.Passwd);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            logger.Info("user added");
        }

        public void Remove(User obj)
        {
            logger.Info("deleting user " + obj.UserName);
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("delete from users where name = @name", connection))
                {
                    command.Parameters.AddWithValue("@name", obj.UserName);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("user deleted");
        }

        public void Modify(User obj)
        {
            logger.Info("updating user " + obj.UserName);
            using (SQLiteConnection connection = new SQLiteConnection(_props))
            {
                connection.Open();
                using (SQLiteCommand command =
                       new SQLiteCommand("update users set passwd=@passwd where name=@name",
                           connection))
                {
                    command.Parameters.AddWithValue("@passwd", obj.Passwd);
                    command.Parameters.AddWithValue("@name", obj.UserName);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            logger.Info("user updated");
        }

        public User Search(User obj)
        {
            logger.Info("searching for user " + obj.UserName);
            try
            {
                foreach (User user in GetAll())
                {
                    if (user.Equals(obj))
                    {
                        logger.Info("--user found");
                        return user;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("--UserDB prepare statement error: " + e.Message);
            }

            logger.Info("--user not found");
            return null;
        }
    }
}