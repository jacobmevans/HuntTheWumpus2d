using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    public class MainLevel : Screen
    {
        ScreenManager mainLevelManager;
        SpriteFont spriteFont;
        SpriteBatch spriteBatch;
        Wumpus wumpus;
        SuperBats superbats;
        Pit pits;
        Map map;
        Background background;
        Player player;


        public MainLevel(Game1 game, ScreenManager screenManager) : base(game)
        {
            content = Game.Content;
            mainLevelManager = screenManager;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = content.Load<SpriteFont>("Fonts/Orbitron");
            wumpus = new Wumpus(content);
            wumpus.LoadStuff();
            superbats = new SuperBats();
            pits = new Pit();
            player = new Player();
            player.Initialize();
            player.LoadContent(content);
            background = new Background(content.Load<Texture2D>("Background/test"));
            map = new Map();
            map.Generate(new int[,] {
                {1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);
        }

        public override void Update(GameTime gameTime)
        {
            wumpus.Update(gameTime);
            player.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Begin();

            //background.Draw(Game1.spriteBatch);
            //wumpus.Draw(Game1.spriteBatch);
            //map.Draw(Game1.spriteBatch);
            player.Draw(Game1.spriteBatch);

            base.Draw(gameTime);
            Game1.spriteBatch.End();
        }
    }
}
