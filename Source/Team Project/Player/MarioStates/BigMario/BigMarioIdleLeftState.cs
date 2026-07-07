using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class BigMarioIdleLeftState : IPlayerState
    {
        private IAnimatedSprite sprite;
        private Mario mario;

        public IAnimatedSprite Sprite { get { return sprite; } }

        public BigMarioIdleLeftState(Mario m)
        {
            mario = m;
            sprite = SpriteFactory.CreateBigMarioIdleLeftSprite();
        }

        public void Left()
        {
            mario.State = new BigMarioRunningLeftState(mario);
        }

        public void Right()
        {
            if (mario.Movement.X < -2.5)
            {
                mario.State = new BigMarioTurningRightState(mario);
            }
            else
            {
                mario.State = new BigMarioIdleRightState(mario);
            }
        }

        public void Up()
        {
            if (MarioMovement.IsGrounded && MarioMovement.CanJump)
            {
                MarioMovement.Jumping();
            }

            if (MarioMovement.IsJumping)
                mario.State = new BigMarioJumpingLeftState(mario);
        }

        public void Down()
        {
            mario.State = new BigMarioCrouchingLeftState(mario);
            mario.Location = new Vector2(mario.Location.X, mario.Location.Y + 10);
        }

        public void B()
        {
        }

        public void NoCommand()
        {
        }

        public void GetHit()
        {
            mario.State = new SmallMarioIdleLeftState(mario);
            mario.Game.currentPlayer = new PoweringDownLeftMario(mario);
        }

        public void PoleSequence()
        {
            mario.State = new BigMarioWinningArmUpRightState(mario);
        }

        public void EndAnimation()
        {
        }

        public void CollectItem(IItem item)
        {
            if (item is FloatingCoin)
            {
                // Do some score stuff
            }
            else if (item is FireFlower)
            {
                mario.State = new FiringUpLeftMario(mario);
            }
            else if (item is IceFlower)
            {
                mario.State = new IcingUpLeftMario(mario);
            }
            else if (item is OneUpMushroom)
            {
                // Give mario an extra life
            }
            else if (item is Starman)
            {
                mario.Game.currentPlayer = new StarMario(mario);
            }
        }

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision, Vector2 marioLocation, Vector2 camLocation)
        {
            if (GetPower() == Mario.Power.Dead) { }
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
            return Mario.Power.Big;
        }
    }
}

