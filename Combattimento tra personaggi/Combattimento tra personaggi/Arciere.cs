using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combattimento_tra_personaggi
{
    public class Arciere : Character
    {
        public Arciere() : base("Mago", 70)
        {
        }

        public override int inflict_damage()
        {
            return 25;
        }

    }
}
