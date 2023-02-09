using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3
{
    class Students : Person
    {
        //fields
        string year;
        string books_ids;
        //property
        public string Books_ids { get; set; }
        public string Year { get; set; }
        //constracter
        public Students(string id, string fname, string lname, string year, string courses_ids, string books_ids = "") : base(id, fname, lname, courses_ids)
        {
            Books_ids = books_ids;
            Year = year;
        }
        //method
        public override string ToString()
        {
            return base.ToString() + "  year: " + Year + "  books ids: " + Books_ids;
        }
    }

}
