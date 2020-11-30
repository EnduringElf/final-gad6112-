using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk1_v._2
{
    class Shop : Tile
    {
        private weapon[] weaponarray;
        private Random random;
        private Charchter buyer;

        public Shop(int x_coordinate, int y_coordinate) : base(x_coordinate, y_coordinate)
        {
            weaponarray = new weapon[2];
            random = new Random();
            for (int i = 0;i< weaponarray.Length; i++)
            {
                Random_weapon(i);
            }
            


        }

        private void Random_weapon(int arrayorder)
        {
            int weapon = random.Next(0,3);
            if(weapon == 0)
            {
                weaponarray[arrayorder]= new Melee_weapon(500, 500, 'D' , Melee_weapon.Type.Dagger);
            }else if (weapon == 1)
            {
                weaponarray[arrayorder] = new Melee_weapon(500, 500, 'L', Melee_weapon.Type.Longsword);
            }else if(weapon == 2)
            {
                weaponarray[arrayorder] = new Ranged_weapon(500, 500, 'R', Ranged_weapon.Type.Rifle);
            }
            else
            {
                weaponarray[arrayorder] = new Ranged_weapon(500, 500, 'B', Ranged_weapon.Type.Longbow);
            }

        }
        public bool CanBuy(int num)
        {
            if (buyer.Gold >= weaponarray[0].Cost)
            {
                return true;
            }else if (buyer.Gold >= weaponarray[1].Cost)
            {
                return true;
            }
            else if(buyer.Gold >= weaponarray[2].Cost)
            {
                return true;
            }
            else
            {
                return false;
            }
            


        }

        internal Charchter Buyer { get => buyer; set => buyer = value; }
    }
}
