using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Team_Project
{
    public static class SoundManager
    {
        private static SoundEffectInstance marioJump;
        private static float hurryTimer;

        public static Song CurrentBackgroundTheme { get; set; }

        public static bool PlayLevelEndingSound { get; set; }


        public static void PlayBlockBreakSound()
        {
            SoundEffect blockBreak = SoundFactory.CreateBlockBreakSound();
            blockBreak.Play();
        }
        public static void PlayBlockBumpSound()
        {
            SoundEffect blockBump = SoundFactory.CreateBlockBumpSound();
            blockBump.Play();
        }
        public static void PlayEnemyStompSound()
        {
            SoundEffect enemyStomp = SoundFactory.CreateEnemyStompSound();
            enemyStomp.Play();
        }
        public static void PlayEnemyKickSound()
        {
            SoundEffect enemyKick = SoundFactory.CreateEnemyKickSound();
            enemyKick.Play();
        }
        public static void PlayPauseSound()
        {
            SoundEffect pauseSound = SoundFactory.CreatePauseSound();
            pauseSound.Play();
        }
        public static void Play1UpSound()
        {
            SoundEffect oneUp = SoundFactory.Create1UpSound();
            oneUp.Play();
        }
        public static void PlayCoinSound()
        {
            SoundEffect coinSound = SoundFactory.CreateCoinSound();
            coinSound.Play();
        }

        public static void PlayEndingScoreFromTimerSound()
        {
            SoundEffect endingPoints = SoundFactory.CreateEndingPointsFromTimerSound();
            SoundEffectInstance endingPointsSound = endingPoints.CreateInstance();
            endingPointsSound.Volume = Value.OneHalf;
            endingPointsSound.Play();
        }

        public static void PlayItemAppearingSound()
        {
            SoundEffect itemAppearing = SoundFactory.CreateItemAppearingSound();
            itemAppearing.Play();
        }
        public static void PlayFireworksSound()
        {
            SoundEffect fireworks = SoundFactory.CreateFireworksSound();
            fireworks.Play();
        }
        public static void PlayFlagpoleSound()
        {
            SoundEffect flagpole = SoundFactory.CreateFlagpoleSound();
            flagpole.Play();
        }
        public static void PlaySmallMarioJumpSound()
        {
            SoundEffect smallMarioJump = SoundFactory.CreateMarioSmallJumpSound();
            marioJump = smallMarioJump.CreateInstance();
            marioJump.Play();
        }
        public static void PlaySuperMarioJumpSound()
        {
            SoundEffect superMarioJump = SoundFactory.CreateMarioSuperJumpSound();
            marioJump = superMarioJump.CreateInstance();
            marioJump.Play();
        }
        public static void PlayMarioPipeOrPowerDownSound()
        {
            SoundEffect pipeOrPowerDown = SoundFactory.CreateMarioPipePowerDownSound();
            pipeOrPowerDown.Play();
        }
        public static void PlayMarioPowerUpSound()
        {
            SoundEffect powerUp = SoundFactory.CreateMarioPowerUpSound();
            powerUp.Play();
        }
        public static void PlayProjectileStartSound()
        {
            SoundEffect fireballStart = SoundFactory.CreateProjectileStartSound();
            fireballStart.Play();
        }
        public static void PlayFFStartSound()
        {
            SoundEffect ffStart = SoundFactory.CreateFFStartSound();
            ffStart.Play();
        }
        public static void PlayMFStartSound()
        {
            SoundEffect mfStart = SoundFactory.CreateMFStartSound();
            mfStart.Play();
        }
        public static void PlayProjectileExplodeSound()
        {
            SoundEffect fireballExplode = SoundFactory.CreateProjectileExplodeSound();
            fireballExplode.Play();
        }
        private static void PlayOverworldTheme()
        {
            Song overworld = SoundFactory.CreateOverworldThemeMusic();
            MediaPlayer.Stop();
            MediaPlayer.Play(overworld);
            CurrentBackgroundTheme = overworld;
        }
        private static void PlayUnderworldTheme()
        {
            Song underworld = SoundFactory.CreateUnderworldThemeMusic();
            MediaPlayer.Stop();
            MediaPlayer.Play(underworld);
            CurrentBackgroundTheme = underworld;
        }

        private static void PlayStarMarioTheme()
        {
            Song starMario = SoundFactory.CreateStarmanMusic();
            MediaPlayer.Stop();
            MediaPlayer.Play(starMario);
            CurrentBackgroundTheme = starMario;
        }
        private static void PlayLevelCompleteTheme()
        {
            Song levelComplete = SoundFactory.CreateLevelCompleteMusic();
            MediaPlayer.Stop();
            MediaPlayer.Play(levelComplete);
            CurrentBackgroundTheme = levelComplete;
        }
        private static void PlayMarioDeadTheme()
        {
            Song marioDead = SoundFactory.CreateMarioDeadMusic();
            MediaPlayer.Stop();
            MediaPlayer.Play(marioDead);
            CurrentBackgroundTheme = marioDead;
        }
        public static void PlayGameOverTheme()
        {
            if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateGameOverMusic()))
            {
                Song gameOver = SoundFactory.CreateGameOverMusic();
                MediaPlayer.Stop();
                MediaPlayer.Play(gameOver);
                CurrentBackgroundTheme = gameOver;
            }
        }
        private static void PlayHurriedUnderworldTheme()
        {
            Song hurriedUnderworld = SoundFactory.CreateHurriedUndergroundMusic();
            MediaPlayer.Stop();
            MediaPlayer.Play(hurriedUnderworld);
            CurrentBackgroundTheme = hurriedUnderworld;
        }
        private static void PlayHurriedStarmanTheme()
        {
            Song hurriedStarman = SoundFactory.CreateHurriedStarmanMusic();
            MediaPlayer.Stop();
            MediaPlayer.Play(hurriedStarman);
            CurrentBackgroundTheme = hurriedStarman;
        }
        private static void PlayHurriedOverworldTheme()
        {
            Song hurriedOverworld = SoundFactory.CreateHurriedOverworldMusic();
            MediaPlayer.Stop();
            MediaPlayer.Play(hurriedOverworld);
            CurrentBackgroundTheme = hurriedOverworld;
        }
        public static void PlayHurrySound()
        {
            if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateHurryMusic()))
            {
                Song hurrySound = SoundFactory.CreateHurryMusic();
                MediaPlayer.Stop();
                MediaPlayer.Play(hurrySound);
                CurrentBackgroundTheme = hurrySound;
                hurryTimer = Value.Zero;
            }
        }
        private static Boolean HasFinishedPlayingHurrySound(GameTime gameTime)
        {
            Song hurrySound = SoundFactory.CreateHurryMusic();
            if (CurrentBackgroundTheme.Equals(SoundFactory.CreateHurryMusic()))
            {
                hurryTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (hurryTimer >= hurrySound.Duration.Milliseconds*Value.Three)
                {
                    hurryTimer = hurrySound.Duration.Milliseconds;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (hurryTimer >= hurrySound.Duration.Milliseconds)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static void ChooseBackgroundMusic(IPlayer mario, GameTime gameTime, bool isEndOfGame)
        {
            bool finishedHurrySound = HasFinishedPlayingHurrySound(gameTime);
            if (mario.GetPower() == Mario.Power.Dead)
            {
                if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateMarioDeadMusic()))
                {
                    SoundManager.PlayMarioDeadTheme();
                }
            }
            else if (PlayLevelEndingSound)
            {
                if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateLevelCompleteMusic()))
                {
                    SoundManager.PlayLevelCompleteTheme();
                }
            }
            else if (finishedHurrySound && !isEndOfGame)
            {
                if (mario is StarMario)
                {
                    if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateHurriedStarmanMusic()))
                    {
                        SoundManager.PlayHurriedStarmanTheme();
                    }
                }
                else if (mario.Location.X > Value.Zero)
                {
                    if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateHurriedOverworldMusic()))
                    {
                        SoundManager.PlayHurriedOverworldTheme();
                    }
                }
                else if (mario.Location.X < Value.Zero)
                {
                    if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateHurriedUndergroundMusic()))
                    {
                        SoundManager.PlayHurriedUnderworldTheme();
                    }
                }
                
            }
            else if(!finishedHurrySound && !CurrentBackgroundTheme.Equals(SoundFactory.CreateHurryMusic()) && !isEndOfGame)
            {
                if (mario is StarMario)
                {
                    if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateStarmanMusic()))
                    {
                        SoundManager.PlayStarMarioTheme();
                    }
                }
                else if (mario.Location.X > Value.Zero)
                {
                    if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateOverworldThemeMusic()))
                    {
                            SoundManager.PlayOverworldTheme();
                    }

                }
                else if (mario.Location.X < Value.Zero)
                {
                    if (!CurrentBackgroundTheme.Equals(SoundFactory.CreateUnderworldThemeMusic()))
                    {
                        SoundManager.PlayUnderworldTheme();
                    }
                }
            }
        }
        public static void PauseCurrentMusic()
        {
            MediaPlayer.Pause();
        }
        public static void ResumeMusic()
        {
            MediaPlayer.Resume();
        }
        public static void ResetHurryTimer()
        {
            hurryTimer = Value.Zero;
        }
        public static void StopMarioJumpSound()
        {
            marioJump.Stop();
        }
    }
}
