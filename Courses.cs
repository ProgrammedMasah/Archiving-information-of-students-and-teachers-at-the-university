using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3
{
    class Courses
    {
        //fields
        int id;
        int year;
        string course_name;
        //constracter
        public Courses(int id, int year, string course_name)
        {
            Id = id;
            Year = year;
            Course_name = course_name;
        }
        //property
        public int Id { get; set; }
        public int Year { get; set; }
        public string Course_name { get; set; }
        //method
        public override string ToString()
        {
            return "id: " + Id + "  year: " + Year + "  course name: " + Course_name;
        }
    }
}
