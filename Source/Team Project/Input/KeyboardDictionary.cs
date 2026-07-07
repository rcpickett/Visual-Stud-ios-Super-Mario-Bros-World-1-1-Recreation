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
    public static class KeyboardDictionary
    {
        static Dictionary<Keys, ICommand> keyMap = new Dictionary<Keys, ICommand>();

        public static void AddToKeyMap(Keys key, ICommand command)
        {
            keyMap.Add(key, command);
        }

        public static ICommand GetCommandFromKeyMap(Keys key)
        {
            ICommand command;
            keyMap.TryGetValue(key, out command);
            return command;
        }
    }
}
