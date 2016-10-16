using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    public class MenuItemComponents
    {
        string[] itemNames;
        int currentlySelected = 0;
        float width, height;
        Vector2 position;
        SpriteFont spriteFont;

        public Color BaseColor
        {
            get;
            set;
        }

        public Color Highlighted
        {
            get;
            set;
        }

        public float Width
        {
            get { return width; }
        }

        public float Height
        {
            get { return height; }
        }

        public int SelectedIndex
        {
            get { return currentlySelected; }
        }

        public MenuItemComponents(SpriteFont spriteFont, string[] items)
        {
            this.spriteFont = spriteFont;
            SetMenuItems(items);
            BaseColor = Color.Black;
            Highlighted = Color.Yellow;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public void SetMenuItems(String[] items)
        {
            itemNames = (string[])items.Clone();
            MeasureMenu();
        }

        private void MeasureMenu()
        {
            width = 0;
            height = 0;

            foreach(string s in itemNames)
            {
                if(width < spriteFont.MeasureString(s).X)
                {
                    width = spriteFont.MeasureString(s).X;
                }
                height += spriteFont.LineSpacing;
            }
        }

        public void Update()
        {
            if(KeyboardManager.Instance.KeyPressed(Keys.Up, Keys.W))
            {
                currentlySelected--;
                if(currentlySelected < 0)
                {
                    currentlySelected = itemNames.Length - 1;
                }
            }
            if(KeyboardManager.Instance.KeyPressed(Keys.Down, Keys.S))
            {
                currentlySelected++;
                if (currentlySelected >= itemNames.Length)
                {
                    currentlySelected = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 menuPosition = position;
            spriteBatch.DrawString(spriteFont, "Hunt The Wumpus", new Vector2(150, 200), Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
            for(int i = 0; i < itemNames.Length; i++)
            {
                if(i == currentlySelected)
                {
                    spriteBatch.DrawString(spriteFont, itemNames[i], menuPosition, Highlighted);
                }
                else
                {
                    spriteBatch.DrawString(spriteFont, itemNames[i], menuPosition, BaseColor);
                }
                menuPosition.Y += spriteFont.LineSpacing;
            }
        }

    }
}
