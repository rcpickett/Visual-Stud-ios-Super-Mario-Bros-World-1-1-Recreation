using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public static class OptionMenu
    {
        public const int DotLocation = 46;

        public const int PlayerLoc = 46;

        public const int FlyingBlocksLoc = 77;

        public const int FireballsLoc = 108;

        public const int WallOfFireLoc = 139;

        public const int GravityControlLoc = 170;

        public const int BackLoc = 201;

        public const string DefaultStatus = "Off";

        public const string DefaultPlayer = "Mario";

        public const int StatusOffset = 200;

        public static String SwitchOnOff(string state)
        {
            string change;
            if (state == "On")
            {
                change = "Off";
            }
            else
            {
                change = "On";
            }
            return change;
        }

        public static String SwitchCharacter(string character)
        {
            string changeCharacter;
            if (character == "Bowser")
            {
                changeCharacter = "Mario";
            }
            else if(character == "Mario")
            {
                changeCharacter = "Luigi";
            }
            else
            {
                changeCharacter = "Bowser";
            }
            return changeCharacter;
        }

        public static Game1.Characters Character(string p)
        {
            Game1.Characters player;
            if (p == "Bowser")
            {
                player = Game1.Characters.Bowser;
            }
            else if (p == "Mario")
            {
                player = Game1.Characters.Mario;
            }
            else
            {
                player = Game1.Characters.Luigi;
            }

            return player;
        }

        public static void Gravity()
        {
            if (OptionMenuObjectGenerator.GravityControllerOnOff == Status.On && ControllerHelper.GravityControlOn)
            {
                MarioMovement.GravityRate = Speed.Change;
            }
            else
            {
                MarioMovement.GravityRate = Speed.Rate;
            }
        }
    }
}
