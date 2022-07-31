using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Organisasi_WebApi.Models
{
    public class AnggotaContext
    {
        public string ConnectionString { get; set; }

        public AnggotaContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<AnggotaItem> GetAllanggota()
        {
            List<AnggotaItem> list = new List<AnggotaItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anggota", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new AnggotaItem()
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            email = reader.GetString("email"),
                            phone = reader.GetString("phone"),
                            address = reader.GetString("address")
                        });
                    }
                }
            }
            return list;
        }

        public List<AnggotaItem> Getanggota(string id)
        {
            List<AnggotaItem> list = new List<AnggotaItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anggota WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new AnggotaItem()
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            email = reader.GetString("email"),
                            phone = reader.GetString("phone"),
                            address = reader.GetString("address")
                        });
                    }
                }
            }
            return list;
        }
    }
}
