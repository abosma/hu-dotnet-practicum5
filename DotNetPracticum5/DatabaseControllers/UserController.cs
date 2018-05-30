using DotNetPracticum5.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPracticum5.DatabaseControllers
{
    public static class UserController
    {
        static SQLiteConnection connection = DatabaseController.GetConnection();
        
        public static string InsertUser(string Username, string Password)
        {
            try
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
                    {
                        connection.Close();
                        return null;
                    }
                    else
                    {
                        int result = -1;
                        cmd.CommandText = "INSERT INTO USER VALUES(null, @Username, @Password, 10)";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        try
                        {
                            result = cmd.ExecuteNonQuery();
                            if(result > -1)
                            {
                                connection.Close();
                                return Password;
                            }
                            else
                            {
                                connection.Close();
                                return null;
                            }
                        }
                        catch(SQLiteException e)
                        {
                            Debug.WriteLine(e);
                            connection.Close();
                            return null;
                        }
                    }
                }
            }
            catch (SQLiteException e)
            {
                connection.Close();
                Debug.WriteLine(e);
                return null;
            }
        }

        public static User GetUserById(int UserId)
        {
            try
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "SELECT * FROM user WHERE userid = @ID";
                    cmd.Parameters.AddWithValue("@ID", UserId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User tempUser = new User();
                            tempUser.UserID = reader.GetInt32(0);
                            tempUser.Username = reader.GetString(1);
                            tempUser.Password = reader.GetString(2);
                            tempUser.Money = reader.GetFloat(3);
                            connection.Close();
                            return tempUser;
                        }
                    }
                    return null;
                }
            }
            catch (SQLiteException)
            {
                connection.Close();
                return null;
            }
        }

        public static User GetUserByUsername(string username)
        {
            try
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "SELECT * FROM user WHERE username = @Username";
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User tempUser = new User();
                            tempUser.UserID = reader.GetInt32(0);
                            tempUser.Username = reader.GetString(1);
                            tempUser.Password = reader.GetString(2);
                            tempUser.Money = reader.GetFloat(3);
                            connection.Close();
                            return tempUser;
                        }
                    }
                    return null;
                }
            }
            catch (SQLiteException)
            {
                connection.Close();
                return null;
            }
        }

        public static User GetUser(string Username, string Password)
        {
            try
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
                    {
                        connection.Close();
                        return null;
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM user WHERE username = @Username AND password = @Password";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if(reader["username"].ToString().Equals(Username) && reader["password"].ToString().Equals(Password))
                                {
                                    User tempUser = new User();
                                    tempUser.UserID = reader.GetInt32(0);
                                    tempUser.Username = reader.GetString(1);
                                    tempUser.Password = reader.GetString(2);
                                    tempUser.Money = reader.GetFloat(3);
                                    

                                    connection.Close();
                                    return tempUser;
                                }
                                else
                                {
                                    connection.Close();
                                    return null;
                                }
                            }
                        }
                    }
                    connection.Close();
                    return null;
                }
            }
            catch (SQLiteException e)
            {
                connection.Close();
                Debug.WriteLine(e);
                return null;
            }
        }
    }
}
