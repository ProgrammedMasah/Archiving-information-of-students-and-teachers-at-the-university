using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3
{
    class Person
    {//fields
        string id;
        string fname;
        string lname;
        string courses_ids;
        //constracter
        public Person(string id, string fname, string lname, string courses_ids)
        {
            Id = id;
            Fname = fname;
            Lname = lname;
            if (courses_ids.Trim() == "") throw new Exception("Courses Ids Null");
            Courses_ids = courses_ids;
        }
        //property
        public string Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Courses_ids { get; set; }
        //method
        public override string ToString()
        {
            return "id: " + Id + "  first name: " + Fname + "  last name: " + Lname + "  courses ids: " + Courses_ids;
        }
    }
}
