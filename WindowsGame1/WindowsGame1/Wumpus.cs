using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HuntTheWumpus
{
    

    public class Wumpus : Hazzard
    {
        private static Wumpus instance;
        private static int room = -1;
        private bool is_awake = false;
        Texture2D wumpusIcon;

        public int Room
        {
            get { return room; }
        }

        public bool IsAwake
        {
            get { return is_awake; } set { is_awake = value; } 
        }

        public static Wumpus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Wumpus();
                    generateStartingPos();
                }
                return instance;
            }
        }

        public Wumpus()
        {
        }

        public void setTexture(Texture2D icon)
        {
            wumpusIcon = icon;
        }

        public void TryMove(int playerRoom)
        {
            int chanceToMove = RandomNum.Instance.Next(1, 4);

            //1 in 4 chance for the wumpus to stay in place.
            if (chanceToMove != 1)
            {
                bool roomNotFound = true;
                int room_num = -1;

                //Generate new wumpus position.
                while (roomNotFound)
                {
                    System.Diagnostics.Debug.Write("\nIn while loop....\n");
                    room_num = RandomNum.Instance.Next(0, Constants.NUM_OF_ROOMS);
                    System.Diagnostics.Debug.Write("\nroom_num = " + room_num + "\n");

                    if (!SuperBats.Instance.ContainsSuperbats(room_num) && !Pit.Instance.ContainsPits(room_num) && (room != room_num) && (room != playerRoom))
                    {
                        room = room_num;
                        roomNotFound = false;
                    }
                }
            }
        }

        public override void LoadStuff()
        {
            base.LoadStuff();
        }

        public override void UnloadStuff()
        {
            base.UnloadStuff();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wumpusIcon, new Rectangle(355,450,124,124), Color.White);
            base.Draw(spriteBatch);
        }

        public static void generateStartingPos()
        {
            while (room == -1)
            {
                room = RandomNum.Instance.Next(0, Constants.NUM_OF_ROOMS);
                if (Pit.Instance.ContainsPits(room) || SuperBats.Instance.ContainsSuperbats(room))
                {
                    room = -1;
                }
            }
        }

        public void checkRoom(int roomNum)
        {
            if(room == roomNum)
            {
                is_awake = true; 
            }
        }

        public void respawnWumpus()
        {
            room = -1;
            generateStartingPos();
        }
    }
}
