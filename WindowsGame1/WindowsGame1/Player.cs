using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    class Player
    {
        private Texture2D playerSprite;
        private Vector2 position, currentFrame;
        Rectangle rectangle;
        float speed = 150f;
        float moveSpeed = 0;
        int currentRoom;
        int numberOfArrows;
        int newRoom = 0;
        bool isFalling = false;
        KeyboardState keyState;

        Animation animation = new Animation();

        public bool Falling
        {
            get { return isFalling; }
            set { isFalling = value; }
        }

        public int ChangeRoom
        {
            get { return newRoom; }
            set { newRoom = value; }
        }

        public int CurrentRoom
        {
            get { return currentRoom; }
            set { currentRoom = value; }
        }

        public int NumberArrows
        {
            get { return numberOfArrows; }
        }

        public void Initialize(bool falling)
        {
            if (falling)
            {
                position = new Vector2((832 / 2) - 64, 0);
                isFalling = true;
            }
            else
            {
                position = new Vector2((832 / 2) - 64, (640 / 2) - 64);
                isFalling = false;
        }
            animation.Initialize(position, new Vector2(13,21));
            currentFrame = Vector2.Zero;
            generateStartingPos();
            numberOfArrows = 5;
        }

        public void LoadContent(ContentManager Content)
        {
            playerSprite = Content.Load<Texture2D>("GameEntities/Player");
            animation.AnimationImage = playerSprite;
        }

        public void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();
            animation.Active = true;
            if(!isFalling)
            {
                checkInput(gameTime);
                rectangle = new Rectangle((int)position.X, (int)position.Y, 56, 64);
            }
            else
            {
                if(position.Y < 832)
                {
                    Fall(gameTime);
                }
               
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch);
        }

        public void checkInput(GameTime gameTime)
        {
            moveSpeed = (speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (keyState.IsKeyDown(Keys.Down))
            {
                position.Y += moveSpeed;
                currentFrame.Y = 10;
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                position.Y -= moveSpeed;
                currentFrame.Y = 8;
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                position.X += moveSpeed;
                currentFrame.Y = 11;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                position.X -= moveSpeed;
                currentFrame.Y = 9;
            }
            else
            {
                animation.Active = false;
                //currentFrame.Y = 9;
            }

            currentFrame.X = animation.CurrentFrame.X;

            animation.Position = position;
            animation.CurrentFrame = currentFrame;

            animation.Update(gameTime);
        }

        public void Collision(Rectangle newRect, int x, int y)
        {
            if(rectangle.touchingTop(newRect))
            {
                position.Y = newRect.Y - rectangle.Height - 6; 
            }

            else if (rectangle.touchingBottom(newRect))
            {
                position.Y = newRect.Y + rectangle.Height + 11;
            }

            else if (rectangle.touchingLeft(newRect))
            {
                position.X = newRect.X - rectangle.Width - 4;
            }

           else if(rectangle.touchingRight(newRect))
            {
                position.X = newRect.X + newRect.Width + 4;
            }

            if(position.X < 0)
            {
                position.X = 0;
                triggerRoomChange();
                newRoom = 1;
            }

            if(position.X > 786)
            {
                position.X = 786;
                triggerRoomChange();
                newRoom = 3;
            }

            if (position.Y < 0)
            {
                position.Y = 0;
                triggerRoomChange();
                newRoom = 2;
            }

            if (position.Y > 578)
            {
                position.Y = 578;
            }
        }

        private void Fall(GameTime gameTime)
        {
            moveSpeed = (100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            position.Y += moveSpeed;
            currentFrame.Y = 2;
            currentFrame.X = animation.CurrentFrame.X;

            animation.Position = position;
            animation.CurrentFrame = currentFrame;

            animation.Update(gameTime);
        }

        private void triggerRoomChange()
        {
            position.X = (832 / 2) - 64;
            position.Y = (640 / 2) + 64;
        }

        private void generateStartingPos()
        {
            currentRoom = RandomNum.Instance.Next(0, Constants.NUM_OF_ROOMS);
        }
    }
}
