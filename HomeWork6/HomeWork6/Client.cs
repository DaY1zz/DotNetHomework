using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    public class Client
    {
        public string Name { get; set; }
        public string VipShip { get; set; }

        public Client() { }

        public Client(string name,string vipship)
        {
            Name = name;
            VipShip = vipship;
        }
        public Client(string name)
        {
            Name = name;
            VipShip = "";
        }

        public override string ToString()
        {
            return $"{Name} {VipShip}";
        }
    }
}
