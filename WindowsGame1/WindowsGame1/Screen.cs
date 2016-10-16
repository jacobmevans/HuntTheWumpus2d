using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HuntTheWumpus
{
    public abstract class Screen : DrawableGameComponent
    {
        List<GameComponent> childComponents;
        protected ContentManager content;
        protected Game1 gameRef;

        public Screen(Game game) : base(game)
        {
            childComponents = new List<GameComponent>();
            gameRef = (Game1)game;
        }

        public List<GameComponent> Components
        {
            get
            {
                return childComponents;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach(GameComponent component in childComponents)
            {
                if(component.Enabled)
                {
                    component.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawComponent;

            foreach(GameComponent component in childComponents)
            {
                if(component is DrawableGameComponent)
                {
                    drawComponent = component as DrawableGameComponent;
                    if(drawComponent.Visible)
                    {
                        drawComponent.Draw(gameTime);
                    }
                }
            }
            base.Draw(gameTime);
        }

        internal protected virtual void ScreenChange(object sender, ScreenEventArgs eventOccurred)
        {
            if(eventOccurred.Screen == this)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            Visible = true;
            Enabled = true;

            foreach(GameComponent component in childComponents)
            {
                component.Enabled = true;
                if(component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = true;
                }
            }
        }

        private void Hide()
        {
            Visible = false;
            Enabled = false;

            foreach (GameComponent component in childComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = false;
                }
            }
        }
    }
}
