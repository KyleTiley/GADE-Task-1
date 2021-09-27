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
        protected char symbol;
        public enum TileType { Hero, Enemy, Gold, Weapon }   //Used to determine what kind of tiles to create
        public Tile(int _x, int _y)   //Constructor
        {
            x = _x;
            y = _y;
        }
    }
    class Obstacle : Tile
    {
        public Obstacle(int _x, int _y) : base(_x,_y)
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
        public Tile[] visionTiles;   //Will hold North, South, East, West
        public enum MovementEnum { NoMovement, Up, Down, Left, Right }

        //Question 2.3
        public Character(int _x, int _y, char _symbol) : base(_x,_y)  //Character constructor wityh x and y positions, and a symbol
        {
            symbol = _symbol;
        }
        public virtual void Attack(Character target)    //Attacks target and decreases its health
        {
            target.hp = target.hp - damage;
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
            return (Math.Abs(y-target.y)+Math.Abs(x-target.x));
        }
        public void Move(MovementEnum move) //Edits a unit's X and Y values to move it in a direction
        {
            if (move == MovementEnum.Up)
            {
                y--;
            }
            else if (move == MovementEnum.Down)
            {
                y++;
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
                //Nothing
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
            return symbol + " at [" + x + "," + y + "] " + "(" + damage + ")";
        }
    }

    //Question 2.5
    class Goblin : Enemy
    {
        public Goblin(int _x, int _y, int _damage, int _hp, int _maxHp, char _symbol) : base(_x, _y, _damage, _hp, _maxHp, _symbol)
        {
            maxHp = 10;
            damage = 1;
            symbol = 'G';
        }
        public override MovementEnum ReturnMove(MovementEnum move)    //Randoms a direction for the Goblin to move
        {
            Random randomNum = new Random();
            MovementEnum inputtedMovement = MovementEnum.NoMovement;
            while(inputtedMovement == MovementEnum.NoMovement)
            {
                int newRandom = randomNum.Next(1, 5);
                if (newRandom == 1 && visionTiles[(int)MovementEnum.Up] is EmptyTile)
                {
                    inputtedMovement = MovementEnum.Up;
                }
                else if (newRandom == 2 && visionTiles[(int)MovementEnum.Down] is EmptyTile)
                {
                    inputtedMovement = MovementEnum.Down;
                }
                else if (newRandom == 3 && visionTiles[(int)MovementEnum.Left] is EmptyTile)
                {
                    inputtedMovement = MovementEnum.Left;
                }
                else if (newRandom == 4 && visionTiles[(int)MovementEnum.Right] is EmptyTile)
                {
                    inputtedMovement = MovementEnum.Right;
                }
                else
                {
                    inputtedMovement = MovementEnum.NoMovement;
                }
            }
            return inputtedMovement;
        }
    }

    //Question 2.6
    class Hero : Character
    {
        public Hero(int _x, int _y, int _hp, int _maxHp, char _symbol) : base(_x, _y, _symbol)
        {
            hp = _hp;
            maxHp = _maxHp;
            damage = 2;
        }
        public override MovementEnum ReturnMove(MovementEnum move)    //Takes direction from keyboard or form buttons
        {
            switch (move)
            {
                case MovementEnum.Up:
                    if(visionTiles[(int)MovementEnum.Up] is EmptyTile)
                    {
                        return MovementEnum.Up;
                    }
                    else
                    {
                        return MovementEnum.NoMovement;
                    }
                case MovementEnum.Down:
                    if (visionTiles[(int)MovementEnum.Down] is EmptyTile)
                    {
                        return MovementEnum.Down;
                    }
                    else
                    {
                        return MovementEnum.NoMovement;
                    }
                case MovementEnum.Left:
                    if (visionTiles[(int)MovementEnum.Left] is EmptyTile)
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return MovementEnum.NoMovement;
                    }
                case MovementEnum.Right:
                    if (visionTiles[(int)MovementEnum.Right] is EmptyTile)
                    {
                        return MovementEnum.Right;
                    }
                    else
                    {
                        return MovementEnum.NoMovement;
                    }
                default: return MovementEnum.NoMovement;
            }
        }
        public override string ToString()   //ToString() object for player stats
        {
            return "Player Stats:" + "\n" + hp + "/" + maxHp+ "\n" + "Damage: " + damage + "\n" + "[" + x + "," + y + "]";
        }
    }

    //Question 3.1
    public class Map
    {
        Tile[,] tiles;
        Hero player;
        Enemy[] enemies;
        public int mapWidth;
        public int mapHeight;
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
            tiles = new Tile[mapWidth, mapHeight];
            enemies = new Enemy[numOfEnemies];
            Create(Tile.TileType.Hero);
            for (int i = 0; i<numOfEnemies;i++)
            {
                Create(Tile.TileType.Enemy);
            }
            UpdateVision();
        }
        public void UpdateVision()
        {
            //??? confused
        }
        private Tile Create(Tile.TileType _type)  //??? fix
        {
            int _x = randomGenerator(2, mapWidth-2);
            int _y = randomGenerator(2, mapHeight - 2);
            while(tiles[_x,_y] is EmptyTile != true)
            {
                _x = randomGenerator(2, mapWidth - 2);
                _y = randomGenerator(2, mapHeight - 2);
            }
            if (_type == Tile.TileType.Hero)
            {
                tiles[_x, _y] = new Hero(_x, _y, 10,10,'H');
            }
            if (_type == Tile.TileType.Enemy)
            {
                tiles[_x, _y] = new Goblin(_x, _y,1, 10, 10, 'G');
            }
            return tiles[_x, _y];
        }
    }

    //Question 3.3
    public class GameEngine
    {
        private Map map;
        public GameEngine()
        {
            Map map = new Map(20, 30, 20, 30, 5);  //??? not sure what numbers to use here
        }
        bool MovePlayer(Character.MovementEnum direction)    //moves player to a new tile, setting old tile to an empty tile
        {
            if ()
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static readonly char Hero = 'H';
        private static readonly char Empty = ' ';
        private static readonly char Goblin = 'G';
        private static readonly char Obstacle = '#';
        public override string ToString()
        {
            string finalMap = " ";
            for (int _x = 0;_x < Map.mapWidth; _x++)
            {
                for (int _y = 0; _y < Map.mapHeight; _y++)
                {
                    //??? not sure how to do this
                }
                finalMap = finalMap + "\n";
            }
            return finalMap;
        }
    }
}
