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
        private int first_room;
        private int second_room;

        public static Pit Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Pit();
                }
                return instance;
            }
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
    }
}
