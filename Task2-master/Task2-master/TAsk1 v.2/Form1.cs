﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

        Map Map = new Map(0,20,0,20);
        public Hero_label()
        {


            InitializeComponent();
            Attack_button.Enabled = false;
            GamEngine GM = new GamEngine(Map);
            Maparray = Map.maparray;
            Map.drawmap(Map_label,LAbel_hero);

            
            
            
           
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
                        mageAttack();
                        getitem();
                       
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
                        mageAttack();
                        getitem();
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
                        mageAttack();
                        getitem();
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
                        mageAttack();
                        getitem();
                    }

                        
                    break;
            }

            Map.drawmap(Map_label , LAbel_hero);
            


            
            
        }

        private void getitem()
        {
            if (Map.GetItemAtPostion(Map.Hero.X_coordinate, Map.Hero.Y_coordinate) != null)
            {
                Map.Hero.Gold += Map.itemarray[Map.Hero.X_coordinate, Map.Hero.Y_coordinate].Goldworth;
                Map.itemarray[Map.Hero.X_coordinate, Map.Hero.Y_coordinate] = null;
            }
        }

        private void mageAttack()
        {
            for (int i = 0; i < Map.MaxWidth_X1; i++)
            {
                for (int o = 0; o < Map.MaxHeight_Y1; o++)
                {
                    if(Map.enemeyArray[i,o] != null && Map.enemeyArray[i,o].Symbol == "M")
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
                Map.enemeyArray[currentenemyX, currentenemyY] = null;
            }
            Map.UpdateVision(Enemeys_textbox);
            Map.drawmap(Map_label, LAbel_hero);
            if(checkgoblin() == false)
            {
                Attack_button.Enabled = false;
            }
            

        }
    }
}