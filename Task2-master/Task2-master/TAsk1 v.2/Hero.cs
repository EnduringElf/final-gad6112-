using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk1_v._2
{
    [Serializable]
    class Hero : Charchter
    {
        public Hero(int x_coordinate, int y_coordinate, int hp, int damage ) : base(x_coordinate, y_coordinate, damage)
        {
            X_coordinate = x_coordinate;
            Y_coordinate = y_coordinate;
            hP = hp;
            MaxHP = hp;
            Damage = damage;

        }

        public override Movement Returnmove(Movement move = Movement.No_Movement)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "player stats:\n"+"HP:"+HP+"/"+MaxHP+"\nDamage: 2"+"\n["+X_coordinate+","+Y_coordinate+"]\n"+"Gold:"+this.gold;
        }
    }
}
