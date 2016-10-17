using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HuntTheWumpus
{
    public class StartScreen : Screen
    {
        MenuItemComponents menuComponents;
        string[] itemNames = { "New Game", "Exit" };
        Background background;
        SpriteFont spriteFont;
        ScreenManager screenManager;
        SpriteBatch spriteBatch;

        public StartScreen(Game game, ScreenManager screenManager) : base(game)
        {
            content = Game.Content;
            this.screenManager = screenManager;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = content.Load<SpriteFont>("Fonts/Orbitron");

            menuComponents = new MenuItemComponents(spriteFont, itemNames);

            Vector2 menuPosition = new Vector2((Game.Window.ClientBounds.Width - menuComponents.Width) / 2, (Game.Window.ClientBounds.Height - menuComponents.Height) - 200);
            menuComponents.SetPosition(menuPosition);
            background = new Background(content.Load<Texture2D>("Background/test"));
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if(KeyboardManager.Instance.KeyPressed(Keys.Enter))
            {
                switch(menuComponents.SelectedIndex)
                {
                    case 0:
                        gameRef.resetMaps();
                        screenManager.ChangeScreens(gameRef.mainLevel);
                        break;
                    case 1:
                        Game.Exit();
                        break;
                }
            }

            menuComponents.Update();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Begin();

            //background.Draw(Game1.spriteBatch);
            menuComponents.Draw(Game1.spriteBatch);

            base.Draw(gameTime);
            Game1.spriteBatch.End();
        }
    }
}
