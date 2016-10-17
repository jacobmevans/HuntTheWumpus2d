using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    public class KillScreen : Screen
    {
        private Texture2D wumpusKill;
        ScreenManager screenManager;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        Player player;

        public KillScreen(Game game, ScreenManager screenManager) : base(game)
        {
            content = Game.Content;
            this.screenManager = screenManager;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = content.Load<SpriteFont>("Fonts/Orbitron");
            player = new Player();
            player.Initialize(true);
            player.LoadContent(content);

            wumpusKill = content.Load<Texture2D>("Background/WumpusKill");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            if (KeyboardManager.Instance.KeyPressed(Keys.Enter))
            {
                screenManager.ChangeScreens(gameRef.startScreen);
            }
            else if (KeyboardManager.Instance.KeyPressed(Keys.Escape))
            {
                Game.Exit();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            Game1.spriteBatch.Begin();
            spriteBatch.Begin();
            spriteBatch.Draw(wumpusKill, new Vector2(250, 100), Color.White);
            player.Draw(Game1.spriteBatch);
            spriteBatch.DrawString(spriteFont, "The Wumpus got ya, better luck next time. \n\nPress Enter to Play again or Escape to exit...", new Vector2(115, 350), Color.DarkRed, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            base.Draw(gameTime);
            Game1.spriteBatch.End();
            spriteBatch.End();
        }
    }
}
