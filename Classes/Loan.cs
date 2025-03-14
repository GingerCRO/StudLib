﻿using System;
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
            
            int result = ReturnDate.CompareTo(other.ReturnDate);

            return result;

        }

        public override string ToString()
        {
            return "Student: " + Student.Name + " " + Student.Surname + ", " + "Book: " + Book.Title + ", " + "Return date: " + ReturnDate.ToShortDateString();
        }

    }
}
