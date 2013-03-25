using System.Collections.Generic;
using PersonTableStorage.WebRole.Controllers;

namespace PersonTableStorage.WebRole.Models
{
    public class Company
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}