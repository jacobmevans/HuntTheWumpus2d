using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    public class ScreenManager : GameComponent
    {
        Stack<Screen> screens = new Stack<Screen>();

        public event EventHandler<ScreenEventArgs> OnScreenChange;

        const int startDrawOrder = 5000;
        const int drawOrderInc = 100;
        int drawOrder;

        public ScreenManager(Game game) : base(game)
        {
            drawOrder = startDrawOrder;
        }

        public Screen CurrentScreen
        {
            get { return screens.Peek(); }
        }

        public void PopScreen()
        {
            RemoveScreen();
            drawOrder = drawOrderInc;
            if(OnScreenChange != null)
            {
                OnScreenChange(this, new ScreenEventArgs(screens.Peek()));
            }
        }

        private void RemoveScreen()
        {
            Screen screen = (Screen)screens.Peek();
            OnScreenChange -= screen.ScreenChange;
            Game.Components.Remove(screen);

            screens.Pop();
        }

        public void PushScreen(Screen newScreen)
        {
            drawOrder += drawOrderInc;
            newScreen.DrawOrder = drawOrder;

            AddScreen(newScreen);

            if(OnScreenChange != null)
            {
                OnScreenChange += newScreen.ScreenChange; 
            }
        }

        private void AddScreen(Screen newScreen)
        {
            screens.Push(newScreen);
            Game.Components.Add(newScreen);
            OnScreenChange += newScreen.ScreenChange;
        }

        public void ChangeScreens(Screen newScreen)
        {
            System.Diagnostics.Debug.Write("\nscreens.Count = " + screens.Count + "\n");
            while (screens.Count > 0)
            {
                RemoveScreen();
            }
            System.Diagnostics.Debug.Write("\ntest2\n");
            newScreen.DrawOrder = startDrawOrder;
            drawOrder = startDrawOrder;
            System.Diagnostics.Debug.Write("\ntest3\n");
            AddScreen(newScreen);
            System.Diagnostics.Debug.Write("\ntest4\n");
            if (OnScreenChange != null)
            {
                OnScreenChange(this, new ScreenEventArgs(newScreen));
            }
            System.Diagnostics.Debug.Write("\nSucessfully changed screens\n");
        }

    }
}
