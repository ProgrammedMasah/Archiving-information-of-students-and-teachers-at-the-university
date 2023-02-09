using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3
{
    class Teachers : Person
    {
        //fields
        string specialization;
        //property
        public string Specialization { get; set; }
        //constracter
        public Teachers(string id, string fname, string lname, string courses_ids, string specialization) : base(id, fname, lname, courses_ids)
        {
            Specialization = specialization;
        }
        //method
        public override string ToString()
        {
            return base.ToString() + "  specialization: " + Specialization;
        }
    }

}
