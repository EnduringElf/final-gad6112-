using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk1_v._2
{
    class Leader : Enemey
    {
        public Leader(int x_coordinate, int y_coordinate, int enemyDamage, string symbol, int startingHP) : base(x_coordinate, y_coordinate, enemyDamage, symbol, startingHP)
        {
            this.HP = 20;
            this.Damage = 2;


        }

        public override Movement Returnmove(Movement move = Movement.No_Movement)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return " L";
        }
    }
}
