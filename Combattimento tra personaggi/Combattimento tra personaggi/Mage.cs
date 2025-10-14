using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combattimento_tra_personaggi
{
    internal class Mage:Character
    {
        public Mage() : base("Mage", 70) { }

        public override int inflict_damage()
        {
            return 30;
        }

    }
}
