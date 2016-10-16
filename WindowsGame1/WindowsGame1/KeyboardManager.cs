using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace HuntTheWumpus
{
    public class KeyboardManager
    {
        KeyboardState currentKeyState, previousKeyState;

        private static KeyboardManager instance;

        public static KeyboardManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KeyboardManager();
                }
                return instance;
            }
        }

        public void Update()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
           
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyUp(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && previousKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && previousKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}