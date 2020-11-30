using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk1_v._2
{
    class Melee_weapon : weapon
    {

        public enum Type
        {
            Dagger, Longsword
        }
        public Melee_weapon(int X_coordinate, int Y_coordinate, char Symbol, Type weapon_type) : base(X_coordinate, Y_coordinate, Symbol)
        {
            if (weapon_type == Type.Dagger)
            {
                Weapon_type = "Dagger";
                Durability = 10;
                Damage = 3;
                Cost = 3;
                Range = 1;
            }else if (weapon_type == Type.Longsword)
            {
                Weapon_type = "Longsword";
                Durability = 6;
                Damage = 4;
                Cost = 5;
                Range = 1;
            }
            

        }
        
        
        public override string ToString()
        {
            return "MW";
        }

    }
}
