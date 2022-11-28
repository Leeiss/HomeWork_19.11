using System;
namespace Project8
{
    public class Employer
    {
        public string name { get; }
        public string surname { get; }
        public Employer(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
    }
}