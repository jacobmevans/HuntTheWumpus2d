using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    public class Tile
    {
        protected Texture2D texture;
        private Rectangle rectangle;
        private static ContentManager content;
        protected bool hasCollision = true;

        public bool Collision
        {
            get { return hasCollision; }
        }

        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    class CollisionTile : Tile
    {
        public CollisionTile(int number, Rectangle newRectangle)
        {
            if(number == 0 || number == 3 || number == 4 || number == 5)
            {
                this.hasCollision = false;
            }
            texture = Content.Load<Texture2D>("Textures/Tile" + number);
            this.Rectangle = newRectangle;
        }
    }
}
