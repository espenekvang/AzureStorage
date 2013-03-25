using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace PersonSQLDatabase.WebRole.Models
{
    public class Company
    {
        public IEnumerable<Person> Persons { get; set; }

        public void PopulateWithPersons()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AzureSqlDatabase"];
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();
                var persons = connection.Query<Person>("select * from Person");
            }
        }
    }
}