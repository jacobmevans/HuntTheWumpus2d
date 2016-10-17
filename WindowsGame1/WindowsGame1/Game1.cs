using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HuntTheWumpus
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public StartScreen startScreen;
        public MainLevel mainLevel;
        public PitFall pitFall;
        public KillScreen killScreen;
        ScreenManager screenManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //set fullscreen to false and change width/height to be a multiple of 64.
            this.graphics.PreferredBackBufferWidth = 832;
            this.graphics.PreferredBackBufferHeight = 640;
            this.graphics.IsFullScreen = false;
            
            screenManager = new ScreenManager(this);
            Components.Add(screenManager);

            startScreen = new StartScreen(this, screenManager);
            mainLevel = new MainLevel(this, screenManager);
            pitFall = new PitFall(this, screenManager);
            killScreen = new KillScreen(this, screenManager);
            screenManager.ChangeScreens(startScreen);

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "Hunt The Wumpus";
            Tile.Content = Content;
            base.Initialize();
        }

        public void resetMaps()
        {
            mainLevel = new MainLevel(this, screenManager);
            pitFall = new PitFall(this, screenManager);
            killScreen = new KillScreen(this, screenManager);
            Pit.Instance.respawnPits();
            SuperBats.Instance.respawnBats();
            Wumpus.Instance.respawnWumpus();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 30f);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Back))
                this.Exit();

            KeyboardManager.Instance.Update();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
