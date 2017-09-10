using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication6_20.data
{
    public class FamilyDb
    {
        private string _connectionString;
        public FamilyDb(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddFamily(Family family)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO FAMILIES VALUES
                                    (@lastName, @kids, @isChasidush, @type)";
            
            object kidsValue = family.Kids;
            if(kidsValue == null)
            {
                kidsValue = DBNull.Value;
            }
            command.Parameters.AddWithValue("@lastName", family.LastName);
            command.Parameters.AddWithValue("@kids", kidsValue);
            command.Parameters.AddWithValue("@isChasidush", family.IsChasidush);
            command.Parameters.AddWithValue("@type", family.Type);
            connection.Open();
            command.ExecuteNonQuery();

        }
        public IEnumerable<Family> GetFamilies()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Families";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Family> families = new List<Family>();
            while (reader.Read())
            {
                int? kids = null;
                if (reader["Kids"] != DBNull.Value)
                {
                    kids = (int)reader["Kids"];
                }
                Family f = new Family
                {
                    LastName = (string)reader["LastName"],
                    Kids = kids,
                    IsChasidush = (bool)reader["IsChasidush"],
                    Type = (Type)reader["Type"]
                };
                families.Add(f);
            }
            return families;
        }
    }
}
