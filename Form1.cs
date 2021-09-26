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
        TileType tileType;
        public Tile(int _x, int _y)   //Constructor
        {
            x = _x;
            y = _y;
        }
        public Tile(int _x, int _y, TileType _tileType)   //Constructor
        {
            x = _x;
            y = _y;
            tileType = _tileType;
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
        protected int[] visionTiles = new int[4];   //Will hold North, South, East, West
        public enum MovementEnum { NoMovement, Up, Down, Left, Right }
        MovementEnum move;

        //Question 2.3
        public Character(int _x, int _y, char _symbol) : base(_x,_y)  //Character constructor wityh x and y positions, and a symbol
        {
            x = _x;
            y = _y;
        }
        public virtual void Attack(Character target)    //Attacks target and decreases its health
        {
            //??? must implement properly
        }
        public bool IsDead()    //Checks if character is dead
        {
            if (hp > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public virtual bool CheckRange(Character target)    //Checks if target is in range of a character
        {
            if (DistanceTo(target) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int DistanceTo(Character target)  //Determines absolute distance between a character and its target
        {
            return ((y-target.y)+(x-target.x));
        }
        public void Move(MovementEnum move) //Edits a unit's X and Y values to move it in a direction
        {
            if (move == MovementEnum.Up)
            {
                y++;
            }
            else if (move == MovementEnum.Down)
            {
                y--;
            }
            else if (move == MovementEnum.Left)
            {
                x--;
            }
            else if (move == MovementEnum.Right)
            {
                x++;
            }
            else if (move == MovementEnum.NoMovement)
            {
                //nothing yet
            }
        }
        public abstract MovementEnum ReturnMove(MovementEnum move = 0);  //Returns a direction of movement based on how the character should move
        public abstract override string ToString(); //Overrides the Object ToString() method
    }

    //Question 2.4
    abstract class Enemy : Character
    {
        protected Random randomNum;  //The random object
        public Enemy(int _x, int _y, int _damage, int _hp, int _maxHp, char _symbol) : base(_x, _y, _symbol)
        {
            damage = _damage;
            hp = _hp;
            maxHp = _maxHp;
        }
        public override string ToString()   //ToString() object to be used by enemy subclasses
        {
            return "Goblin at [" + x + "," + y + "] " + "(" + damage + ")";
        }
    }

    //Question 2.5
    class Goblin : Enemy
    {
        public Goblin(int _x, int _y, int _damage, int _hp, int _maxHp, char _symbol) : base(_x, _y, _damage, _hp, _maxHp, _symbol)    //??? figure out how to delegate properly
        {
            _maxHp = 10;
            _damage = 1;
            _symbol = 'G';
        }
        public override MovementEnum ReturnMove(MovementEnum move)    //Randoms a direction for the Goblin to move
        {
            return move;    //??? needs work and randomisation
        }
    }

    //Question 2.6
    class Hero : Character
    {
        public Hero(int _x, int _y, int _damage, int _hp, int _maxHp, char _symbol) : base(_x, _y, _symbol)    //??? figure out how to delegate properly
        {
            hp = _hp;
            maxHp = _maxHp;
            _damage = 2;
        }
        public override MovementEnum ReturnMove(MovementEnum move)    //Takes direction from keyboard or form buttons
        {
            return move;    //??? needs work
        }
        public override string ToString()   //ToString() object for player stats
        {
            return "Player Stats:" + "\n" + hp + "/" + maxHp+ "\n" + "Damage: 2" + "\n" + "[" + x + "," + y + "]"; //??? needs to be implemented properly
        }
    }

    //Question 3.1
    class Map
    {
        char[,] tiles;  //??? must initialise with outside border of obstacles
        Hero player;
        Enemy[] enemies;
        int mapWidth;
        int mapHeight;
        Random randomNum;

        //Question 3.2
        int randomGenerator(int min, int max)
        {
            return randomNum.Next(min, max);
        }
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numOfEnemies)
        {
            mapWidth = randomGenerator(minWidth, maxWidth + 1);
            mapHeight = randomGenerator(minHeight, maxHeight + 1);
            tiles = new char[mapWidth, mapHeight];
            Tile Create()
            {

            }
        }

    }
}
