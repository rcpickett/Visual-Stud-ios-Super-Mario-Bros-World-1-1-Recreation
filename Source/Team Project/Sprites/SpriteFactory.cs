using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public static class SpriteFactory
    {
        private static Game1 game;
        private static Dictionary<string, Texture2D> textureMap; 
        private static Dictionary<string, Texture2D> StaticSpriteMap;

        public static void LoadGame(Game1 Game)
        {
            game = Game;
        }

        // Load textures
        public static void LoadPlayerSprites()
        {
            textureMap = new Dictionary<string, Texture2D>();

            // Mario
            textureMap.Add(CreateSprite.SmallMarioIdleRight, game.Content.Load<Texture2D>(SpritePath.SmallMarioIdleRightPath));
            textureMap.Add(CreateSprite.SmallMarioIdleLeft, game.Content.Load<Texture2D>(SpritePath.SmallMarioIdleLeftPath));
            textureMap.Add(CreateSprite.BigMarioIdleRight, game.Content.Load<Texture2D>(SpritePath.BigMarioIdleRightPath));
            textureMap.Add(CreateSprite.BigMarioIdleLeft, game.Content.Load<Texture2D>(SpritePath.BigMarioIdleLeftPath));
            textureMap.Add(CreateSprite.FireMarioIdleRight, game.Content.Load<Texture2D>(SpritePath.FireMarioIdleRightPath));
            textureMap.Add(CreateSprite.FireMarioIdleLeft, game.Content.Load<Texture2D>(SpritePath.FireMarioIdleLeftPath));
            textureMap.Add(CreateSprite.SmallMarioRunningRight, game.Content.Load<Texture2D>(SpritePath.SmallMarioRunningRightPath));
            textureMap.Add(CreateSprite.SmallMarioRunningLeft, game.Content.Load<Texture2D>(SpritePath.SmallMarioRunningLeftPath));
            textureMap.Add(CreateSprite.BigMarioRunningRight, game.Content.Load<Texture2D>(SpritePath.BigMarioRunningRightPath));
            textureMap.Add(CreateSprite.BigMarioRunningLeft, game.Content.Load<Texture2D>(SpritePath.BigMarioRunningLeftPath));
            textureMap.Add(CreateSprite.FireMarioRunningRight, game.Content.Load<Texture2D>(SpritePath.FireMarioRunningRightPath));
            textureMap.Add(CreateSprite.FireMarioRunningLeft, game.Content.Load<Texture2D>(SpritePath.FireMarioRunningLeftPath));
            textureMap.Add(CreateSprite.SmallMarioJumpingRight, game.Content.Load<Texture2D>(SpritePath.SmallMarioJumpingRightPath));
            textureMap.Add(CreateSprite.SmallMarioJumpingLeft, game.Content.Load<Texture2D>(SpritePath.SmallMarioJumpingLeftPath));
            textureMap.Add(CreateSprite.BigMarioJumpingRight, game.Content.Load<Texture2D>(SpritePath.BigMarioJumpingRightPath));
            textureMap.Add(CreateSprite.BigMarioJumpingLeft, game.Content.Load<Texture2D>(SpritePath.BigMarioJumpingLeftPath));
            textureMap.Add(CreateSprite.FireMarioJumpingRight, game.Content.Load<Texture2D>(SpritePath.FireMarioJumpingRightPath));
            textureMap.Add(CreateSprite.FireMarioJumpingLeft, game.Content.Load<Texture2D>(SpritePath.FireMarioJumpingLeftPath));
            textureMap.Add(CreateSprite.BigMarioCrouchingRight, game.Content.Load<Texture2D>(SpritePath.BigMarioCrouchingRightPath));
            textureMap.Add(CreateSprite.BigMarioCrouchingLeft, game.Content.Load<Texture2D>(SpritePath.BigMarioCrouchingLeftPath));
            textureMap.Add(CreateSprite.FireMarioCrouchingRight, game.Content.Load<Texture2D>(SpritePath.FireMarioCrouchingRightPath));
            textureMap.Add(CreateSprite.FireMarioCrouchingLeft, game.Content.Load<Texture2D>(SpritePath.FireMarioCrouchingLeftPath));
            textureMap.Add(CreateSprite.MarioDeadRight, game.Content.Load<Texture2D>(SpritePath.MarioDeadRightPath));
            textureMap.Add(CreateSprite.MarioDeadLeft, game.Content.Load<Texture2D>(SpritePath.MarioDeadLeftPath));
            textureMap.Add(CreateSprite.SmallMarioTurningLeft, game.Content.Load<Texture2D>(SpritePath.SmallMarioTurningLeftPath));
            textureMap.Add(CreateSprite.SmallMarioTurningRight, game.Content.Load<Texture2D>(SpritePath.SmallMarioTurningRightPath));
            textureMap.Add(CreateSprite.BigMarioTurningLeft, game.Content.Load<Texture2D>(SpritePath.BigMarioTurningLeftPath));
            textureMap.Add(CreateSprite.BigMarioTurningRight, game.Content.Load<Texture2D>(SpritePath.BigMarioTurningRightPath));
            textureMap.Add(CreateSprite.FireMarioTurningLeft, game.Content.Load<Texture2D>(SpritePath.FireMarioTurningLeftPath));
            textureMap.Add(CreateSprite.FireMarioTurningRight, game.Content.Load<Texture2D>(SpritePath.FireMarioTurningRightPath));
            textureMap.Add(CreateSprite.BigSmallMarioRight, game.Content.Load<Texture2D>(SpritePath.BigSmallMarioRightPath));
            textureMap.Add(CreateSprite.BigSmallMarioLeft, game.Content.Load<Texture2D>(SpritePath.BigSmallMarioLeftPath));
            textureMap.Add(CreateSprite.BigMarioSwimIdleRight, game.Content.Load<Texture2D>(SpritePath.BigMarioSwimIdleRightPath));
            textureMap.Add(CreateSprite.BigMarioSwimIdleLeft, game.Content.Load<Texture2D>(SpritePath.BigMarioSwimIdleLeftPath));
            textureMap.Add(CreateSprite.SmallMarioSwimIdleRight, game.Content.Load<Texture2D>(SpritePath.SmallMarioSwimIdleRightPath));
            textureMap.Add(CreateSprite.SmallMarioSwimIdleLeft, game.Content.Load<Texture2D>(SpritePath.SmallMarioSwimIdleLeftPath));
            textureMap.Add(CreateSprite.FireMarioFireballRight, game.Content.Load<Texture2D>(SpritePath.FireMarioFireballRightPath));
            textureMap.Add(CreateSprite.FireMarioFireballLeft, game.Content.Load<Texture2D>(SpritePath.FireMarioFireballLeftPath));
            textureMap.Add(CreateSprite.SmallMarioWinningLegDownRight, game.Content.Load<Texture2D>(SpritePath.SmallMarioWinningLegDownRightPath));
            textureMap.Add(CreateSprite.SmallMarioWinningLegUpRight, game.Content.Load<Texture2D>(SpritePath.SmallMarioWinningLegUpRightPath));
            textureMap.Add(CreateSprite.SmallMarioWinningLegDownLeft, game.Content.Load<Texture2D>(SpritePath.SmallMarioWinningLegDownLeftPath));
            textureMap.Add(CreateSprite.SmallMarioWinningLegUpLeft, game.Content.Load<Texture2D>(SpritePath.SmallMarioWinningLegUpLeftPath));
            textureMap.Add(CreateSprite.BigMarioWinningArmDownRight, game.Content.Load<Texture2D>(SpritePath.BigMarioWinningArmDownRightPath));
            textureMap.Add(CreateSprite.BigMarioWinningArmUpRight, game.Content.Load<Texture2D>(SpritePath.BigMarioWinningArmUpRightPath));
            textureMap.Add(CreateSprite.BigMarioWinningArmDownLeft, game.Content.Load<Texture2D>(SpritePath.BigMarioWinningArmDownLeftPath));
            textureMap.Add(CreateSprite.BigMarioWinningArmUpLeft, game.Content.Load<Texture2D>(SpritePath.BigMarioWinningArmUpLeftPath));
            textureMap.Add(CreateSprite.FireMarioWinningArmDownRight, game.Content.Load<Texture2D>(SpritePath.FireMarioWinningArmDownRightPath));
            textureMap.Add(CreateSprite.FireMarioWinningArmUpRight, game.Content.Load<Texture2D>(SpritePath.FireMarioWinningArmUpRightPath));
            textureMap.Add(CreateSprite.FireMarioWinningArmDownLeft, game.Content.Load<Texture2D>(SpritePath.FireMarioWinningArmDownLeftPath));
            textureMap.Add(CreateSprite.FireMarioWinningArmUpLeft, game.Content.Load<Texture2D>(SpritePath.FireMarioWinningArmUpLeftPath));

            // Luigi
            textureMap.Add(CreateSprite.SmallLuigiIdleRight, game.Content.Load<Texture2D>(SpritePath.SmallLuigiIdleRightPath));
            textureMap.Add(CreateSprite.SmallLuigiIdleLeft, game.Content.Load<Texture2D>(SpritePath.SmallLuigiIdleLeftPath));
            textureMap.Add(CreateSprite.BigLuigiIdleRight, game.Content.Load<Texture2D>(SpritePath.BigLuigiIdleRightPath));
            textureMap.Add(CreateSprite.BigLuigiIdleLeft, game.Content.Load<Texture2D>(SpritePath.BigLuigiIdleLeftPath));
            textureMap.Add(CreateSprite.FireLuigiIdleRight, game.Content.Load<Texture2D>(SpritePath.FireLuigiIdleRightPath));
            textureMap.Add(CreateSprite.FireLuigiIdleLeft, game.Content.Load<Texture2D>(SpritePath.FireLuigiIdleLeftPath));
            textureMap.Add(CreateSprite.SmallLuigiRunningRight, game.Content.Load<Texture2D>(SpritePath.SmallLuigiRunningRightPath));
            textureMap.Add(CreateSprite.SmallLuigiRunningLeft, game.Content.Load<Texture2D>(SpritePath.SmallLuigiRunningLeftPath));
            textureMap.Add(CreateSprite.BigLuigiRunningRight, game.Content.Load<Texture2D>(SpritePath.BigLuigiRunningRightPath));
            textureMap.Add(CreateSprite.BigLuigiRunningLeft, game.Content.Load<Texture2D>(SpritePath.BigLuigiRunningLeftPath));
            textureMap.Add(CreateSprite.FireLuigiRunningRight, game.Content.Load<Texture2D>(SpritePath.FireLuigiRunningRightPath));
            textureMap.Add(CreateSprite.FireLuigiRunningLeft, game.Content.Load<Texture2D>(SpritePath.FireLuigiRunningLeftPath));
            textureMap.Add(CreateSprite.SmallLuigiJumpingRight, game.Content.Load<Texture2D>(SpritePath.SmallLuigiJumpingRightPath));
            textureMap.Add(CreateSprite.SmallLuigiJumpingLeft, game.Content.Load<Texture2D>(SpritePath.SmallLuigiJumpingLeftPath));
            textureMap.Add(CreateSprite.BigLuigiJumpingRight, game.Content.Load<Texture2D>(SpritePath.BigLuigiJumpingRightPath));
            textureMap.Add(CreateSprite.BigLuigiJumpingLeft, game.Content.Load<Texture2D>(SpritePath.BigLuigiJumpingLeftPath));
            textureMap.Add(CreateSprite.FireLuigiJumpingRight, game.Content.Load<Texture2D>(SpritePath.FireLuigiJumpingRightPath));
            textureMap.Add(CreateSprite.FireLuigiJumpingLeft, game.Content.Load<Texture2D>(SpritePath.FireLuigiJumpingLeftPath));
            textureMap.Add(CreateSprite.BigLuigiCrouchingRight, game.Content.Load<Texture2D>(SpritePath.BigLuigiCrouchingRightPath));
            textureMap.Add(CreateSprite.BigLuigiCrouchingLeft, game.Content.Load<Texture2D>(SpritePath.BigLuigiCrouchingLeftPath));
            textureMap.Add(CreateSprite.FireLuigiCrouchingRight, game.Content.Load<Texture2D>(SpritePath.FireLuigiCrouchingRightPath));
            textureMap.Add(CreateSprite.FireLuigiCrouchingLeft, game.Content.Load<Texture2D>(SpritePath.FireLuigiCrouchingLeftPath));
            textureMap.Add(CreateSprite.LuigiDeadRight, game.Content.Load<Texture2D>(SpritePath.LuigiDeadRightPath));
            textureMap.Add(CreateSprite.LuigiDeadLeft, game.Content.Load<Texture2D>(SpritePath.LuigiDeadLeftPath));
            textureMap.Add(CreateSprite.SmallLuigiTurningLeft, game.Content.Load<Texture2D>(SpritePath.SmallLuigiTurningLeftPath));
            textureMap.Add(CreateSprite.SmallLuigiTurningRight, game.Content.Load<Texture2D>(SpritePath.SmallLuigiTurningRightPath));
            textureMap.Add(CreateSprite.BigLuigiTurningLeft, game.Content.Load<Texture2D>(SpritePath.BigLuigiTurningLeftPath));
            textureMap.Add(CreateSprite.BigLuigiTurningRight, game.Content.Load<Texture2D>(SpritePath.BigLuigiTurningRightPath));
            textureMap.Add(CreateSprite.FireLuigiTurningLeft, game.Content.Load<Texture2D>(SpritePath.FireLuigiTurningLeftPath));
            textureMap.Add(CreateSprite.FireLuigiTurningRight, game.Content.Load<Texture2D>(SpritePath.FireLuigiTurningRightPath));
            textureMap.Add(CreateSprite.BigSmallLuigiRight, game.Content.Load<Texture2D>(SpritePath.BigSmallLuigiRightPath));
            textureMap.Add(CreateSprite.BigSmallLuigiLeft, game.Content.Load<Texture2D>(SpritePath.BigSmallLuigiLeftPath));
            textureMap.Add(CreateSprite.BigLuigiSwimIdleRight, game.Content.Load<Texture2D>(SpritePath.BigLuigiSwimIdleRightPath));
            textureMap.Add(CreateSprite.BigLuigiSwimIdleLeft, game.Content.Load<Texture2D>(SpritePath.BigLuigiSwimIdleLeftPath));
            textureMap.Add(CreateSprite.SmallLuigiSwimIdleRight, game.Content.Load<Texture2D>(SpritePath.SmallLuigiSwimIdleRightPath));
            textureMap.Add(CreateSprite.SmallLuigiSwimIdleLeft, game.Content.Load<Texture2D>(SpritePath.SmallLuigiSwimIdleLeftPath));
            textureMap.Add(CreateSprite.FireLuigiFireballRight, game.Content.Load<Texture2D>(SpritePath.FireLuigiFireballRightPath));
            textureMap.Add(CreateSprite.FireLuigiFireballLeft, game.Content.Load<Texture2D>(SpritePath.FireLuigiFireballLeftPath));
            textureMap.Add(CreateSprite.SmallLuigiWinningLegDownRight, game.Content.Load<Texture2D>(SpritePath.SmallLuigiWinningLegDownRightPath));
            textureMap.Add(CreateSprite.SmallLuigiWinningLegUpRight, game.Content.Load<Texture2D>(SpritePath.SmallLuigiWinningLegUpRightPath));
            textureMap.Add(CreateSprite.SmallLuigiWinningLegDownLeft, game.Content.Load<Texture2D>(SpritePath.SmallLuigiWinningLegDownLeftPath));
            textureMap.Add(CreateSprite.SmallLuigiWinningLegUpLeft, game.Content.Load<Texture2D>(SpritePath.SmallLuigiWinningLegUpLeftPath));
            textureMap.Add(CreateSprite.BigLuigiWinningArmDownRight, game.Content.Load<Texture2D>(SpritePath.BigLuigiWinningArmDownRightPath));
            textureMap.Add(CreateSprite.BigLuigiWinningArmUpRight, game.Content.Load<Texture2D>(SpritePath.BigLuigiWinningArmUpRightPath));
            textureMap.Add(CreateSprite.BigLuigiWinningArmDownLeft, game.Content.Load<Texture2D>(SpritePath.BigLuigiWinningArmDownLeftPath));
            textureMap.Add(CreateSprite.BigLuigiWinningArmUpLeft, game.Content.Load<Texture2D>(SpritePath.BigLuigiWinningArmUpLeftPath));
            textureMap.Add(CreateSprite.FireLuigiWinningArmDownRight, game.Content.Load<Texture2D>(SpritePath.FireLuigiWinningArmDownRightPath));
            textureMap.Add(CreateSprite.FireLuigiWinningArmUpRight, game.Content.Load<Texture2D>(SpritePath.FireLuigiWinningArmUpRightPath));
            textureMap.Add(CreateSprite.FireLuigiWinningArmDownLeft, game.Content.Load<Texture2D>(SpritePath.FireLuigiWinningArmDownLeftPath));
            textureMap.Add(CreateSprite.FireLuigiWinningArmUpLeft, game.Content.Load<Texture2D>(SpritePath.FireLuigiWinningArmUpLeftPath));

            // Bowser
            textureMap.Add(CreateSprite.BowserRunningRight, game.Content.Load<Texture2D>(SpritePath.BowserRunningRight));
            textureMap.Add(CreateSprite.BowserRunningLeft, game.Content.Load<Texture2D>(SpritePath.BowserRunningLeft));
            textureMap.Add(CreateSprite.BigBowserRunningRight, game.Content.Load<Texture2D>(SpritePath.BigBowserRunningRight));
            textureMap.Add(CreateSprite.BigBowserRunningLeft, game.Content.Load<Texture2D>(SpritePath.BigBowserRunningLeft));
            textureMap.Add(CreateSprite.GigaBowserRunningRight, game.Content.Load<Texture2D>(SpritePath.GigaBowserRunningRight));
            textureMap.Add(CreateSprite.GigaBowserRunningLeft, game.Content.Load<Texture2D>(SpritePath.GigaBowserRunningLeft));

        }
        public static void LoadStaticSprites()
        {
            StaticSpriteMap = new Dictionary<string, Texture2D>();
            StaticSpriteMap.Add(CreateSprite.CreateCastleFlag, game.Content.Load<Texture2D>(SpritePath.CastleFlagPath));
            StaticSpriteMap.Add(CreateSprite.CreateFlag, game.Content.Load<Texture2D>(SpritePath.FlagPath));
            StaticSpriteMap.Add(CreateSprite.CreatePole, game.Content.Load<Texture2D>(SpritePath.PolePath));
            StaticSpriteMap.Add(CreateSprite.CreateSmallCastle, game.Content.Load<Texture2D>(SpritePath.SmallCastlePath));
        }

        // Player Creators
        public static IAnimatedSprite CreateSmallMarioIdleRightSprite()
        {
            Texture2D texture = null;
            if (game.playerChar == Game1.Characters.Mario) textureMap.TryGetValue(CreateSprite.SmallMarioIdleRight, out texture);
            if (game.playerChar == Game1.Characters.Luigi) textureMap.TryGetValue(CreateSprite.SmallLuigiIdleRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioIdleLeftSprite()
        {
            Texture2D texture = null;
            if (game.playerChar == Game1.Characters.Mario) textureMap.TryGetValue(CreateSprite.SmallMarioIdleLeft, out texture);
            if (game.playerChar == Game1.Characters.Luigi) textureMap.TryGetValue(CreateSprite.SmallLuigiIdleLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioIdleRightSprite()
        {
            Texture2D texture = null;
            if (game.playerChar == Game1.Characters.Mario) textureMap.TryGetValue(CreateSprite.BigMarioIdleRight, out texture);
            if (game.playerChar == Game1.Characters.Luigi) textureMap.TryGetValue(CreateSprite.BigLuigiIdleRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioIdleLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioIdleLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiIdleLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioIdleRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioIdleRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiIdleRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioIdleLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioIdleLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiIdleLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioRunningRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioRunningRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiRunningRight, out texture);
            IAnimatedSprite sprite = new MarioRunningSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioRunningLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioRunningLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiRunningLeft, out texture);
            IAnimatedSprite sprite = new MarioRunningSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioRunningRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioRunningRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiRunningRight, out texture);
            IAnimatedSprite sprite = new MarioRunningSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioRunningLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioRunningLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiRunningLeft, out texture);
            IAnimatedSprite sprite = new MarioRunningSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioRunningRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioRunningRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiRunningRight, out texture);
            IAnimatedSprite sprite = new MarioRunningSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioRunningLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioRunningLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiRunningLeft, out texture);
            IAnimatedSprite sprite = new MarioRunningSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioJumpingRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioJumpingRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiJumpingRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioJumpingLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioJumpingLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiJumpingLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioJumpingRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioJumpingRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiJumpingRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioJumpingLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioJumpingLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiJumpingLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioJumpingRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioJumpingRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiJumpingRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioJumpingLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioJumpingLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiJumpingLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioCrouchingRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioCrouchingRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiCrouchingRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioCrouchingLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioCrouchingLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiCrouchingLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioCrouchingRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioCrouchingRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiCrouchingRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioCrouchingLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioCrouchingLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiCrouchingLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateMarioDeadLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.MarioDeadLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.LuigiDeadLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateMarioDeadRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.MarioDeadRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.LuigiDeadRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioTurningLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioTurningLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiTurningLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioTurningRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioTurningRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiTurningRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioTurningLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioTurningLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiTurningLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioTurningRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioTurningRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiTurningRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioTurningLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioTurningLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiTurningLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioTurningRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioTurningRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiTurningRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigSmallMarioRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigSmallMarioRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigSmallLuigiRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigSmallMarioLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigSmallMarioLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigSmallLuigiLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioSwimIdleLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioSwimIdleLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiSwimIdleLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioSwimIdleRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioSwimIdleRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiSwimIdleRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioSwimIdleLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioSwimIdleLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiSwimIdleLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioFireballRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioFireballRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiFireballRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioFireballLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioFireballLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiFireballLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioSwimIdleRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioSwimIdleRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiSwimIdleRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioWinningLegDownRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioWinningLegDownRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiWinningLegDownRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioWinningLegDownLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioWinningLegDownLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiWinningLegDownLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioWinningLegUpRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioWinningLegUpRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiWinningLegUpRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallMarioWinningLegUpLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.SmallMarioWinningLegUpLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.SmallLuigiWinningLegUpLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioWinningArmUpLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioWinningArmUpLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiWinningArmUpLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioWinningArmDownLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioWinningArmDownLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiWinningArmDownLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioWinningArmUpRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioWinningArmUpRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiWinningArmUpRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateBigMarioWinningArmDownRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.BigMarioWinningArmDownRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.BigLuigiWinningArmDownRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioWinningArmUpLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioWinningArmUpLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiWinningArmUpLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioWinningArmDownLeftSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioWinningArmDownLeft, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiWinningArmDownLeft, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioWinningArmUpRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioWinningArmUpRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiWinningArmUpRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateFireMarioWinningArmDownRightSprite()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0) textureMap.TryGetValue(CreateSprite.FireMarioWinningArmDownRight, out texture);
            if ((int)game.playerChar == 1) textureMap.TryGetValue(CreateSprite.FireLuigiWinningArmDownRight, out texture);
            IAnimatedSprite sprite = new MarioSingleFrameSprite(texture);
            return sprite;
        }
        public static IAnimatedSprite CreateIceMarioWinningArmUpLeftSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioWinningArmUpLeftPath));
        }
        public static IAnimatedSprite CreateIceMarioWinningArmDownLeftSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioWinningArmDownLeftPath));
        }
        public static IAnimatedSprite CreateIceMarioWinningArmUpRightSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioWinningArmUpRightPath));
        }
        public static IAnimatedSprite CreateIceMarioWinningArmDownRightSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioWinningArmDownRightPath));
        }
        public static IAnimatedSprite CreateIceMarioIdleRightSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioIdleRightPath));
        }
        public static IAnimatedSprite CreateIceMarioIdleLeftSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioIdleLeftPath));
        }
        public static IAnimatedSprite CreateIceMarioRunningRightSprite()
        {
            return new MarioRunningSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioRunningRightPath));
        }
        public static IAnimatedSprite CreateIceMarioRunningLeftSprite()
        {
            return new MarioRunningSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioRunningLeftPath));
        }
        public static IAnimatedSprite CreateIceMarioTurningLeftSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioTurningLeftPath));
        }
        public static IAnimatedSprite CreateIceMarioTurningRightSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioTurningRightPath));
        }
        public static IAnimatedSprite CreateIceMarioCrouchingRightSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioCrouchRightPath));
        }
        public static IAnimatedSprite CreateIceMarioCrouchingLeftSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioCrouchLeftPath));
        }
        public static IAnimatedSprite CreateIceMarioJumpingRightSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioJumpingRightPath));
        }
        public static IAnimatedSprite CreateIceMarioJumpingLeftSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioJumpingLeftPath));
        }
        public static IAnimatedSprite CreateIceMarioIceballRightSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioIceballRightPath));
        }
        public static IAnimatedSprite CreateIceMarioIceballLeftSprite()
        {
            return new MarioSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.IceMarioIceballLeftPath));
        }

        //Bowser Creators
        public static IAnimatedSprite CreateSmallBowserIdleRightSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.BowserIdleRight));
        }
        public static IAnimatedSprite CreateBowserRunningRightSprite()
        {
            Texture2D texture;
            textureMap.TryGetValue(CreateSprite.BowserRunningRight, out texture);
            IAnimatedSprite sprite = new BowserRunningSprite(texture,Value.Two);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallBowserIdleLeftSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.BowserIdleLeft));
        }
        public static IAnimatedSprite CreateBowserRunningLeftSprite()
        {
            Texture2D texture;
            textureMap.TryGetValue(CreateSprite.BowserRunningLeft, out texture);
            IAnimatedSprite sprite = new BowserRunningSprite(texture,Value.Two);
            return sprite;
        }
       
        public static IAnimatedSprite CreateBigBowserIdleRightSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.BigBowserIdleRight));
        }
        public static IAnimatedSprite CreateBigBowserRunningRightSprite()
        {
            Texture2D texture;
            textureMap.TryGetValue(CreateSprite.BigBowserRunningRight, out texture);
            IAnimatedSprite sprite = new BowserRunningSprite(texture,Value.Five);
            return sprite;
        }
        public static IAnimatedSprite CreateBigBowserIdleLeftSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.BigBowserIdleLeft));
        }
        public static IAnimatedSprite CreateBigBowserRunningLeftSprite()
        {
            Texture2D texture;
            textureMap.TryGetValue(CreateSprite.BigBowserRunningLeft, out texture);
            IAnimatedSprite sprite = new BowserRunningSprite(texture,Value.Five);
            return sprite;
        }

        public static IAnimatedSprite CreateGigaBowserIdleRightSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.GigaBowserIdleRight));
        }
        public static IAnimatedSprite CreateGigaBowserRunningRightSprite()
        {
            Texture2D texture;
            textureMap.TryGetValue(CreateSprite.GigaBowserRunningRight, out texture);
            IAnimatedSprite sprite = new BowserRunningSprite(texture, Value.Two);
            return sprite;
        }
        public static IAnimatedSprite CreateGigaBowserIdleLeftSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.GigaBowserIdleLeft));
        }
        public static IAnimatedSprite CreateGigaBowserRunningLeftSprite()
        {
            Texture2D texture;
            textureMap.TryGetValue(CreateSprite.GigaBowserRunningLeft, out texture);
            IAnimatedSprite sprite = new BowserRunningSprite(texture, Value.Two);
            return sprite;
        }
        public static IAnimatedSprite CreateSmallBowserBreathLeftSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.SmallBowserBreathLeft));
        }
        public static IAnimatedSprite CreateSmallBowserBreathRightSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.SmallBowserBreathRight));
        }
        public static IAnimatedSprite CreateBigBowserBreathLeftSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.BigBowserBreathLeft));
        }
        public static IAnimatedSprite CreateBigBowserBreathRightSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.BigBowserBreathRight));
        }
        public static IAnimatedSprite CreateGigaBowserBreathLeftSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.GigaBowserBreathLeft));
        }
        public static IAnimatedSprite CreateGigaBowserBreathRightSprite()
        {
            return new BowserSingleFrameSprite(game.Content.Load<Texture2D>(SpritePath.GigaBowserBreathRight));
        }
        public static IAnimatedSprite CreateBowserDeadLeftSprite()
        {
            Texture2D texture = null;
            textureMap.TryGetValue(CreateSprite.MarioDeadLeft, out texture);
            IAnimatedSprite sprite = new BowserSingleFrameSprite(texture);
            return sprite;
        }

        // Enemy Creators
        public static IAnimatedSprite CreateGoombaWalkingSprite()
        {
            Texture2D goombaWalking = game.Content.Load<Texture2D>(SpritePath.GoombaWalkPath);
            IAnimatedSprite walkingGoomba = new GoombaMovingSprite(goombaWalking);
            return walkingGoomba;
        }
        public static IAnimatedSprite CreateGoombaSquishedSprite()
        {
            Texture2D goombaSquished = game.Content.Load<Texture2D>(SpritePath.GoombaSquishPath);
            IAnimatedSprite squishedGoomba = new GoombaSingleFrameSprite(goombaSquished);
            return squishedGoomba;
        }
        public static IAnimatedSprite CreateGoombaKilledSprite()
        {
            Texture2D goombaKilled = game.Content.Load<Texture2D>(SpritePath.GoombaKilledPath);
            IAnimatedSprite killedGoomba = new GoombaSingleFrameSprite(goombaKilled);
            return killedGoomba;
        }
        public static IAnimatedSprite CreateKoopaMovingLeftSprite()
        {
            Texture2D koopaLeft = game.Content.Load<Texture2D>(SpritePath.KoopaWalkLeftPath);
            IAnimatedSprite leftWalkingKoopaSprite = new KoopaMovingSprite(koopaLeft);
            return leftWalkingKoopaSprite;
        }
        public static IAnimatedSprite CreateKoopaShellSprite()
        {
            Texture2D koopaShell = game.Content.Load<Texture2D>(SpritePath.KoopaShellPath);
            IAnimatedSprite koopaShellSprite = new KoopaSingleFrameSprite(koopaShell);
            return koopaShellSprite;
        }
        public static IAnimatedSprite CreateKoopaKilledSprite()
        {
            Texture2D koopaKilled = game.Content.Load<Texture2D>(SpritePath.KoopaKilledPath);
            IAnimatedSprite koopaKilledSprite = new KoopaSingleFrameSprite(koopaKilled);
            return koopaKilledSprite;
        }
        public static IAnimatedSprite CreateKoopaMovingRightSprite()
        {
            Texture2D koopaRight = game.Content.Load<Texture2D>(SpritePath.KoopaWalkRightPath);
            IAnimatedSprite rightWalkingKoopaSprite = new KoopaMovingSprite(koopaRight);
            return rightWalkingKoopaSprite;
        }
        public static IAnimatedSprite CreatePiranhaSprite()
        {
            Texture2D piranhatex = game.Content.Load<Texture2D>(SpritePath.PirahnaChompPath);
            IAnimatedSprite chompingPiranha = new PiranhaSprite(piranhatex);
            return chompingPiranha;
        }

        // Item Creators
        public static IAnimatedSprite Create1UPMushroomSprite()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.OneUPMushroom1APath);
            IAnimatedSprite oneUpMushroom = new OneUpMushroomSprite(texture);
            return oneUpMushroom;
        }
        public static IAnimatedSprite CreateFloatingCoinSprite()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.Coin1Path);
            IAnimatedSprite coin = new FloatingCoinSprite(texture);
            return coin;
        }
        public static IAnimatedSprite CreateBlockCoinSprite()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.Coin2Path);
            IAnimatedSprite coin = new BlockCoinSprite(texture);
            return coin;
        }
        public static IAnimatedSprite CreateFireFlowerSprite()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.FireFlowerPath);
            IAnimatedSprite fireFlower = new FireFlowerSprite(texture);
            return fireFlower;
        }
        public static IAnimatedSprite CreateIceFlowerSprite()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.IceFlowerPath);
            IAnimatedSprite fireFlower = new FireFlowerSprite(texture);
            return fireFlower;
        }
        public static IAnimatedSprite CreateStarmanSprite()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.Starman1Path);
            IAnimatedSprite starMan = new StarmanSprite(texture);
            return starMan;
        }
        public static IAnimatedSprite CreateSuperMushroomSprite()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.SuperMushroom1APath);
            IAnimatedSprite superMushroom = new SuperMushroomSprite(texture);
            return superMushroom;
        }

        // Block Creators
        public static IAnimatedSprite CreateExplodingBlock()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.BlockExplode2Path);
            IAnimatedSprite explodingBlockSprite = new ExplodingBlockSprite(texture);
            return explodingBlockSprite;
        }
        public static IAnimatedSprite CreateHiddenBlock()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.HiddenBlockPath);
            IAnimatedSprite hiddenBlockSprite = new OtherBlocksSprite(texture);
            return hiddenBlockSprite;
        }
        public static IAnimatedSprite CreateQuestionBlock()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.QuestionBlockPath);
            IAnimatedSprite questionBlockSprite = new QuestionBlockSprite(texture);
            return questionBlockSprite;
        }
        public static IAnimatedSprite CreateBrickBlock()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.RedBlockPath);
            IAnimatedSprite redBlockSprite = new OtherBlocksSprite(texture);
            return redBlockSprite;
        }
        public static IAnimatedSprite CreateRegularFloorBlock()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.RegularFloorBlockPath);
            IAnimatedSprite regularFloorBlockSprite = new OtherBlocksSprite(texture);
            return regularFloorBlockSprite;
        }
        public static IAnimatedSprite CreateStepPyramidBlock()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.StepPyramidBlockPath);
            IAnimatedSprite stepPyramidBlockSprite = new OtherBlocksSprite(texture);
            return stepPyramidBlockSprite;
        }
        public static IAnimatedSprite CreateUndergroundBlock()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.UndergroundBlockPath);
            IAnimatedSprite undergroundBlockSprite = new OtherBlocksSprite(texture);
            return undergroundBlockSprite;
        }
        public static IAnimatedSprite CreateUndergroundFloorBlock()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.UndergroundFloorBlockPath);
            IAnimatedSprite undergroundFloorBlockSprite = new OtherBlocksSprite(texture);
            return undergroundFloorBlockSprite;
        }
        public static IAnimatedSprite CreateUsedBlock()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.UsedBlockPath);
            IAnimatedSprite usedBlockSprite = new OtherBlocksSprite(texture);
            return usedBlockSprite;
        }
        public static IAnimatedSprite CreateSnowOnBlockSprite()
        {
            return new OtherBlocksSprite(game.Content.Load<Texture2D>(SpritePath.SnowOnBlockPath));
        }
        public static IAnimatedSprite CreateIceBlock1616Sprite()
        {
            return new OtherBlocksSprite(game.Content.Load<Texture2D>(SpritePath.IceBlock1616Path));
        }
        public static IAnimatedSprite CreateIceBlock1622Sprite()
        {
            return new OtherBlocksSprite(game.Content.Load<Texture2D>(SpritePath.IceBlock1622Path));
        }
        public static IAnimatedSprite CreateIceBlock1624Sprite()
        {
            return new OtherBlocksSprite(game.Content.Load<Texture2D>(SpritePath.IceBlock1624Path));
        }

        // Misc. Object Creators
        public static IAnimatedSprite CreateStaticSprites(String WhichTexture)
        {
            Texture2D texture;
            StaticSpriteMap.TryGetValue(WhichTexture, out texture);
            IAnimatedSprite staticObject = new StaticObject(texture);
            return staticObject;
        }
        // Misc. Object Creators
        public static Texture2D CreateMainMenu()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.MainscreenPath);
            return texture;
        }
        public static Texture2D CreateLevelSelectMenu()
        {
            return game.Content.Load<Texture2D>(SpritePath.LevelSelectScreenPath);
        }
        public static Texture2D CreateDot()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.DotPath);
            return texture;
        }
        public static Texture2D CreateLivesLeft()
        {
            Texture2D texture = null;
            if ((int)game.playerChar == 0 /* Game1.Characters.Mario */) texture = game.Content.Load<Texture2D>(SpritePath.LivesLeftMarioScreenPath);
            if ((int)game.playerChar == 1 /* Game1.Characters.Luigi */) texture = game.Content.Load<Texture2D>(SpritePath.LivesLeftLuigiScreenPath);
            if ((int)game.playerChar == 2 /* Game1.Characters.Bowser */) texture = game.Content.Load<Texture2D>(SpritePath.LivesLeftBowserScreenPath);
            return texture;
        }
        public static Texture2D CreateGameOver()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.GameOverScreenPath);
            return texture;
        }
        public static Texture2D CreateHighScore()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.HighScoreScreenPath);
            return texture;
        }
        public static Texture2D CreatePause()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.PauseScreenPath);
            return texture;
        }
        public static Texture2D CreateConfirmation()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.ConfirmationScreenPath);
            return texture;
        }
        public static Texture2D CreateOption()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.OptionMenuPath);
            return texture;
        }        
        public static IAnimatedSprite CreateSmallPipe()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.SmallPipePath);
            IAnimatedSprite smallPipe = new PipeSprite(texture);
            return smallPipe;
        }
        public static IAnimatedSprite CreateMediumPipe()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.MediumPipePath);
            IAnimatedSprite mediumPipe = new PipeSprite(texture);
            return mediumPipe;
        }
        public static IAnimatedSprite CreateLargePipe()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.LargePipePath);
            IAnimatedSprite largePipe = new PipeSprite(texture);
            return largePipe;
        }
        public static IAnimatedSprite CreateLLeftStandPipe()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.HorizontalLPipeLeftStandPath);
            IAnimatedSprite lPipeStanding = new PipeSprite(texture);
            return lPipeStanding;
        }
        public static IAnimatedSprite CreateLLeftInPipe()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.HorizontalLPipeLeftInPath);
            IAnimatedSprite lPipeRightIn = new PipeSprite(texture);
            return lPipeRightIn;
        }
        public static IAnimatedSprite CreateSmallHill()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.SmallHillPath);
            IAnimatedSprite smallHill = new StaticObject(texture);
            return smallHill;
        }
        public static IAnimatedSprite CreateBigHill()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.BigHillPath);
            IAnimatedSprite bigHill = new StaticObject(texture);
            return bigHill;
        }
        public static IAnimatedSprite CreateOneBush()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.OneBushPath);
            IAnimatedSprite oneBush = new StaticObject(texture);
            return oneBush;
        }
        public static IAnimatedSprite CreateTwoBush()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.TwoBushPath);
            IAnimatedSprite twoBush = new StaticObject(texture);
            return twoBush;
        }
        public static IAnimatedSprite CreateThreeBush()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.ThreeBushPath);
            IAnimatedSprite threeBush = new StaticObject(texture);
            return threeBush;
        }
        public static IAnimatedSprite CreateOneCloud()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.OneCloudPath);
            IAnimatedSprite oneCloud = new StaticObject(texture);
            return oneCloud;
        }
        public static IAnimatedSprite CreateTwoClouds()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.TwoCloudsPath);
            IAnimatedSprite twoClouds = new StaticObject(texture);
            return twoClouds;
        }
        public static IAnimatedSprite CreateThreeClouds()
        {
            Texture2D texture = game.Content.Load<Texture2D>(SpritePath.ThreeCloudsPath);
            IAnimatedSprite threeClouds = new StaticObject(texture);
            return threeClouds;
        }
        public static IAnimatedSprite CreateFireballSprite()
        {
            return new MarioFireballSprite(game.Content.Load<Texture2D>(SpritePath.MarioFireballPath));
        }
        public static IAnimatedSprite CreateIceballSprite()
        {
            return new MarioFireballSprite(game.Content.Load<Texture2D>(SpritePath.MarioIceballPath));
        }
        public static IAnimatedSprite CreateLeftEmberSprite()
        {
            return new EmberSprite(game.Content.Load<Texture2D>(SpritePath.EmberLeftPath));
        }
        public static IAnimatedSprite CreateRightEmberSprite()
        {
            return new EmberSprite(game.Content.Load<Texture2D>(SpritePath.EmberRightPath));
        }
        public static IAnimatedSprite CreateLeftFFSprite()
        {
            return new FlamethrowerSprite(game.Content.Load<Texture2D>(SpritePath.FFLeftPath),false);
        }
        public static IAnimatedSprite CreateRightFFSprite()
        {
            return new FlamethrowerSprite(game.Content.Load<Texture2D>(SpritePath.FFRightPath),true);
        }
        public static IAnimatedSprite CreateLeftMFSprite()
        {
            return new MegaFireSprite(game.Content.Load<Texture2D>(SpritePath.MFLeftPath), false);
        }
        public static IAnimatedSprite CreateRightMFSprite()
        {
            return new MegaFireSprite(game.Content.Load<Texture2D>(SpritePath.MFRightPath), true);
        }
        public static IAnimatedSprite CreateFireballExplodingSprite()
        {
            return new MarioFireballExplodingSprite(game.Content.Load<Texture2D>(SpritePath.FireBallWorksPath));
        }
        public static IAnimatedSprite CreateIceballExplodingSprite()
        {
            return new MarioFireballExplodingSprite(game.Content.Load<Texture2D>(SpritePath.IceballExplosionPath));
        }

        public static SpriteFont CreateHUDSpriteFont()
        {
            return game.Content.Load<SpriteFont>(SpritePath.HUDFontPath);
        }

        public static SpriteFont CreateLivesLeftFont()
        {
            return game.Content.Load<SpriteFont>(SpritePath.LivesLeftFontPath);
        }

        public static SpriteFont CreateOptionsFont()
        {
            return game.Content.Load<SpriteFont>(SpritePath.OptionsFontPath);
        }

        public static SpriteFont CreateHighScoreFont()
        {
            return game.Content.Load<SpriteFont>(SpritePath.HighScoreFontPath);
        }
        public static IAnimatedSprite CreateHUDCoinSprite() 
        {
            return new HUDCoinSprite(game.Content.Load<Texture2D>(SpritePath.HUDCoinPath));
        }

        public static IAnimatedSprite CreateFlameShotRightSprite()
        {
            return new FlameShotSprite(game.Content.Load<Texture2D>(SpritePath.FlameShotRightPath));
        }

        public static IAnimatedSprite CreateFlameShotDownSprite()
        {
            return new FlameShotSprite(game.Content.Load<Texture2D>(SpritePath.FlameShotDownPath));
        }

        public static IAnimatedSprite CreateFlameShotLeftSprite()
        {
            return new FlameShotSprite(game.Content.Load<Texture2D>(SpritePath.FlameShotLeftPath));
        }
    }
}
