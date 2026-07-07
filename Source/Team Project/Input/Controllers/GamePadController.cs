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
    class GamePadController : IController
    {
        private GamePadState oldState;
        private GamePadState newState;

        public GamePadController()
        {
            oldState = GamePad.GetState(PlayerIndex.One);
        }

        public void Update()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            ICommand command = null;

            ControllerHelper.IsGamePadBHeld = oldState.IsButtonDown(Buttons.B) && newState.IsButtonDown(Buttons.B);
            ControllerHelper.IsGamePadUpHeld = oldState.IsButtonDown(Buttons.A) && newState.IsButtonDown(Buttons.A);
            ControllerHelper.IsGamePadDDown = newState.IsButtonDown(Buttons.LeftThumbstickDown);

            ControllerHelper.NoGamePadMovement(newState);

            if (ControllerHelper.NoMovement())
            {
                command = KeyboardDictionary.GetCommandFromKeyMap(Keys.None); //there's no such thing as "none" for GamePad
                command.Execute();
            }
            if (newState.IsButtonDown(Buttons.Start))
            {
                command = GamePadDictionary.GetCommandFromButtonMap(Buttons.Start);
                command.Execute();
            }
            if (newState.IsButtonDown(Buttons.A))
            {
                command = GamePadDictionary.GetCommandFromButtonMap(Buttons.A);
                command.Execute();
            }
            if (newState.IsButtonDown(Buttons.B))
            {
                command = GamePadDictionary.GetCommandFromButtonMap(Buttons.B);
                command.Execute();
            }
            if (newState.IsButtonDown(Buttons.LeftThumbstickDown))
            {
                command = GamePadDictionary.GetCommandFromButtonMap(Buttons.LeftThumbstickDown);
                command.Execute();
            }
            if (newState.IsButtonDown(Buttons.LeftThumbstickLeft))
            {
                command = GamePadDictionary.GetCommandFromButtonMap(Buttons.LeftThumbstickLeft);
                command.Execute();
            }
            if (newState.IsButtonDown(Buttons.LeftThumbstickRight))
            {
                command = GamePadDictionary.GetCommandFromButtonMap(Buttons.LeftThumbstickRight);
                command.Execute();
            }
            if (newState.IsButtonDown(Buttons.Back))
            {
                command = GamePadDictionary.GetCommandFromButtonMap(Buttons.Back);
                command.Execute();
            }
            if (newState.IsButtonDown(Buttons.X))
            {
                command = GamePadDictionary.GetCommandFromButtonMap(Buttons.X);
                command.Execute();
            }
            
            oldState = newState;
        }
    }
}