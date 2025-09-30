using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OlympicsDataAccess.Entities
{
    public class CountryTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
