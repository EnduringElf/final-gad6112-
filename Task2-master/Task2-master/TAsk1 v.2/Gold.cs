﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk1_v._2
{
    [Serializable]
    class Gold : Item
    {
        private Random random = new Random();
        

        
        public Gold(int X_coordinate, int Y_coordinate) : base(X_coordinate, Y_coordinate)
        {
            this.Goldworth = random.Next(0,6);
            
        }

        public override string ToString()
        {
            return " g ";
        }
    }
}
