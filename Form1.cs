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
        public abstract override string ToString(); //overrides the Object ToString() method
    }

    //Question 2.4
    abstract class Enemy : Character
    {
        Random rnd = new Random();  //the random object
        public Enemy() : base() //still needs to receive all relevant values
        {
            
        }
        public override string ToString()   //ToString() object to be used by enemy subclasses
        {
            //output must look like: EnemyClassName at [X, Y] (Amount DMG)
        }
    }

    //Question 2.5
    public class Goblin : Enemy
    {
        public Goblin(int x, int y) : base(x, y)    //receives X and Y positions
        {
            //goblins have 10 HP
            //goblins do 1 damage
        }
        //need to do overridden ReturnMove() method 
    }

    //Question 2.6
    public class Hero : Character
    {
        public Hero(int x, int y, int HP) : base(x, y)    //receives X and Y positions but also HP???? fix
        {
            //hero does 2 damage
        }
        //need to do overridden ReturnMove() method
        public override string ToString()   //ToString() object for player stats
        {
        //output must look like:
        //Player Stats:
        //HP: HP / Max HP
        //  Damage: 2
        // [X, Y]
        }
    }
}
