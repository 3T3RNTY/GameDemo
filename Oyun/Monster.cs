using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyun
{
    public class Monster
    {
        public string? Name { get; set; }
        public int Level;
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public Monster(int level)
        {
            Level = level;
        }

        public void Slime()
        {
            Name = "Slime";
            Health = 20 + Level * 30;
            Attack = 5 + Level * 10;
            Defence = 0 + Level * 10;
        }
        public void Skeleton()
        {
            Name = "Iskelet";
            Health = 40 + Level * 30;
            Attack =  10+ Level * 10;
            Defence = 5 + Level * 10;
        }
        public void Zombie()
        {
            Name = "Zombi";
            Health = 50 + Level * 30;
            Attack = 10 + Level * 10;
            Defence = 10 + Level * 10;
        }

    }
}
