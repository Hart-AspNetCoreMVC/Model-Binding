using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBinding.Models
{
    public interface IRepository
    {   //People property to retrieve a person object from the collection
        IEnumerable<Person> People { get; }
        //an indexer for items to be stored or retrieved by using []
        Person this[int id] {
            get;
            set;
        }

    }
    public class MemoryRepository:IRepository
    {   
        private Dictionary<int,Person> _people = new Dictionary<int, Person>
        {
            [1]= new Person { PersonID = 1, FirstName = "Bob", LastName = "Smith", Role = Role.Admin},
            [2]= new Person { PersonID = 2, FirstName = "Anne", LastName = "Douglas", Role = Role.User},
            [1]= new Person { PersonID = 1, FirstName = "Joe", LastName = "Able", Role = Role.User},
            [1]= new Person { PersonID = 1, FirstName = "Mary", LastName = "Peters", Role = Role.Guest},
        };

        public IEnumerable<Person> People => _people.Values;

        public Person this[int id]
        {
            get { return _people.ContainsKey(id) ? _people[id] : null; }
            set { _people[id] = value; }
        }
    }
}
