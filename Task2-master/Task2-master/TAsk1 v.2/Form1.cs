using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAsk1_v._2
{
    
    
    public partial class Hero_label : Form
    {
        public int Goblincount = 0;
        public int currentenemyX;
        public int currentenemyY;
        Tile[,] Maparray;
        public int shopitemselected;

        Map Map = new Map(0,20,0,20);
        public Hero_label()
        {


            InitializeComponent();
            Attack_button.Enabled = false;
            GamEngine GM = new GamEngine(Map);
            Maparray = Map.maparray;
            Map.drawmap(Map_label,LAbel_hero);
            loadshopitems();
            
            Map.shop.Buyer = Map.Hero;
            Buy_button.Enabled = false;
            //Map.Hero.weapon = Map.shop.Weaponarray[0];
            
            


        }

        private void loadshopitems()
        {
            shopinventory.Items.Add(Map.shop.Weaponarray[0].ToString());
            shopinventory.Items.Add(Map.shop.Weaponarray[1].ToString());
            shopinventory.Items.Add(Map.shop.Weaponarray[2].ToString());
        }

        private new void Move(Keys keys)
        {
            switch (keys)
            {
                case Keys.W:
                    if(Map.Hero.X_coordinate == Map.MinHeight_Y1 + 1)
                    {
                        
                    }
                    else
                    {
                        Map.Hero.Move(Charchter.Movement.Up);
                        Map.UpdateVision(Enemeys_textbox);
                        if (checkgoblin() == true) 
                        {
                            Attack_button.Enabled = true;
                        }
                        ;
                        enemyattack();
                        getitem();
                        moveenemeies();
                        
                       
                    }
                    break;
                case Keys.A:
                    if (Map.Hero.Y_coordinate == Map.MinWidth_X1 + 1)
                    {
                       
                    }
                    else 
                    {
                        Map.Hero.Move(Charchter.Movement.Left);
                        Map.UpdateVision(Enemeys_textbox);
                        if (checkgoblin() == true)
                        {
                            Attack_button.Enabled = true;
                        }
                        ;
                        enemyattack();
                        getitem();
                        moveenemeies();
                        
                    }
                        
                    break;
                case Keys.S:
                    if (Map.Hero.X_coordinate == Map.MaxWidth_X1-2)
                    {
                        
                    }
                    else
                    {
                        Map.Hero.Move(Charchter.Movement.Down);
                        Map.UpdateVision(Enemeys_textbox);
                        if (checkgoblin() == true)
                        {
                            Attack_button.Enabled = true;
                        }
                        ;
                        enemyattack();
                        getitem();
                        moveenemeies();
                        
                    }
                       
                    break;
                case Keys.D:
                    if(Map.Hero.Y_coordinate == Map.MaxHeight_Y1-2 )
                    {
                       
                    }
                    else
                    {
                        Map.Hero.Move(Charchter.Movement.Right);
                        Map.UpdateVision(Enemeys_textbox);
                        if (checkgoblin() == true)
                        {
                            Attack_button.Enabled = true;
                        }
                        ;
                        enemyattack();
                        getitem();
                        moveenemeies();
                       
                    }

                        
                    break;
            }

            Map.drawmap(Map_label , LAbel_hero);

            showshopitemselected();




        }

        private void showshopitemselected()
        {
            if (shopinventory.SelectedItem != null)
            {
                debugbox.Text = shopinventory.SelectedItem.ToString();
                
            }
            if(shopinventory.SelectedIndex == 0)
            {
                if (Map.Hero.Gold >= Map.shop.Weaponarray[0].Cost)
                {
                    Buy_button.Enabled = true;
                }
            }
            if (shopinventory.SelectedIndex == 1)
            {
                if (Map.Hero.Gold >= Map.shop.Weaponarray[1].Cost)
                {
                    Buy_button.Enabled = true;
                }
            }
            if (shopinventory.SelectedIndex == 2)
            {
                if (Map.Hero.Gold >= Map.shop.Weaponarray[2].Cost)
                {
                    Buy_button.Enabled = true;
                }
            }

        }

        private void moveenemeies()
        {
            for(int i = 0; i< Map.MaxWidth_X1 -2; i++)
            {
                for (int o = 0; o< Map.MaxHeight_Y1 - 2; o++)
                {
                    if(Map.enemeyArray[i,o] != null && Map.enemeyArray[i, o].Symbol == " G")
                    {
                        Movethisenemey(i, o, 'G');

                    }else if (Map.enemeyArray[i,o] != null && Map.enemeyArray[i,o].Symbol ==" L")
                    {
                        Movethisenemey(i, o, 'L');
                    }
                }
            }
        }

        private void Movethisenemey(int x, int y, char enemy)
        {
            Random random = new Random();
            int i = random.Next(0, 4);
            if (enemy == 'G')
            {
                switch (i)
                {
                    case 0:

                        if (Map.enemeyArray[x - 1, y] == null && x - 1 <= Map.MaxWidth_X1)
                        {
                            Map.enemeyArray[x, y].Move(Charchter.Movement.Down);
                            Map.enemeyArray[x - 1, y] = Map.enemeyArray[x, y];
                            Map.enemeyArray[x, y] = null;

                        }
                        else
                        {

                        }

                        break;
                    case 1:
                        if (Map.enemeyArray[x, y - 1] == null && y - 1 <= Map.MaxHeight_Y1)
                        {
                            
                            Map.enemeyArray[x, y].Move(Charchter.Movement.Left);
                            Map.enemeyArray[x, y - 1] = Map.enemeyArray[x, y];
                            Map.enemeyArray[x, y] = null;
                        }
                        else
                        {

                        }

                        break;
                    case 2:
                        if (Map.enemeyArray[x, y + 1] == null && y + 1 >= Map.MinHeight_Y1)
                        {
                            Map.enemeyArray[x, y].Move(Charchter.Movement.Right);
                            Map.enemeyArray[x, y + 1] = Map.enemeyArray[x, y];
                            Map.enemeyArray[x, y] = null;
                        }
                        else
                        {

                        }
                        break;
                    case 3:
                        if (Map.enemeyArray[x + 1, y] == null && x + 1 >= Map.MinWidth_X1)
                        {
                            Map.enemeyArray[x, y].Move(Charchter.Movement.Up);
                            Map.enemeyArray[x + 1, y] = Map.enemeyArray[x, y];
                            Map.enemeyArray[x, y] = null;
                        }
                        else
                        {

                        }

                        break;
                    case 4:
                        Map.enemeyArray[x, y].Move(Charchter.Movement.No_Movement);
                        break;
                }
            }else if (enemy == 'L')
            {
                if(x < Map.Hero.X_coordinate && x+1 >= Map.MinWidth_X1)
                {
                    if(Map.enemeyArray[x,y] != null)
                    {
                        Map.enemeyArray[x, y].Move(Charchter.Movement.Up);
                        Map.enemeyArray[x + 1, y] = Map.enemeyArray[x, y];
                        Map.enemeyArray[x, y] = null;
                    }
                    
                }
                if (x > Map.Hero.X_coordinate)
                {
                    if (Map.enemeyArray[x, y] != null)
                    {
                        Map.enemeyArray[x, y].Move(Charchter.Movement.Down);
                        Map.enemeyArray[x - 1, y] = Map.enemeyArray[x, y];
                        Map.enemeyArray[x, y] = null;
                    }
                     
                }
                if (y > Map.Hero.Y_coordinate)
                {
                    if (Map.enemeyArray[x, y] != null)
                    {
                        Map.enemeyArray[x, y].Move(Charchter.Movement.Left);
                        Map.enemeyArray[x, y - 1] = Map.enemeyArray[x, y];
                        Map.enemeyArray[x, y] = null;
                    }
                    
                }
                if (y < Map.Hero.Y_coordinate)
                {
                    if (Map.enemeyArray[x, y] != null)
                    {
                        Map.enemeyArray[x, y].Move(Charchter.Movement.Right);
                        Map.enemeyArray[x, y + 1] = Map.enemeyArray[x, y];
                        Map.enemeyArray[x, y] = null;

                    }
                   
                }
            }
            
        }

        private void getitem()
        {
            if (Map.GetItemAtPostion(Map.Hero.X_coordinate, Map.Hero.Y_coordinate) != null)
            {
                Map.Hero.Gold += Map.itemarray[Map.Hero.X_coordinate, Map.Hero.Y_coordinate].Goldworth;
                Map.itemarray[Map.Hero.X_coordinate, Map.Hero.Y_coordinate] = null;
            }
        }

        private void enemyattack()
        {
            for (int i = 0; i < Map.MaxWidth_X1-1; i++)
            {
                for (int o = 0; o < Map.MaxHeight_Y1-1; o++)
                {
                    //only mage attack
                    if(Map.enemeyArray[i,o] != null && Map.enemeyArray[i,o].Symbol == " M")
                    {
                        //attacking anything above this object
                       if(i + 1 == Map.Hero.X_coordinate && o == Map.Hero.Y_coordinate)
                       {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                       }
                       if (Map.enemeyArray[i + 1, o] != null)
                       {
                            Map.enemeyArray[i, o].Attack(Map.enemeyArray[i+1,o]);
                       }
                        //attacking anything below this object
                        if (i - 1 == Map.Hero.X_coordinate && o == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        if (Map.enemeyArray[i - 1, o] != null)
                        {
                            Map.enemeyArray[i, o].Attack(Map.enemeyArray[i - 1, o]);
                        }
                        //attacking anything to the right this object
                        if (i == Map.Hero.X_coordinate && o + 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        if (Map.enemeyArray[i , o +1 ] != null)
                        {
                            Map.enemeyArray[i, o].Attack(Map.enemeyArray[i , o + 1]);
                        }
                        //attacking anything to the left this object
                        if (i == Map.Hero.X_coordinate && o - 1  == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        if (Map.enemeyArray[i, o - 1] != null)
                        {
                            Map.enemeyArray[i, o].Attack(Map.enemeyArray[i , o-1]);
                        }
                        //above and to the right
                        if (i +1== Map.Hero.X_coordinate && o + 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        if (Map.enemeyArray[i+1, o + 1] != null)
                        {
                            Map.enemeyArray[i, o].Attack(Map.enemeyArray[i + 1 , o + 1]);
                        }
                        //above and to the left
                        if (i + 1 == Map.Hero.X_coordinate && o - 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        if (Map.enemeyArray[i + 1, o - 1] != null)
                        {
                            Map.enemeyArray[i, o].Attack(Map.enemeyArray[i+ 1, o - 1]);
                        }

                        //below and to the left
                        if (i - 1 == Map.Hero.X_coordinate && o + 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        if (Map.enemeyArray[i -1 , o + 1] != null)
                        {
                            Map.enemeyArray[i, o].Attack(Map.enemeyArray[i - 1, o - 1]);
                        }

                        //below and to the right
                        if (i - 1 == Map.Hero.X_coordinate && o + 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        if (Map.enemeyArray[i - 1, o + 1] != null)
                        {
                            Map.enemeyArray[i, o].Attack(Map.enemeyArray[i - 1, o - 1]);
                        }
                    }
                    if(Map.enemeyArray[i,o] != null && Map.enemeyArray[i,o].Symbol == " G")
                    {
                        //attacking anything above this object
                        if (i + 1 == Map.Hero.X_coordinate && o == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        //attacking anything below this object
                        if (i - 1 == Map.Hero.X_coordinate && o == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        //attacking anything to the right this object
                        if (i == Map.Hero.X_coordinate && o + 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        //attacking anything to the left this object
                        if (i == Map.Hero.X_coordinate && o - 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        //above and to the right
                        if (i + 1 == Map.Hero.X_coordinate && o + 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        //above and to the left
                        if (i + 1 == Map.Hero.X_coordinate && o - 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        //below and to the left
                        if (i - 1 == Map.Hero.X_coordinate && o + 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                        //below and to the right
                        if (i - 1 == Map.Hero.X_coordinate && o + 1 == Map.Hero.Y_coordinate)
                        {
                            Map.enemeyArray[i, o].Attack(Map.Hero);
                        }
                    }
                    
                }
            }
        }

        private bool checkgoblin()
        {
            
            Goblincount = 0;


            for (int i = 0; i < Map.MaxWidth_X1; i++)
            {
                for (int o = 0; o < Map.MaxHeight_Y1; o++)
                {
                    if (i == Map.Hero.X_coordinate + 1 && o == Map.Hero.Y_coordinate && Map.enemeyArray[i, o] != null)
                    {
                        currentenemyX = i;
                        currentenemyY = o;
                        Goblincount++;
                        return true;
                    }
                    if (i == Map.Hero.X_coordinate - 1 && o == Map.Hero.Y_coordinate && Map.enemeyArray[i, o] != null)
                    {
                        currentenemyX = i;
                        currentenemyY = o;
                        Goblincount++;
                        return true;
                    }
                    if (i == Map.Hero.X_coordinate && o == Map.Hero.Y_coordinate + 1 && Map.enemeyArray[i, o] != null)
                    {
                        currentenemyX = i;
                        currentenemyY = o;
                        Goblincount++;
                        return true;
                    }
                    if (i == Map.Hero.X_coordinate && o == Map.Hero.Y_coordinate - 1 && Map.enemeyArray[i, o] != null)
                    {
                        currentenemyX = i;
                        currentenemyY = o;
                        Goblincount++;
                        return true;
                    }
                    if (i == Map.Hero.X_coordinate + 1 && o == Map.Hero.Y_coordinate + 1 && Map.enemeyArray[i, o] != null)
                    {
                        currentenemyX = i;
                        currentenemyY = o;
                        Goblincount++;
                        return true;
                    }
                    if (i == Map.Hero.X_coordinate + 1 && o == Map.Hero.Y_coordinate - 1 && Map.enemeyArray[i, o] != null)
                    {
                        currentenemyX = i;
                        currentenemyY = o;
                        Goblincount++;
                        return true;
                    }
                    if (i == Map.Hero.X_coordinate - 1 && o == Map.Hero.Y_coordinate + 1 && Map.enemeyArray[i, o] != null)
                    {
                        currentenemyX = i;
                        currentenemyY = o;
                        Goblincount++;
                        return true;
                    }
                    if (i == Map.Hero.X_coordinate - 1 && o == Map.Hero.Y_coordinate - 1 && Map.enemeyArray[i, o] != null)
                    {
                        currentenemyX = i;
                        currentenemyY = o;
                        Goblincount++;
                        return true;
                    }
                }
            }
            return false;
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.W)
            {
                Move(keyData);
                displaykeypress("W");
            }
            if(keyData == Keys.A)
            {
                Move(keyData);
                displaykeypress("A");
            }
            if(keyData == Keys.S)
            {
                Move(keyData);
                displaykeypress("S");
            }
            if(keyData == Keys.D)
            {
                Move(keyData);
                displaykeypress("D");
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void displaykeypress(string key)
        {
            Keypress.Text = key;
        }

        private void Enemeys_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Attack_button_Click(object sender, EventArgs e)
        {
            
            Map.enemeyArray[currentenemyX, currentenemyY].Attack(Map.Hero);
            Map.Hero.Attack(Map.enemeyArray[currentenemyX,currentenemyY]);
            if(Map.enemeyArray[currentenemyX,currentenemyY].HP <= 0)
            {
                Map.Hero.loot(Map.enemeyArray[currentenemyX, currentenemyY]);
                Map.enemeyArray[currentenemyX, currentenemyY] = null;
            }
            Map.UpdateVision(Enemeys_textbox);
            Map.drawmap(Map_label, LAbel_hero);
            if(checkgoblin() == false)
            {
                Attack_button.Enabled = false;
            }
            

        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            FileStream outputfile = new FileStream("rougelitesave.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(outputfile,Map);
            
            outputfile.Close();
        }

        private void Load_button_Click(object sender, EventArgs e)
        {
            FileStream inputfile = new FileStream("rougelitesave.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Map mapfromfile = (Map)binaryFormatter.Deserialize(inputfile); 
            inputfile.Close();


            Map = mapfromfile;
        }

        private void shopinventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }

        private void Buy_button_Click(object sender, EventArgs e)
        {
            if (shopinventory.SelectedIndex == 0)
            {
                Map.Hero.weapon = Map.shop.Weaponarray[0];
                Map.Hero.Gold -= Map.shop.Weaponarray[0].Cost;
                
                Map.shop.newitem(0);
                
                shopreload();
                
                
                
            }else if (shopinventory.SelectedIndex == 1)
            {
                Map.Hero.weapon = Map.shop.Weaponarray[1];
                Map.Hero.Gold -= Map.shop.Weaponarray[1].Cost;
                //shopinventory.Items.RemoveAt(1);
                Map.shop.newitem(1);
                shopreload();

            }
            else if (shopinventory.SelectedIndex == 2)
            {
                Map.Hero.weapon = Map.shop.Weaponarray[2];
                Map.Hero.Gold -= Map.shop.Weaponarray[2].Cost;
                //shopinventory.Items.RemoveAt(2);
                Map.shop.newitem(2);
                shopreload();

            }
            Map.drawmap(Map_label,LAbel_hero);
            Buy_button.Enabled = false;
        }

        private void shopreload()
        {
            shopinventory.Items.Clear();

            shopinventory.Items.Add(Map.shop.Weaponarray[0].ToString());
            shopinventory.Items.Add(Map.shop.Weaponarray[1].ToString());
            shopinventory.Items.Add(Map.shop.Weaponarray[2].ToString());
        }
    }
}
