using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    class ScreenText
    {
        string currentRoom;
        string room1Text;
        string room2Text;
        string room3Text;
        string numberArrowsLeft;
        string shootPath;
        SpriteFont spriteFont;

        public ScreenText(SpriteFont spriteFont)
        {
            this.spriteFont = spriteFont;
        }

        public void setText(int text1, int text2, int text3, int text4, int numArrows)
        {
            currentRoom = "" + text1;
            room1Text = "Room " + text2;
            room2Text = "Room " + text3;
            room3Text = "Room " + text4;
            numberArrowsLeft = "" + numArrows;
        }

        public void setShootingText(string shoot)
        {
            shootPath = shoot;
        }

        public void DrawShoot(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, "Shooting at Rooms: " + shootPath, new Vector2(250, 550), Color.Black, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, "Current Room: " + currentRoom, new Vector2(75, 525), Color.Black, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(spriteFont, "Arrows Left: " + numberArrowsLeft, new Vector2(75, 550), Color.Black, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(spriteFont, room1Text, new Vector2(60, 335), Color.Black, 4.71239f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(spriteFont, room2Text, new Vector2(360, 60), Color.Black, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(spriteFont, room3Text, new Vector2(770, 235), Color.Black, 1.57f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            
        }
    }
}
