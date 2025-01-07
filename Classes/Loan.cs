using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary.Classes
{
    public class Loan : IComparable<Loan>
    {

        public string Id { get; set; }
        public Student Student { get; set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime ReturnDate
        {
            get
            {
                return LoanDate.AddDays(NumberOfDays);
            }
        }

        public int CompareTo(Loan other)
        {
            
            int result = Student.CompareTo(other.Student);

            if (result == 0)
            {
                result = Book.CompareTo(other.Book);
            }

            return result;

        }

        public override string ToString()
        {
            return Student.Name + ", " + Book.Title + ": " + LoanDate.ToString() + " - " + ReturnDate.ToString();
        }

    }
}
