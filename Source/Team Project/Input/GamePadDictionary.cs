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
    public static class GamePadDictionary
    {
        static Dictionary<Buttons, ICommand> buttonMap = new Dictionary<Buttons, ICommand>();

        public static void AddToButtonMap(Buttons button, ICommand command)
        {
            buttonMap.Add(button, command);
        }
        
        public static ICommand GetCommandFromButtonMap(Buttons button)
        {
            ICommand command;
            buttonMap.TryGetValue(button, out command);
            return command;
        }
    }
}
