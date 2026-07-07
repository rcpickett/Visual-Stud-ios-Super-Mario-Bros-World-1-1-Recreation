using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public static class ControllerHelper
    {
        private static Boolean isGamePadBHeld = false;
        private static Boolean isKeyboardBHeld = false;
        private static Boolean isGamePadUpHeld = false;
        private static Boolean isKeyboardUpHeld = false;
        private static Boolean isGamePadPauseHeld = false;
        private static Boolean isKeyboardPauseHeld = false;

        public static Boolean IsGamePadBHeld { get { return isGamePadBHeld; } set { isGamePadBHeld = value; } }        
        public static Boolean IsKeyboardBHeld { get { return isKeyboardBHeld; } set { isKeyboardBHeld = value; } }
        
        public static Boolean IsGamePadDDown { get; set; }
        public static Boolean IsKeyboardDDown { get; set; }

        public static Boolean IsGamePadUpHeld { get { return isGamePadUpHeld; } set { isGamePadUpHeld = value; } }
        public static Boolean IsKeyboardUpHeld { get { return isKeyboardUpHeld; } set { isKeyboardUpHeld = value; } }

        public static Boolean IsGamePadPauseHeld { get { return isGamePadPauseHeld; } set { isGamePadPauseHeld = value; } }
        public static Boolean IsKeyboardPauseHeld { get { return isKeyboardPauseHeld; } set { isKeyboardPauseHeld = value; } }

        public static Boolean IsBHeld { get { return (IsGamePadBHeld || IsKeyboardBHeld); } }
        public static Boolean IsDDown { get { return (IsGamePadDDown || IsKeyboardDDown); } }
        public static Boolean IsUpHeld { get { return (IsGamePadUpHeld || IsKeyboardUpHeld); } }
        public static Boolean IsPauseHeld { get { return (IsGamePadPauseHeld || IsKeyboardPauseHeld); } }

        public static Boolean GravityControlOn { get; set; }

        private static Boolean noKeyboardMovement = false;
        private static Boolean noGamePadMovement = false;

        public static void NoKeyboardMovement(KeyboardState state)
        {
            noKeyboardMovement = (state.IsKeyUp(Keys.Down) && state.IsKeyUp(Keys.Right) && state.IsKeyUp(Keys.Left));
        }

        public static void NoGamePadMovement(GamePadState state)
        {
            noGamePadMovement = state.IsButtonUp(Buttons.LeftThumbstickDown) && state.IsButtonUp(Buttons.LeftThumbstickLeft) && state.IsButtonUp(Buttons.LeftThumbstickRight);
        }

        public static Boolean NoMovement()
        {
            return noKeyboardMovement && noGamePadMovement;
        }

    }
}
