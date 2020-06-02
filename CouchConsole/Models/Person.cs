using System;
namespace CouchConsole.Models
{
    public class Person
    {
        public string Id { get; set; }        public string Name { get; set; }        public Person()        { }        public Person(string id, string name)        {            Id = id;            Name = name;        }
    }
}

