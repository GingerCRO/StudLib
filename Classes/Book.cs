using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary.Classes
{
    public class Book : IComparable<Book>
    {

        public string Id { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string YearOfRelease { get; set; }
        public int QuantityNumber { get; set; }

        public int CompareTo(Book other)
        {
            
            int result = Author.CompareTo(other.Author);

            if (result == 0)
            {
                Title.CompareTo(other.Title);
            }

            return result;

        }

        public override string ToString()
        {
            return Author + ": " + Title;
        }

    }
}
