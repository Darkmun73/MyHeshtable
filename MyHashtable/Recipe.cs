using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeshtable
{
    class Recipe
    {
        public string _name;
        public string _author;
        public DateTime _date;
        public Recipe(string name, string author, DateTime date)
        {
            _name = name;
            _author = author;
            _date = date;
        }
        public static bool operator==(Recipe other1, Recipe other2)
        {
            return ((other1._name == other2._name) && (other1._author == other2._author) && (other1._date == other2._date));
        }
        public static bool operator !=(Recipe other1, Recipe other2)
        {
            return ((other1._name != other2._name) || (other1._author != other2._author) || (other1._date != other2._date));
        }
    }
}
