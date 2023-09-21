using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {

        public long Id {  get; private set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime Release_date { get; set; }
        public long Software_house_id { get; private set; }

        //COSTRUTTORE
        public Videogame(long id, string name, string overview, DateTime release_date, long software_house_id)
        {
            Id = id;
            Name = name;
            Overview = overview;
            Release_date = release_date;
            Software_house_id = software_house_id;
        }

        //METODI
        public override string ToString()
        {
            return $@"
ID: {Id} 
Nome videogame: {Name}
Trama: {Overview}
Data di rilascio: {Release_date.ToString("dd/MM/yyyy")}";
        }
    }
}
