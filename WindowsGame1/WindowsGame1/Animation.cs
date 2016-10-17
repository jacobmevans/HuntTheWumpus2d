using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    class Animation
    {
        int frameCounter;
        int switchFrame;
        bool active;

        Texture2D playerSpriteSheet;
        Rectangle sourceRect;

        Vector2 position, amountofFrames, currentFrame;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }

        public Vector2 CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Texture2D AnimationImage
        {
            set { playerSpriteSheet = value; }
        }

        public int FrameWidth
        {
            get { return playerSpriteSheet.Width / (int)amountofFrames.X; }
        }

        public int FrameHeight
        {
            get { return playerSpriteSheet.Height / (int)amountofFrames.Y; }
        }

        public void Initialize(Vector2 pos, Vector2 frames)
        {
            active = false;
            switchFrame = 100;
            this.position = pos;
            this.amountofFrames = frames;
        }

        public void Update(GameTime gameTime)
        {
            if(active)
            {
                frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                frameCounter = 0;
            }
          
            if(frameCounter >= switchFrame)
            {
                frameCounter = 0;
                currentFrame.X += FrameWidth;
                //If the current frame has past the 9th frame (for movement - 13 total frames - 4 frames of emptiness)
                if(currentFrame.X >= playerSpriteSheet.Width - (4 * 64))
                {
                    currentFrame.X = 0;
                }
            }

            sourceRect = new Rectangle((int)currentFrame.X, (int)currentFrame.Y * FrameHeight, 56, 64);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerSpriteSheet, position, sourceRect, Color.White);
        }
    }
}
