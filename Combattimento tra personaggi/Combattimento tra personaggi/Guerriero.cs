using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combattimento_tra_personaggi
{
    public class Guerriero : Character
    { 
        public Guerriero() : base("Guerriero", 100)
        {
        }

        public override int inflict_damage()
        {
            return 20;
        }

    }
}
