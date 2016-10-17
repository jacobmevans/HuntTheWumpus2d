using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HuntTheWumpus
{
    class SuperBats : Hazzard
    {
        private static SuperBats instance;
        private static int first_room = -1;
        private static int second_room = -1;
        private static Texture2D superbatIcon;

        public static SuperBats Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SuperBats();
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

        public bool ContainsSuperbats(int room)
        {
            if((first_room == room) || (second_room == room))
            {
                return true;
            }

            return false;
        }

        public override void UnloadStuff()
        {
            base.UnloadStuff();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void setTexture(Texture2D icon)
        {
            superbatIcon = icon;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public static void generateStartingPos()
        {
            while (first_room == -1)
            {
                first_room = RandomNum.Instance.Next(0, Constants.NUM_OF_ROOMS);
                if (first_room == Wumpus.Instance.Room || Pit.Instance.ContainsPits(first_room))
                {
                    first_room = -1;
                }

            }
            while (second_room == -1)
            {
                second_room = RandomNum.Instance.Next(0, Constants.NUM_OF_ROOMS);
                if (second_room == Wumpus.Instance.Room || Pit.Instance.ContainsPits(second_room) || second_room == first_room)
                {
                    second_room = -1;
                }
            }
        }

        public void respawnBats()
        {
            first_room = -1;
            second_room = -1;
            generateStartingPos();
        }
    }
}
