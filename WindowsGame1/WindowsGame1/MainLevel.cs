using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HuntTheWumpus
{
    public class MainLevel : Screen
    {
        ScreenManager mainLevelManager;
        SpriteFont spriteFont;
        SpriteBatch spriteBatch;
        Map map;
        ScreenText screenText, shootingText;
        Player player;
        bool isShooting = false;

        public MainLevel(Game1 game, ScreenManager screenManager) : base(game)
        {
            content = Game.Content;
            mainLevelManager = screenManager;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = content.Load<SpriteFont>("Fonts/Orbitron");
            screenText = new ScreenText(spriteFont);
            shootingText = new ScreenText(spriteFont);
            Wumpus.Instance.setTexture(content.Load<Texture2D>("GameEntities/Wumpus"));
            SuperBats.Instance.setTexture(content.Load<Texture2D>("GameEntities/SuperBats"));
            Pit.Instance.setTexture(content.Load<Texture2D>("GameEntities/Pit"));
            player = new Player();
            player.Initialize(false);
            player.LoadContent(content);
            map = new Map();
            map.Generate(new int[,] {
                {2,6,6,6,6,6,3,6,6,6,6,6,10},
                {9,0,0,0,0,0,0,0,0,0,0,0,7},
                {9,0,0,0,0,0,0,0,0,0,0,0,7},
                {9,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,4},
                {9,0,0,0,0,0,0,0,0,0,0,0,7},
                {9,0,0,0,0,0,0,0,0,0,0,0,7},
                {9,0,0,0,0,0,0,0,0,0,0,0,7},
                {9,0,0,0,0,0,0,0,0,0,0,0,7},
                {12,8,8,8,8,8,8,8,8,8,8,8,11},
            }, 64);

            screenText.setText(player.CurrentRoom, map.Tunnels[player.CurrentRoom].RoomOne, map.Tunnels[player.CurrentRoom].RoomTwo, map.Tunnels[player.CurrentRoom].RoomThree, player.NumberArrows);
        }

        private int GenerateNewPos()
        {
            int room = RandomNum.Instance.Next(0, Constants.NUM_OF_ROOMS);
            return room;
        }

        public override void Update(GameTime gameTime)
        {
            //Check for collision.
            foreach (CollisionTile tile in map.TileList)
            {
                if (tile.Collision)
                {
                    player.Collision(tile.Rectangle, map.Width, map.Height);
                }

            }
            player.Update(gameTime);

            //If the player went into a new room.
            if (player.ChangeRoom != 0)
            {
                switch (player.ChangeRoom)
                {
                    case 1:
                        player.CurrentRoom = map.Tunnels[player.CurrentRoom].RoomOne;
                        break;
                    case 2:
                        player.CurrentRoom = map.Tunnels[player.CurrentRoom].RoomTwo;
                        break;
                    case 3:
                        player.CurrentRoom = map.Tunnels[player.CurrentRoom].RoomThree;
                        break;
                }

                //If the wumpus is awake try and move it.
                if (Wumpus.Instance.IsAwake)
                {
                    Wumpus.Instance.TryMove(player.CurrentRoom);
                }

                //If the current room has wumpus wake it, or if it is kill player.
                if (Wumpus.Instance.Room == player.CurrentRoom)
                {
                    if (Wumpus.Instance.IsAwake)
                    {
                        mainLevelManager.ChangeScreens(gameRef.killScreen);
                    }
                    else
                    {
                        Wumpus.Instance.IsAwake = true;
                    }
                }

                //If room has a pit, you die.
                if (Pit.Instance.ContainsPits(player.CurrentRoom))
                {
                    mainLevelManager.ChangeScreens(gameRef.pitFall);
                }

                //If room has superbats you get put in a random new room that doesnt have a hazzard.
                if (SuperBats.Instance.ContainsSuperbats(player.CurrentRoom))
                {
                    int newRoom = -1;
                    while (newRoom == -1)
                    {
                        newRoom = RandomNum.Instance.Next(0, Constants.NUM_OF_ROOMS);
                        if (SuperBats.Instance.ContainsSuperbats(newRoom) || Pit.Instance.ContainsPits(newRoom) || (player.CurrentRoom == newRoom) || (Wumpus.Instance.Room == newRoom))
                        {
                            newRoom = -1;
                        }
                        else
                        {
                            player.CurrentRoom = newRoom;
                        }
                    }
                }

                if (SuperBats.Instance.ContainsSuperbats(player.CurrentRoom))
                {
                    double counter = gameTime.ElapsedGameTime.TotalSeconds;
                    while (gameTime.ElapsedGameTime.TotalSeconds - counter < 5)
                    {
                        SuperBats.Instance.Draw(Game1.spriteBatch);
                    }
                }

                //Update text to the screen.
                screenText.setText(player.CurrentRoom, map.Tunnels[player.CurrentRoom].RoomOne, map.Tunnels[player.CurrentRoom].RoomTwo, map.Tunnels[player.CurrentRoom].RoomThree, player.NumberArrows);
                //Reset variable to zero, room change is complete.
                player.ChangeRoom = 0;
            }

            base.Update(gameTime);

            if (KeyboardManager.Instance.KeyPressed(Keys.Z))
            {
                mainLevelManager.ChangeScreens(gameRef.killScreen);
            }

            if (KeyboardManager.Instance.KeyPressed(Keys.T))
            {
                isShooting = true;
            }

            if (KeyboardManager.Instance.KeyPressed(Keys.Escape))
            {
                isShooting = false;
            }

            if(isShooting)
            {
                //process shooting somehow
            }
         }



        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Game1.spriteBatch.Begin();
            spriteBatch.Begin();

            Wumpus.Instance.Draw(Game1.spriteBatch);

            

            map.Draw(Game1.spriteBatch);
            player.Draw(Game1.spriteBatch);
            screenText.Draw(Game1.spriteBatch);
            //If hazzard nearby print message to the screen.
            if (map.Tunnels[player.CurrentRoom].isConnectedRoom(Wumpus.Instance.Room))
            {
                spriteBatch.DrawString(spriteFont, "I smell a wumpus...", new Vector2(75, 100), Color.MediumVioletRed, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            }
            if (map.Tunnels[player.CurrentRoom].isConnectedRoom(SuperBats.Instance.RoomOne()) || map.Tunnels[player.CurrentRoom].isConnectedRoom(SuperBats.Instance.RoomTwo()))
            {
                spriteBatch.DrawString(spriteFont, "Bats nearby...", new Vector2(75, 125), Color.MediumVioletRed, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            }
            if (map.Tunnels[player.CurrentRoom].isConnectedRoom(Pit.Instance.RoomOne()) || map.Tunnels[player.CurrentRoom].isConnectedRoom(Pit.Instance.RoomTwo()))
            {
                spriteBatch.DrawString(spriteFont, "I feel a draft...", new Vector2(75, 150), Color.MediumVioletRed, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            }

            if(player.CurrentRoom == Wumpus.Instance.Room)
            {
                Wumpus.Instance.Draw(Game1.spriteBatch);
            }

            if(isShooting)
            {
                spriteBatch.DrawString(spriteFont, "In Shooting Mode\npress 1-5 to choose number of rooms to shoot at.", new Vector2(65, 400), Color.CadetBlue, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            }    

            //Cheats
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                spriteBatch.DrawString(spriteFont, "Superbats1: " + SuperBats.Instance.RoomOne(), new Vector2(550, 75), Color.MediumVioletRed, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
                spriteBatch.DrawString(spriteFont, "Superbats2: " + SuperBats.Instance.RoomTwo(), new Vector2(550, 100), Color.MediumVioletRed, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
                spriteBatch.DrawString(spriteFont, "Pits1: " + Pit.Instance.RoomOne(), new Vector2(550, 125), Color.MediumVioletRed, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
                spriteBatch.DrawString(spriteFont, "Pits2: " + Pit.Instance.RoomTwo(), new Vector2(550, 150), Color.MediumVioletRed, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
                spriteBatch.DrawString(spriteFont, "Wumpus: " + Wumpus.Instance.Room, new Vector2(550, 175), Color.MediumVioletRed, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
            }
            //Cheats
            base.Draw(gameTime);
            Game1.spriteBatch.End();
            spriteBatch.End();
        }
    }
}
