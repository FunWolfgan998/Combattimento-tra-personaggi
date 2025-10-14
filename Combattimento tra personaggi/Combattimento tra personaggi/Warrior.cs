using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combattimento_tra_personaggi
{
    internal class Warrior : Character
    {
        public Warrior() : base("Warrior", 100) { }

        public override int inflict_damage()
        {
            return 20;
        }

    }
}
