using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public static class MarioMovement
    {
        public static Boolean IsJumping { get; set; }
        public static Boolean IsFalling { get; set; }
        public static Boolean IsGrounded { get; set; }
        public static Boolean IsRunning { get; set; }
        public static Boolean IsBouncing { get; set; }
        public static Boolean HasBounced { get; set; }
        public static Boolean CanJump { get; set; }
        public static float GravityRate { get; set; }

        private static Mario mario;
        private static float speedDecayRateX = Speed.Rate;
        private static float runningRate = Speed.RunningRate;
        private static float stoppingRate = Speed.StoppingRate;
        private static float maxSpeed = Speed.OneHundredFifty;


        public static void LoadMario(Mario m)
        {
            GravityRate = Speed.Rate;
            mario = m;
        }

        public static void HitJump()
        {
            IsFalling = false;
            mario.Movement = new Vector2(mario.Movement.X, mario.Movement.Y * GravityRate);

            if (mario.Movement.Y > Speed.NegativeThirty)
            {
                IsBouncing = false;
            }
        }

        public static void Left()
        {
            IsRunning = true;
            if (mario.Movement.X >= Speed.NegativeNineteen)
            {
                mario.Movement = new Vector2(Speed.NegativeThirty, mario.Movement.Y);
            }

            mario.Movement = new Vector2(mario.Movement.X / speedDecayRateX, mario.Movement.Y);

            if (mario.Movement.X < -maxSpeed)
            {
                mario.Movement = new Vector2(-maxSpeed, mario.Movement.Y);
            }
        }

        public static void Right()
        {
            IsRunning = true;
            if (mario.Movement.X <= Speed.Nineteen)
            {
                mario.Movement = new Vector2(Speed.Thirty, mario.Movement.Y);
            }

            mario.Movement = new Vector2(mario.Movement.X / speedDecayRateX, mario.Movement.Y);

            if (mario.Movement.X > maxSpeed)
            {
                mario.Movement = new Vector2(maxSpeed, mario.Movement.Y);
            }
        }

        public static void Falling()
        {
            IsGrounded = false;
            IsJumping = false;
            CanJump = false;
            if (mario.Movement.Y <= Speed.Zero)
            {
                mario.Movement = new Vector2(mario.Movement.X, Speed.Thirty);
            }

            else if (mario.Movement.Y > Speed.Zero && mario.Movement.Y < Speed.ThreeHundredFifty)
            {
                mario.Movement = new Vector2(mario.Movement.X, mario.Movement.Y / GravityRate);
            }

            else
            {
                mario.Movement = new Vector2(mario.Movement.X, Speed.ThreeHundredFifty);
            }
        }    
    
        public static void Jumping()
        {
            IsGrounded = false;
            IsJumping = true;
            CanJump = false;
            mario.Movement = new Vector2(mario.Movement.X, -Speed.ThreeHundredFifty);
            if (mario.GetPower() == Mario.Power.Small)
            {
                SoundManager.PlaySmallMarioJumpSound();
            }
            else
            {
                SoundManager.PlaySuperMarioJumpSound();
            }

        }

        public static void StillJumping()
        {
            mario.Movement = new Vector2(mario.Movement.X, mario.Movement.Y * GravityRate);

            if (mario.Movement.Y > Speed.NegativeThirty)
            {
                IsJumping = false;
            }
        }

        public static void Grounded()
        {
            mario.Movement = new Vector2(mario.Movement.X, Speed.Thirty);
            IsGrounded = true;
            IsJumping = false;
            IsFalling = false;
            HasBounced = false;
        }

        public static void Bounce()
        {
            IsBouncing = true;
            HasBounced = true;
            mario.Movement = new Vector2(mario.Movement.X, -Speed.OneHundred);
        }

        public static void Update() //Updates mario speed and variables
        {
            if (ControllerHelper.IsBHeld && IsRunning && (mario.Movement.X == Speed.OneHundredFifty || mario.Movement.X == -Speed.OneHundredFifty))
                mario.Movement = new Vector2(mario.Movement.X / runningRate, mario.Movement.Y);

            if (ControllerHelper.IsBHeld && IsJumping && (mario.Movement.X > Speed.OneHundredForty || mario.Movement.X < -Speed.OneHundredForty))
                mario.Movement = new Vector2(mario.Movement.X, mario.Movement.Y / Speed.JumpingRate);

            if (!IsRunning)
            {
                mario.Movement = new Vector2(mario.Movement.X * stoppingRate, mario.Movement.Y);
            }

            IsFalling = true; //goes back to original values to recheck values
            IsRunning = false;

            OptionMenu.Gravity();
            ControllerHelper.GravityControlOn = false;

            if (!ControllerHelper.IsUpHeld && IsGrounded)
                CanJump = true;
        }

        public static void OnIcyTerrain()
        {
            speedDecayRateX = Speed.IceRate;
            stoppingRate = Speed.IceStoppingRate;
            runningRate = Speed.IceRunningRate;
            maxSpeed = Speed.TwoHundred;
        }

        public static void OnNormalTerrain()
        {
            speedDecayRateX = Speed.Rate;
            stoppingRate = Speed.StoppingRate;
            runningRate = Speed.RunningRate;
            maxSpeed = Speed.OneHundredFifty;
        }
    }
}
