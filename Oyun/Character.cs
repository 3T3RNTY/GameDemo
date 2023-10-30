using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyun
{
    public class Character
    {
        public string? Name { get; set; }
        public string? Class { get; set; }
        public int Max_Health { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Level { get; set; }
        public void Swordmaster()
        {
            Class = "Kılıç ustası";
            Max_Health = 100;
            Health = 100;
            Attack = 30;
            Defence = 10;
            Level = 1;
        }
        public void Knight()
        {
            Class = "Şovalye";
            Max_Health = 140;
            Health = 140;
            Attack = 20;
            Defence = 20;
            Level = 1;
        }
        public void Archer()
        {
            Class = "Okçu";
            Max_Health = 80;
            Health = 80;
            Attack = 30;
            Defence = 10;
            Level = 1;
        }
    }
}
