﻿using Microsoft.Data.Sqlite;
using Project.Interfaces;
using SQLitePCL;
using Dapper;
using System.Data.SqlClient;

namespace Project.Classes
{
    public class CostumerRepository : ICostumerRepository
    {
        public SqliteConnection GetConnection()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            return new SqliteConnection(connectionString);
        }

        public void AddUsers(int Id, string names, string surname, string SecondName, string Aboniment)
        {
           
            using (var db = GetConnection())
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                if (names != null)
                {
                    insertCommand.CommandText = "INSERT INTO Costumers VALUES (@Id, @Name, @Surname, @SecondName, @Date, @Aboniment);";
                    insertCommand.Parameters.AddWithValue("@Id", Convert.ToInt32(Id));
                    insertCommand.Parameters.AddWithValue("@Name", names);
                    insertCommand.Parameters.AddWithValue("@Surname", surname);
                    insertCommand.Parameters.AddWithValue("@SecondName", SecondName);
                    insertCommand.Parameters.AddWithValue("@Aboniment", Aboniment);
                    insertCommand.Parameters.AddWithValue("@Date", DateTime.Today.ToString());
                    insertCommand.ExecuteReader();
                }


                db.Close();
            }
        }
        public IEnumerable<Costumers> DeleteUser(int? id)
        {
            using (var db = GetConnection())
            {
                var result = db.Query<Costumers>($"DELETE FROM [Costumers] WHERE id = {id}");

                return result;
            }
        }

        public List<Costumers> GetUsers()
        {

            using(var db = GetConnection())
            {
                var result = db.Query<Costumers>("SELECT * FROM Costumers").ToList();

                return result;
            }
        }

        public IEnumerable<Costumers> UpdateUser(string names, int? id)
        {
            using (var db = GetConnection())
            {
                var result = db.Query<Costumers>($"UPDATE [Costumers] SET Name = {names},");

                return result;
            }
        }
    }
}
