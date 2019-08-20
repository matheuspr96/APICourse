using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using APICourse.Model;

namespace APICourse.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet()
                ,
                FirstName = "Matheus"
                ,
                LastName = "Pimenta Reis"
                ,
                Address = "PÇ Renato Humberto Calcagno, N100, Bloco 5, Apto 44"
                ,
                Gender = "Masculino"
            };

        }

        public Person Update(Person person)
        {
            return person;
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet()
                 ,
                FirstName = "Matheus" + i
                 ,
                LastName = "Pimenta Reis" + i
                 ,
                Address = "PÇ Renato Humberto Calcagno, N100, Bloco 5, Apto 44" + i
                 ,
                Gender = "Masculino" + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

    }
}
