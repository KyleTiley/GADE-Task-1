using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    //Question 2.1
    public abstract class Tile
    {
        protected int X;
        protected int Y;
        public enum TileType
        {
            Hero,
            Enemy,
            Gold,
            Weapon,
        }
        public Tile(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    public class Obstacle : Tile
    {
        public Obstacle() : base(1,1)
        {
            
        }
    }
    public class EmptyTile : Tile
    {
        public EmptyTile() : base(1, 1)
        {
            
        }
    }

    //Question 2.2
    public abstract class Character //must inherit from Tile how to do this??
    {
        int HP;
        int MaxHP;
        int Damage;
        int[] Vision;
        public enum Movement
        {
            NoMovement,
            Up,
            Down,
            Left,
            Right,
        }
    }
}
