using System.Collections.Generic;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Table;
using CloudStorageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount;

namespace PersonTableStorage.WebRole.Models
{
    public class Company
    {
        public IEnumerable<Person> Persons { get; set; }
        public string Name { get; private set; }

        public Company(string name)
        {
            Name = name;
        }

        public void PopulateWithPersons()
        {
            CreateTableIfNotExists();
            
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var tableClient = storageAccount.CreateCloudTableClient();
            
            var table = tableClient.GetTableReference("Persons");
            
            var query = new TableQuery<Person>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, Name));

            Persons = table.ExecuteQuery(query);
        }

        private void CreateTableIfNotExists()
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            var tableClient = storageAccount.CreateCloudTableClient();

            var table = tableClient.GetTableReference("Persons");
            if (!table.CreateIfNotExists()) return;
            
            var persons = new List<Person>
                              {
                                  new Person("Albert", "Einstein", Name)
                                      {
                                          Email = "albert@einstein.com"
                                      },
                                  new Person("Isaac", "Newton", Name)
                                      {
                                          Email = "isaac@newton.com"
                                      }
                              };
            var batchOperation = new TableBatchOperation();

            persons.ForEach(batchOperation.Insert);

            table.ExecuteBatch(batchOperation);
        }
    }
}