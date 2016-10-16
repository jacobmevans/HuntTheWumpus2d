using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    public class ScreenEventArgs : EventArgs
    {
        Screen screen;

        public Screen Screen
        {
            get
            {
                return screen;
            }
            private set
            {
                screen = value;
            }
        }
        public ScreenEventArgs(Screen screen)
        {
            Screen = screen;
        }
    }
}
