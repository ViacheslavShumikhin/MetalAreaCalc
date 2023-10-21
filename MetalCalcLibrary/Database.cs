using System;
using System.Data;
using MySql.Data.MySqlClient;
using Renci.SshNet;

namespace MetalCalcLibrary
{
    public class Database //Временно поменял с internal

    {
        private MySqlConnection connection;
        private ForwardedPortLocal tunnel;
        private SshClient sshClient;
        public void OpenConnection()
        {
            if (connection == null && tunnel == null && sshClient == null)
            {
                try
                {
                    // Создаем SSH-соединение
                    var sshConnInfo = new PasswordConnectionInfo(" ", "root", " ");
                    sshConnInfo.Timeout = TimeSpan.FromSeconds(30);
                    sshClient = new SshClient(sshConnInfo);
                    sshClient.Connect();
                    // Создаем SSH-туннель для подключения к базе данных
                    tunnel = new ForwardedPortLocal("localhost", 3306, "localhost", 3306);
                    sshClient.AddForwardedPort(tunnel);
                    tunnel.Start();
                    // Подключаемся к базе данных через SSH-туннель
                    connection = new MySqlConnection("server=;database=metalareacalc;uid=connect;password=");
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    throw;
                }
            }
        }

        public void CloseConnection() //Закрытие соединения
        {
            if(connection != null)
            {
                connection.Close();
            }
        }

        public void CloseTunnel() //Закрытие тунеля
        {
            if(tunnel != null)
            {
                tunnel.Stop();
                sshClient.Disconnect();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                {
                    dataAdapter.SelectCommand.Connection = connection;
                    dataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public object ExecuteScalar(string query)
        {
            // Создаем объект команды
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                // Открываем соединение, если оно закрыто
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                // Выполняем команду и получаем результат
                object result = command.ExecuteScalar();
                // Возвращаем результат
                return result;
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                Console.WriteLine($"Ошибка: {ex.Message}");
                throw;
            }
            finally
            {
                // Закрываем соединение
                connection.Close();
            }
        }
    }
}