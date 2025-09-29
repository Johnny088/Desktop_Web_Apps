using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OlympicsDataAccess.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public Medal Medal { get; set; }
        public int MedalID { get; set; }
        public Olympic Olympic { get; set; }
        public int OlympicID { get; set; }
        public Player Player { get; set; }
        public int PlayerID { get; set; }
    }
}
