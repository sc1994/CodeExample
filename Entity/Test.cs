using System;
using System.Collections.Generic;

namespace Entity
{
    public class Person 
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Emails { get; set; }
        public List<PersonChild> Child { get; set; }
    }

    public class PersonChild
    {
        public string Sex { get; set; }
    }

    public class PersonDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<int> Emails { get; set; }
        public List<PersonChild> Child { get; set; }
    }

    public class PersonDtoChild
    {
        public string Sex { get; set; }
    }

    public class BaseEntity
    {

    }
}
