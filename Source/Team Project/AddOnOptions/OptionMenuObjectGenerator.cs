using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public static class OptionMenuObjectGenerator
    {
        private static IObjectsEffectPlayer flameShotLeft, flameWall, flameShotDown;
        private static Random rdmValue = new Random();

        private static float shotLeftDelay;
        private static float shotDownDelay;
        private static float flyingBlocksDelay;
        private static ArrayList tempWallList = new ArrayList();
        private static ArrayList tempBlockList = new ArrayList();


        public static String FlyingBlockOnOff { get; set; }
        public static String FireBallOnOff { get; set; }
        public static String WallOfFireOnOff { get; set; }
        public static String GravityControllerOnOff { get; set; }
        public static Boolean FireWallOn { get; set; }


        public static void Initialize()
        {
            FlyingBlockOnOff = OptionMenu.DefaultStatus;
            FireBallOnOff = OptionMenu.DefaultStatus;
            WallOfFireOnOff = OptionMenu.DefaultStatus;
            GravityControllerOnOff = OptionMenu.DefaultStatus;
            FireWallOn = false;

            shotLeftDelay = rdmValue.Next(Status.TimeDiffMin, Status.TimeDiffMax);
            shotDownDelay = rdmValue.Next(Status.TimeDiffMin, Status.TimeDiffMax);
            flyingBlocksDelay = rdmValue.Next(Status.TimeDiffMin, Status.TimeDiffMax);
        }

        public static void CreateFlameShotLeft(Vector2 location)
        {
            flameShotLeft = new FlameShotLeft(location);
        }

        public static void CreateFlameShotDown(Vector2 location)
        {
            flameShotDown = new FlameShotDown(location);
        }

        public static void CreateWallOfFire(Vector2 location)
        {
            flameWall = new FireWall(location);
        }

        public static void CreateFlyingBlock(Vector2 location)
        {
            tempBlockList.Add(new Block(location, new FlyingBlocks()));
        }

        public static void GetProjectile(ArrayList projectileList)
        {
            if (flameShotLeft != null)
            {
                projectileList.Add(flameShotLeft);
                flameShotLeft = null;
            }

            if (flameShotDown != null)
            {
                projectileList.Add(flameShotDown);
                flameShotDown = null;
            }
        }

        public static void GetFlameWall(ArrayList wallList)
        {
            if (flameWall != null)
            {
                int position = Value.Zero;
                while(tempWallList.Count > position)
                {
                    wallList.Add(tempWallList[position]);
                    position++;
                }
                tempWallList.Clear();
                flameWall = null;
            }
        }

        public static void GetFlyingBlock(ArrayList blockList)
        {
            if (tempBlockList.Count > 0)
            {
                foreach (Block block in tempBlockList)
                {
                    block.GetBlock();
                    blockList.Add(tempBlockList[Value.Zero]);
                }
                tempBlockList.Clear();
            }
        }

        public static void ObjectGenerator(GameTime gameTime, Game1 game)
        {
            Vector2 location = new Vector2(game.Camera.position.X, game.Camera.position.Y);

            if (FireBallOnOff == Status.On)
            {
                shotLeftDelay -= (float)gameTime.ElapsedGameTime.Milliseconds;
                shotDownDelay -= (float)gameTime.ElapsedGameTime.Milliseconds;
                if (shotLeftDelay <= 0)
                {
                    CreateFlameShotLeft(new Vector2(game.Camera.position.X + game.Camera.viewport.Width, rdmValue.Next((int)game.Camera.position.Y, (int)game.Camera.position.Y + game.Camera.viewport.Height)));
                    shotLeftDelay = rdmValue.Next(Status.TimeDiffMin, Status.TimeDiffMax);
                }
                if (shotDownDelay <= 0)
                {
                    CreateFlameShotDown(new Vector2(rdmValue.Next((int)game.Camera.position.X, (int)game.Camera.position.X + game.Camera.viewport.Width), Value.Zero));
                    shotDownDelay = rdmValue.Next(Status.TimeDiffMin, Status.TimeDiffMax);
                }
            }

            if (WallOfFireOnOff == Status.On && !FireWallOn)
            {
                int createWall = Value.Zero;
                while (createWall <= game.Camera.viewport.Height)
                {

                    CreateWallOfFire(new Vector2(game.Camera.position.X - Value.ThirtyFive, createWall));
                    createWall += Value.Seven;
                    tempWallList.Add(flameWall);
                }
                FireWallOn = true;
            }

            if (FlyingBlockOnOff == Status.On)
            {
                flyingBlocksDelay -= (float)gameTime.ElapsedGameTime.Milliseconds;
                if (flyingBlocksDelay <= 0)
                {
                    CreateFlyingBlock(new Vector2(game.Camera.position.X + game.Camera.viewport.Width, rdmValue.Next((int)game.Camera.position.Y, (int)game.Camera.position.Y + game.Camera.viewport.Height)));
                    flyingBlocksDelay = rdmValue.Next(Status.TimeDiffMin, Status.TimeDiffMax);
                }
            }
        }
    }
}
