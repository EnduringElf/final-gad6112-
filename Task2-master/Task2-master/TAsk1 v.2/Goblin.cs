using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk1_v._2
{
    class Goblin : Enemey
    {
        public Goblin(int x_coordinate, int y_coordinate) : base(x_coordinate, y_coordinate, 1, " G", 10)
        {
            X_coordinate = x_coordinate;
            Y_coordinate = y_coordinate;
            this.HP = 10;
        }

        public override Movement Returnmove(Movement move = Movement.No_Movement)
        {
            throw new NotImplementedException();
        }
        public  override string ToString()
        {
            return "Goblin[" + X_coordinate + "," + Y_coordinate + "]" +"Dmg:"+ base.damage +"HP:"+ this.HP;
        }
        
    }
}
