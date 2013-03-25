using Microsoft.WindowsAzure.Storage.Table;

namespace PersonTableStorage.WebRole.Models
{
    public class Person : TableEntity
    {
        public Person(string firstName, string lastName, string company)
        {
            PartitionKey = company;
            RowKey = firstName;
            LastName = lastName;
        }

        public Person(){}

        public string FirstName { get { return RowKey; } }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}