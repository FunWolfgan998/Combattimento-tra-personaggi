using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combattimento_tra_personaggi
{
    public class Mago : Character
    {
        public Mago() : base("Mago", 70)
        {
        }

        public override int inflict_damage()
        {
            return 30;
        }

    }
}
