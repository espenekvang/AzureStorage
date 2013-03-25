using System.Collections.Generic;

namespace PersonSQLDatabase.WebRole.Models
{
    public class Company
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}