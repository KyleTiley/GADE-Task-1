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
    abstract class Tile //Base class for all in-game objects that have positions on the map
    {
        protected int x;
        protected int y;
        public enum TileType { Hero, Enemy, Gold, Weapon }    //Used to determine what kind of tiles to create
        public Tile(int _x, int _y)   //Constructor for the class Tile
        {
            x = _x;
            y = _y;
        }
    }
    class Obstacle : Tile
    {
        public Obstacle(int _x, int _y) : base(_x,_y)   //Constructor that calls the base class with the X and Y parameters
        {
            //sets the borders
        }
    }
    class EmptyTile : Tile
    {
        public EmptyTile(int _x, int _y) : base(_x, _y)
        {
            //sets the empty tiles
        }
    }

    //Question 2.2
    abstract class Character : Tile
    {
        protected int hp;
        protected int maxHp;
        protected int damage;
        protected int[] visionTiles = new int[4];
        public enum MovementEnum { NoMovement, Up, Down, Left, Right }

        //Question 2.3
        public Character(int _x, int _y, char _symbol) : base(_x,_y)  //Character constructor wityh x and y positions, and a symbol
        {
            //??? must still delegate variable settings to Tile
        }
        public virtual void Attack(Character target)    //Attacks target and decreases its health
        {

        }
        public bool IsDead()    //Checks if character is dead
        {
            //return of true or false still required
        }
        public virtual bool CheckRange(Character target)    //Checks if target is in range of a character
        {
            //determines distance via the DistanceTo() method
            //return of true or false still required
        }
        private int DistanceTo(target)  //determines absolute distance between a character and its target
        {
            //return of distance integer still required
            //??? why is target used here
        }
        public void Move(MovementEnum move) //Edits a unit's X and Y values to move it in a direction
        {
            
        }
        public abstract MovementEnum ReturnMove(MovementEnum move = 0);  //Returns a direction of movement based on how the character should move
        public abstract override string ToString(); //Overrides the Object ToString() method
    }

    //Question 2.4
    abstract class Enemy : Character
    {
        Random rnd = new Random();  //The random object
        public Enemy(int _x, int _y, int _damage, int _hp, int _maxHp, char _symbol) : base(_x, _y, _symbol)
        {
            damage = _damage;
            hp = _hp;
            maxHp = _maxHp;
        }
        public override string ToString()   //ToString() object to be used by enemy subclasses
        {
            return "EnemyClassName at [X, Y] (Amount DMG)"; //??? needs to be implemented properly
        }
    }

    //Question 2.5
    class Goblin : Enemy
    {
        public Goblin(int _x, int _y) : base(_x, _y)    //??? figure out how to delegate properly
        {
            //goblins have 10 HP
            //goblins do 1 damage
        }
        public override MovementEnum ReturnMove()    //Randoms a direction for the Goblin to move
        {
            //??? implement random direction picker
            //return of MovementEnum still required
        }
    }

    //Question 2.6
    class Hero : Character
    {
        public Hero(int _x, int _y, int _hp) : base(_x, _y)    //??? figure out how to delegate properly
        {
            //hero always does 2 damage
        }
        public override MovementEnum ReturnMove(//??? is MovementEnum move = MovementEnum.NoMovement correct)
        {
            //receives directional button press
            //return of number for movement indication still required
        }
        public override string ToString()   //ToString() object for player stats
        {
            return "Player Stats:" + "\n" + "HP: HP/Max HP" + "Damage: 2" + "[X,Y]"; //??? needs to be implemented properly
        }
    }
}
