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
        public enum TileType {Hero, Enemy, Gold, Weapon}
        public Tile(int x, int y)   //constructor for the class Tile
        {
            this.X = x;
            this.Y = y;
        }
    }
    public class Obstacle : Tile    //Obstacle class is child of Tile class
    {
        public Obstacle(int x, int y) : base(x,y)   //constructor that calls the base class with the X and Y parameters
        {
            //set the border values here
        }
    }
    public class EmptyTile : Tile
    {
        public EmptyTile(int x, int y) : base(x, y)
        {
            //set the empty tile values here
        }
    }

    //Question 2.2
    public abstract class Character : Tile
    {
        protected int HP;
        protected int MaxHP;
        protected int Damage;
        protected int[] Vision = new int[4];
        public enum Movement { NoMovement, Up, Down, Left, Right }

        //Question 2.3
        public Character(int x, int y) : base(x,y)
        {
            //symbol part still needs to be done?????
        }
        public virtual void Attack(Character target)    //attacks target and decreases its health
        {

        }
        public bool IsDead()    //checks if character is dead
        {
            
        }
        public virtual bool CheckRange(Character target)    //checks if target is in range of a character
        {
            DistanceTo();
        }
        private int DistanceTo(target)  //determines absolute distance between a character and its target
        {

        }
        public void Move(MovementEnum move) //edits a unit's X and Y values to move it in a direction
        {

        }
        public abstract MovementEnum ReturnMove(MovementEnum move = 0)  //returns a direction of movement based on how the character should move
        {

        }
        public abstract override ToString() //overrides the Object ToString() method
        {

        }
    }

    //Question 2.4
    abstract class Enemy : Character
    {
        Random rnd = new Random();  //random object
        public Enemy()
        {
            
        }
        
    }
}
