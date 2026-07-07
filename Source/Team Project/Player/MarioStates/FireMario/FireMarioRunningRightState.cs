using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    class FireMarioRunningRightState : IPlayerState
    {
        private MarioRunningSprite sprite;
        private Mario mario;

        public IAnimatedSprite Sprite { get { return sprite; } }

        public FireMarioRunningRightState(Mario m)
        {
            sprite = (MarioRunningSprite)SpriteFactory.CreateFireMarioRunningRightSprite();
            mario = m;
        }

        public void Left()
        {
            mario.State = new FireMarioTurningLeftState(mario);
        }

        public void Right()
        {
            MarioMovement.Right();
        }

        public void Up()
        {
            if (MarioMovement.IsGrounded && MarioMovement.CanJump)
            {
                MarioMovement.Jumping();
            }

            if (MarioMovement.IsJumping)
                mario.State = new FireMarioJumpingRightState(mario);
        }

        public void Down()
        {
            mario.State = new FireMarioCrouchingRightState(mario);
            mario.Location = new Vector2(mario.Location.X, mario.Location.Y + 10);
        }

        public void B()
        {
            sprite.DelayTime = 60;
            if (ProjectileTracker.GetNumberOfProjectilesOnScreen() < 2 && !ControllerHelper.IsBHeld)
            {
                mario.State = new FireMarioFireballRightState(mario);
                mario.Location = new Vector2(mario.Location.X, mario.Location.Y + 2);
            }
        }

        public void NoCommand()
        {
            mario.State = new FireMarioIdleRightState(mario);
        }

        public void GetHit()
        {
            mario.State = new SmallMarioRunningRightState(mario);
            mario.Game.currentPlayer = new PoweringDownRightMario(mario);
        }

        public void PoleSequence()
        {
            mario.State = new FireMarioWinningArmUpRightState(mario);
        }

        public void EndAnimation()
        {
            MarioMovement.IsRunning = true;
            mario.Movement = new Vector2(70f, mario.Movement.Y);
        }

        public void CollectItem(IItem item)
        {
            if (item is FloatingCoin)
            {
                // Do some score stuff
            }
            else if (item is OneUpMushroom)
            {
                // Give mario an extra life
            }
            else if (item is Starman)
            {
                mario.Game.currentPlayer = new StarMario(mario);
            }
            else if (item is IceFlower)
            {
                mario.State = new IcingUpLeftMario(mario);
            }
        }

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision, Vector2 marioLocation, Vector2 camLocation)
        {
            if (IsWarping(marioLocation))
            {
                if (collision == CollisionDetector.CollisionType.left)
                {
                    mario.State = new FireMarioGoingIntoPipeRightState(mario, marioLocation, camLocation);
                }
            }
            else if (GetPower() == Mario.Power.Dead) { }
            else
            {
                switch (collision)
                {
                    case CollisionDetector.CollisionType.top:
                        mario.Location = new Vector2(mario.Location.X, pipe.Rectangle.Y - mario.Rectangle.Height);
                        MarioMovement.Grounded();
                        break;
                    case CollisionDetector.CollisionType.bottom:
                        mario.Location = new Vector2(mario.Location.X, pipe.Rectangle.Y + pipe.Rectangle.Height);
                        MarioMovement.IsFalling = true;
                        MarioMovement.IsJumping = false;
                        break;
                    case CollisionDetector.CollisionType.left:
                        mario.Location = new Vector2(pipe.Rectangle.X - mario.Rectangle.Width, mario.Location.Y);
                        if (!MarioMovement.IsFalling)
                            mario.Movement = new Vector2(Speed.Zero, mario.Movement.Y);
                        break;
                    case CollisionDetector.CollisionType.right:
                        mario.Location = new Vector2(pipe.Rectangle.X + pipe.Rectangle.Width, mario.Location.Y);
                        if (!MarioMovement.IsFalling)
                            mario.Movement = new Vector2(Speed.Zero, mario.Movement.Y);
                        break;
                }
            }
        }

        private bool IsWarping(Vector2 marioLocation)
        {
            if (mario.Location != marioLocation)
            {
                mario.Movement = new Vector2(0, mario.Movement.Y);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }

        public Mario.Power GetPower()
        {
            return Mario.Power.Fire;
        }
    }
}
