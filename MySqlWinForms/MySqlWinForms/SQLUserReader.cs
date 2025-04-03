using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlWinForms
{
    class SQLUserReader
    {
        private string MyConnectionString = "server=127.0.0.1;uid=root;pwd=vertrigo;database=users";
        public List<UserInfo> ReadUsers()
        {
            List<UserInfo> result = new List<UserInfo>();
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                const string quary = "SELECT login, name, surname, birthday, password, email from users";
                MySqlCommand command = new MySqlCommand(quary, conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Login = reader.GetString("login");

                        UserInfo us = new UserInfo(Login);
                        us.Name = reader.GetString("name");
                        us.Surname = reader.GetString("surname");
                        us.Birhday = reader.GetDateTime("birthday");
                        us.Password = reader.GetString("password");
                        us.Email = reader.GetString("email");
                        result.Add(us);
                    }
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
            return result;
        }

        public bool DeleteUser(string login)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                string query = "DELETE FROM users WHERE login = @login";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@login", login);

                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool AddUser(UserInfo user)  // Метод для добавления пользователя
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                string query = "INSERT INTO users (login, name, surname, birthday, password, email) " +
                               "VALUES (@login, @name, @surname, @birthday, @password, @email)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@login", user.Login);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@birthday", user.Birhday);
                command.Parameters.AddWithValue("@password", user.Password); //**Важно: Пароль должен быть предварительно захэширован!**
                command.Parameters.AddWithValue("@email", user.Email);

                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0; // Возвращает true, если добавление прошло успешно
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
