using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combattimento_tra_personaggi
{
    public class Character
    {//mazzo circolare  primo che perde una carta perde 
        protected string name {get;set;}
        protected int heath_points { get; set; }

        public Character()
        {
            this.name = "Pippo Baldo";
            this.heath_points = 0;
        }
        public Character(string name, int heath_points)
        {
            this.name = name;
            this.heath_points = heath_points;
        }
        public virtual int inflict_damage()
        {
            return 5;
        }
        
        public void take_damage(int damage)
        {
            this.heath_points -= damage;
            if (heath_points < 0)
            {
                heath_points = 0;
            }
        }
        public bool IsAlive()
        {
            return heath_points > 0;
        }
        public virtual string InfoCard()
        {
            return $"Name: {this.name}\n HP: {this.heath_points} \n DP: {inflict_damage()}";
        }
    }
}
