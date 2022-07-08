using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeshtable
{
    public class Recipe
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
        public Recipe(string name, string author)
        {
            _name = name;
            _author = author;
            _date = DateTime.Now;
        }
        public static bool operator==(Recipe other1, Recipe other2)
        {
            return (other1._name == other2._name) && (other1._author == other2._author) && (other1._date.Date == other2._date.Date);
        }
        public static bool operator !=(Recipe other1, Recipe other2)
        {
            return (other1._name != other2._name) || (other1._author != other2._author) || (other1._date.Date != other2._date.Date);
        }
    }
}
