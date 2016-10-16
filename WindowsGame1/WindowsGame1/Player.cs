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
        Texture2D playerImage;
        Vector2 playerPosition, currentFrame;
        float moveSpeed = 150f;
        KeyboardState keyState;

        Animation animation = new Animation();

        public void Initialize()
        {
            playerPosition = new Vector2(10, 10);
            animation.Initialize(playerPosition, new Vector2(13,21));
            currentFrame = Vector2.Zero;
        }

        public void LoadContent(ContentManager Content)
        {
            playerImage = Content.Load<Texture2D>("GameEntities/Player");
            animation.AnimationImage = playerImage;
        }

        public void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();
            animation.Active = true;

            playerPosition = animation.Position;

            if(keyState.IsKeyDown(Keys.Down))
            {
                playerPosition.Y += (moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                currentFrame.Y = 10;
            }
            else if(keyState.IsKeyDown(Keys.Up))
            {
                playerPosition.Y -= (moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                currentFrame.Y = 8;
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                playerPosition.X += (moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                currentFrame.Y = 11;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                playerPosition.X -= (moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                currentFrame.Y = 9;
            }
            else
            {
                animation.Active = false;
                //currentFrame.Y = 9;
            }

            currentFrame.X = animation.CurrentFrame.X;

            animation.Position = playerPosition;
            animation.CurrentFrame = currentFrame;

            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch);
        }
    }
}
