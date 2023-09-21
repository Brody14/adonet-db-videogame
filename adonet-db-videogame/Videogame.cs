using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class Videogame
    {

        public long Id {  get; private set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime Release_date { get; set; }

        public Videogame(long id, string name, string overview, DateTime release_date)
        {
            Id = id;
            Name = name;
            Overview = overview;
            Release_date = release_date;
        }

        public override string ToString()
        {
            return $"ID: {Id}, videogame: {Name}, trama: {Overview}, data di rilascio: {Release_date}";
        }
    }
}
