using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    public class Background
    {
        Texture2D backgroundImage;

        public Background(Texture2D texture)
        {
            Visible = true;
            backgroundImage = texture;
        }

        public bool Visible
        {
            get;
            set;
        }

        public Texture2D BackgroundImage
        {
            get { return backgroundImage; }
            set { backgroundImage = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(Visible)
            {
                spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White);
            }
        }
    }
}
