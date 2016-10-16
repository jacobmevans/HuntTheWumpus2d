using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HuntTheWumpus
{
    

    public class Wumpus : Hazzard
    {
        private static Wumpus instance;
        private int room;
        private bool is_awake { get { return is_awake; } set { is_awake = value; } }
        Texture2D wumpusIcon;
        ContentManager content;

        public static Wumpus Instance
        {
            get
            {
                if (instance == null)
                {
                    //instance = new Wumpus();
                }
                return instance;
            }
        }

        public Wumpus(ContentManager gameContent)
        {
            this.content = gameContent;
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
            wumpusIcon = content.Load<Texture2D>("GameEntities/Wumpus");
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
            spriteBatch.Draw(wumpusIcon, new Rectangle(0,0,256,256), Color.White);
            base.Draw(spriteBatch);
        }
    }
}
