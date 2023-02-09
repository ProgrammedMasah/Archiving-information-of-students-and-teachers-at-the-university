using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3
{
    class Books
    {
        //fields
        int id;
        int year_publication;
        string title;
        //constracter
        public Books(int id, int year_publication, string title)
        {
            Id = id;
            Year_publication = year_publication;
            Title = title;
        }
        //property
        public int Id { get; set; }
        public int Year_publication { get; set; }
        public string Title { get; set; }
        //method
        public override string ToString()
        {
            return "id: " + Id + "  year publication: " + Year_publication + "  title: " + Title;
        }
    }
}
