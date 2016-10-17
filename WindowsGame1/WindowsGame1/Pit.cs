using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HuntTheWumpus
{
    class Pit : Hazzard
    {
        private static Pit instance;
        private static int first_room = -1;
        private static int second_room = -1;
        private static Texture2D pitIcon;

        public static Pit Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Pit();
                    generateStartingPos();
                }
                return instance;
            }
        }

        public int RoomOne()
        {
            return first_room;
        }

        public int RoomTwo()
        {
            return second_room;
        }

        public bool ContainsPits(int room)
        {
            if ((first_room == room) || (second_room == room))
            {
                return true;
            }

            return false;
        }

        public override void LoadStuff()
        {
            base.LoadStuff();
        }

        public void setTexture(Texture2D icon)
        {
            pitIcon = icon;
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
            base.Draw(spriteBatch);
        }

        private static void generateStartingPos()
        {
            while (first_room == -1)
            {
                first_room = RandomNum.Instance.Next(0, Constants.NUM_OF_ROOMS);
                if (first_room == Wumpus.Instance.Room || SuperBats.Instance.ContainsSuperbats(first_room))
                {
                    first_room = -1;
                }

            }
            while (second_room == -1)
            {
                second_room = RandomNum.Instance.Next(0, Constants.NUM_OF_ROOMS);
                if (second_room == Wumpus.Instance.Room || SuperBats.Instance.ContainsSuperbats(second_room) || second_room == first_room)
                {
                    second_room = -1;
                }
            }
        }

        public void respawnPits()
        {
            first_room = -1;
            second_room = -1;
            generateStartingPos();
        }
    }
}
