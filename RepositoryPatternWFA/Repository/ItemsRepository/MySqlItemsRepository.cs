using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternWFA.Models;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RepositoryPatternWFA.Repository.ItemsRepository
{
    public class MySqlItemsRepository : IRepositoryItems
    {
        private string connectionString { get; set; }

        public MySqlItemsRepository(string host, string database, string user, string password)
        {
            connectionString = "Database=" + database + ";Datasource=" + host + ";User=" + user + ";Password=" + password;
        }

        public List<Items> GetAll()
        {
            List<Items> allItems = new List<Items>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand queryCommand = connection.CreateCommand();
            queryCommand.CommandText = "SELECT * FROM test_db.Items";

            try
            {
                connection.Open();
                MySqlDataReader reader;

                reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    allItems.Add(new Items { Id = reader.GetInt32(0), Name = reader.GetString(1), Price = reader.GetInt32(2) });
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return allItems;
        }
        public int Insert(Items value)
        {
            int rows = 0;
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand queryCommand = connection.CreateCommand();
            queryCommand.CommandText = $"INSERT INTO test_db.Items(name, price) VALUES ('{value.Name}', {value.Price})";
            try
            {
                connection.Open();
                rows = queryCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return rows;
        }

        public int Update(int id, Items value)
        {
            int rows = 0;
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand queryCommand = connection.CreateCommand();
            queryCommand.CommandText = $"UPDATE test_db.Items SET name = '{value.Name}', price = {value.Price} WHERE id = {id};";
            try
            {
                connection.Open();
                rows = queryCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                MessageBox.Show("Updated!");
            }
            return rows;
        }
    }
}
