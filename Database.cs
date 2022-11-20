using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PassHold_WF
{
    internal class Database
    {
        public static string connectionString = ("Data source=Database.db; Version=3; New = True; Compress = True;"); // Здесь указываются параметры базы данных

        public static SQLiteConnection? connection;
        public static SQLiteCommand? command;

        public static SQLiteConnection Create_Connect() // Начинаем работу с базой данных
        {
            connection = new SQLiteConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return connection;
        }

        public static SQLiteConnection Close_Connect() // Прекращаем работу с базой данных
        {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            connection.Close();
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            return connection;
        }

        public static void CreateTable() // Создаём таблицу, с проверкой существует ли она
        {
            command = new SQLiteCommand
            {
                Connection = connection,
                CommandText = "CREATE TABLE IF NOT EXISTS PassLog (ID VARCHAR(30), Login VARCHAR(40), Password VARCHAR(40))"
            };
            command.ExecuteNonQuery();
        }

        public static void InsertData(string id, string login, string password) // Передаём значение трёх переменных в команду и вставляем в базу данных
        {
            command = new SQLiteCommand
            {
                Connection = connection,
                CommandText = $"Insert into PassLog (ID, Login, Password) VALUES ('" + id + "', '" + login + "', '" + password + "')"
            };
            command.ExecuteNonQuery();
        }

        public static DataSet ReadData() // Считываем базу данных и передаём её в значение dataSet
        {
            SQLiteDataAdapter dataAdapter = new("SELECT * From PassLog", connection);

            DataSet dataSet = new();

            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static void DeleteData(string delete) // Удаление строки по выделенной ячейке ID
        {
            command = new SQLiteCommand
            {
                CommandText = "DELETE FROM PassLog WHERE ID='" + delete + "'",
                Connection = connection
            };
            command.ExecuteNonQuery();
        }
    }
}
