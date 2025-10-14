using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combattimento_tra_personaggi
{
    internal class Archer : Character
    {
        public Archer() : base("Archer", 80) { }

        public override int inflict_damage()
        {
            return 25;
        }

    }
}
