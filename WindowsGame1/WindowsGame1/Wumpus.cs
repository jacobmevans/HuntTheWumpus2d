using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HuntTheWumpus
{
    

    class Wumpus : Hazzard
    {
        private static Wumpus instance;
        private int room;
        private bool is_awake { get { return is_awake; } set { is_awake = value; } }

        public static Wumpus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Wumpus();
                }
                return instance;
            }
        }

        public void TryMove()
        {
            Random rand = new Random();
            int chanceToMove = rand.Next(1, 4);

            //1 in 4 chance for the wumpus to stay in place.
            if (chanceToMove != 1)
            {
                int i = 0;
                int room_num = -1;

                //Generate new wumpus position.
                while (i < 1)
                {
                    room_num = rand.Next(0, Constants.NUM_OF_ROOMS);

                    if (SuperBats.Instance.ContainsSuperbats(room) && !Pit.Instance.ContainsPits(room) && room != room_num)
                    {
                        room = room_num;
                        i++;
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
            base.Draw(spriteBatch);
        }
    }
}
