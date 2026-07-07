using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Team_Project
{
    public static class SoundFactory
    {
        private static Game1 game;

        public static void LoadGame(Game1 Game)
        {
            game = Game;
        }

        public static SoundEffect CreateBlockBreakSound()
        {
            SoundEffect blockBreak = game.Content.Load<SoundEffect>("Sounds/Block/smb_breakblock");
            return blockBreak;
        }

        public static SoundEffect CreateBlockBumpSound()
        {
            SoundEffect blockBump = game.Content.Load<SoundEffect>("Sounds/Block/smb_bump");
            return blockBump;
        }

        public static SoundEffect CreateEnemyStompSound()
        {
            SoundEffect enemyStomp = game.Content.Load<SoundEffect>("Sounds/Enemy/smb_stomp");
            return enemyStomp;
        }

        public static SoundEffect CreateEnemyKickSound()
        {
            SoundEffect enemyKick = game.Content.Load<SoundEffect>("Sounds/Enemy/smb_kick");
            return enemyKick;
        }

        public static SoundEffect CreatePauseSound()
        {
            SoundEffect pause = game.Content.Load<SoundEffect>("Sounds/Game State/smb_pause");
            return pause;
        }

        public static SoundEffect Create1UpSound()
        {
            SoundEffect oneUp = game.Content.Load<SoundEffect>("Sounds/Item/smb_1-up");
            return oneUp;
        }

        public static SoundEffect CreateCoinSound()
        {
            SoundEffect coin = game.Content.Load<SoundEffect>("Sounds/Item/smb_coin");
            return coin;
        }

        public static SoundEffect CreateEndingPointsFromTimerSound()
        {
            SoundEffect endingPoints = game.Content.Load<SoundEffect>("Sounds/Item/smb_ending_points");
            return endingPoints;
        }

        public static SoundEffect CreateItemAppearingSound()
        {
            SoundEffect itemAppearing = game.Content.Load<SoundEffect>("Sounds/Item/smb_powerup_appears");
            return itemAppearing;
        }

        public static SoundEffect CreateFireworksSound()
        {
            SoundEffect fireworks = game.Content.Load<SoundEffect>("Sounds/Level Ending/smb_fireworks");
            return fireworks;
        }

        public static SoundEffect CreateFlagpoleSound()
        {
            SoundEffect flagpole = game.Content.Load<SoundEffect>("Sounds/Level Ending/smb_flagpole");
            return flagpole;
        }

        public static SoundEffect CreateMarioSmallJumpSound()
        {
            SoundEffect smallMarioJump = game.Content.Load<SoundEffect>("Sounds/Mario/smb_jumpsmall");
            return smallMarioJump;
        }

        public static SoundEffect CreateMarioSuperJumpSound()
        {
            SoundEffect superMarioJump = game.Content.Load<SoundEffect>("Sounds/Mario/smb_jump-super");
            return superMarioJump;
        }

        public static SoundEffect CreateMarioPipePowerDownSound()
        {
            SoundEffect pipeOrPowerDown = game.Content.Load<SoundEffect>("Sounds/Mario/smb_pipe_powerdown");
            return pipeOrPowerDown;
        }

        public static SoundEffect CreateMarioPowerUpSound()
        {
            SoundEffect powerUp = game.Content.Load<SoundEffect>("Sounds/Mario/smb_powerup");
            return powerUp;
        }

        public static SoundEffect CreateProjectileExplodeSound()
        {
            SoundEffect fireballExplode = game.Content.Load<SoundEffect>("Sounds/Projectile/smb_bump");
            return fireballExplode;
        }

        public static SoundEffect CreateProjectileStartSound()
        {
            SoundEffect fireballStart = game.Content.Load<SoundEffect>("Sounds/Projectile/smb_fireball");
            return fireballStart;
        }

        public static SoundEffect CreateFFStartSound()
        {
            SoundEffect ffStart = game.Content.Load<SoundEffect>("Sounds/Projectile/FF");
            return ffStart;
        }

        public static SoundEffect CreateMFStartSound()
        {
            SoundEffect mfStart = game.Content.Load<SoundEffect>("Sounds/Projectile/explosion");
            return mfStart;
        }

        public static Song CreateOverworldThemeMusic()
        {
            Song overworldTheme = game.Content.Load<Song>("Sounds/Music/01-main-theme-overworld");
            return overworldTheme;
        }

        public static Song CreateUnderworldThemeMusic()
        {
            Song underworldTheme = game.Content.Load<Song>("Sounds/Music/02-underworld");
            return underworldTheme;
        }

        public static Song CreateStarmanMusic()
        {
            Song starman = game.Content.Load<Song>("Sounds/Music/05-starman");
            return starman;
        }

        public static Song CreateLevelCompleteMusic()
        {
            Song levelComplete = game.Content.Load<Song>("Sounds/Music/06-level-complete");
            return levelComplete;
        }

        public static Song CreateMarioDeadMusic()
        {
            Song marioDead = game.Content.Load<Song>("Sounds/Music/08-you-re-dead");
            return marioDead;
        }

        public static Song CreateGameOverMusic()
        {
            Song gameOver = game.Content.Load<Song>("Sounds/Music/09-game-over");
            return gameOver;
        }

        public static Song CreateHurriedUndergroundMusic()
        {
            Song hurriedUnderworld = game.Content.Load<Song>("Sounds/Music/14-hurry-underground-");
            return hurriedUnderworld;
        }

        public static Song CreateHurriedStarmanMusic()
        {
            Song hurriedStarman = game.Content.Load<Song>("Sounds/Music/17-hurry-starman-");
            return hurriedStarman;
        }

        public static Song CreateHurriedOverworldMusic()
        {
            Song hurriedOverwold = game.Content.Load<Song>("Sounds/Music/18-hurry-overworld-");
            return hurriedOverwold;
        }

        public static Song CreateHurryMusic()
        {
            Song hurrySound = game.Content.Load<Song>("Sounds/Music/19-hurrysound");
            return hurrySound;
        }

        public static Song CreateSilence()
        {
            Song silence = game.Content.Load<Song>("Sounds/Music/20-silence");
            return silence;
        }
    }
}
