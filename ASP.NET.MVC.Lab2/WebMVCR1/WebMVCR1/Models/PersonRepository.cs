using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCR1.Models
{
    public class PersonRepository
    {
        private List<Person> people = new List<Person>();
        public int NumberOfPeople
        {
            get
            {
                return people.Count();
            }
        }

        public IEnumerable<Person> GetAllResponses 
        { 
            get 
            { 
                return people; 
            }
        }

        public void AddResponse(Person p)
        {
            people.Add(p);
        }
    }
}