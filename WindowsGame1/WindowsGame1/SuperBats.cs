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
        private int first_room;
        private int second_room;

        public static SuperBats Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SuperBats();
                }
                return instance;
            }
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
