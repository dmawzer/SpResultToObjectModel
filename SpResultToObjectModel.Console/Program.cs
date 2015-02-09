using SpResultToObjectModel.BLL;
using SpResultToObjectModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpResultToObjectModel.Consolee
{
    class Program
    {
        private static Executer executer;

        static void Main(string[] args)
        {
            executer = new Executer();

            Customer customer = executer.Execute<Customer>("dbo.Sel_Customer");
            Console.WriteLine("Customer : {0} - {1}", customer.Id, customer.Name);

            Person person = executer.Execute<Person>("dbo.Sel_Person");
            Console.WriteLine("Person : {0} - {1} - {2}", person.Id, person.Name, person.TaxNumber);


            IList<Person> personList = executer.ExecuteForList<Person>("dbo.Sel_PersonList");
            foreach (var item in personList)
            {
                Console.WriteLine("Person : {0} - {1} - {2}", item.Id, item.Name, item.TaxNumber);
            }

            Console.ReadLine(); 
        }
    }
}
