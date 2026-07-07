using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Team_Project
{
    public class KeyboardController : IController
    {
        private KeyboardState newState;
        private KeyboardState oldState;
        private ICommand command;

        public KeyboardController()
        {
            oldState = Keyboard.GetState();
        }

        public void Update()
        {
            newState = Keyboard.GetState();
            ControllerHelper.IsKeyboardBHeld = oldState.IsKeyDown(Keys.X) && newState.IsKeyDown(Keys.X);
            ControllerHelper.IsKeyboardUpHeld = oldState.IsKeyDown(Keys.Z) && newState.IsKeyDown(Keys.Z);
            ControllerHelper.IsKeyboardPauseHeld = oldState.IsKeyDown(Keys.A) && newState.IsKeyDown(Keys.A);
            ControllerHelper.IsKeyboardDDown = newState.IsKeyDown(Keys.Down);

            ControllerHelper.NoKeyboardMovement(newState);

            if (ControllerHelper.NoMovement())
            {
                command = KeyboardDictionary.GetCommandFromKeyMap(Keys.None);
                command.Execute();
            }               
            foreach (Keys key in newState.GetPressedKeys())
            {    
                    command = KeyboardDictionary.GetCommandFromKeyMap(key);
                    if (command != null)
                    {
                        command.Execute();
                    }
            }
            oldState = newState;
        }
    }
}
