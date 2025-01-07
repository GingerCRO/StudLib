using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary.Classes
{
    public class Student : IComparable<Student>
    {

        public string Id { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UniversityName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public int CompareTo(Student other)
        {
            
            int result = Surname.CompareTo(other.Surname);

            if (result == 0)
            {
                result = Name.CompareTo(other.Name);
            }

            return result;

        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

    }
}
