using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk1_v._2
{
    class Leader : Enemey
    {
        public Leader(int x_coordinate, int y_coordinate) : base(x_coordinate, y_coordinate,2," L", 20)
        {
            X_coordinate = x_coordinate;
            Y_coordinate = y_coordinate;
            this.HP = 20;
            this.Damage = 2;
            this.gold = 2;


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
