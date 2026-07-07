using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class SmallBowserIdleRightState : IPlayerState
    {
        private IAnimatedSprite sprite;
        private Mario mario;

        public IAnimatedSprite Sprite { get { return sprite; } }

        public SmallBowserIdleRightState(Mario m)
        {
            mario = m;
            sprite = SpriteFactory.CreateSmallBowserIdleRightSprite();
        }

        public void Left()
        {
            if (mario.Movement.X > 2.5)
            {
                mario.State = new SmallBowserIdleLeftState(mario);
            }
            else
            {
                mario.State = new SmallBowserIdleLeftState(mario);
            }
        }

        public void Right()
        {
            mario.State = new SmallBowserRunningRightState(mario);
        }

        public void Up()
        {
            if (MarioMovement.IsGrounded && MarioMovement.CanJump)
            {
                MarioMovement.Jumping();
            }

            if (MarioMovement.IsJumping)
                mario.State = new SmallBowserJumpingRightState(mario);
        }

        public void Down()
        {
            mario.Movement = new Vector2(0, mario.Movement.Y);
        }

        public void B()
        {
            if (ProjectileTracker.GetNumberOfProjectilesOnScreen() < 2 && !ControllerHelper.IsBHeld)
            {
                mario.State = new BowserEmberRightState(mario);
                mario.Location = new Vector2(mario.Location.X, mario.Location.Y + 2);
            }
        }

        public void NoCommand()
        {
        }

        public void GetHit()
        {
           // mario.State = new MarioDeadRightState(mario);
        }

        public void PoleSequence()
        {
           // mario.State = new SmallMarioWinningLegDownRightState(mario);
        }

        public void EndAnimation()
        {
            mario.Movement = new Vector2(60f, mario.Movement.Y);

            if (MarioMovement.IsGrounded)
            {
                mario.State = new SmallBowserRunningRightState(mario);
            }
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
             //   mario.Game.Player = new StarMario(mario);
            }
            else if (item is SuperMushroom || item is FireFlower || item is IceFlower)
            {
                mario.State = new PoweringUpRightBowser(mario);
            }
        }

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision, Vector2 marioLocation, Vector2 camLocation)
        {
            if (IsWarping(marioLocation) && IsInMiddleOfPipe(mario, pipe))
            {
                if (collision == CollisionDetector.CollisionType.top && ControllerHelper.IsDDown)
                {
                 //   mario.State = new SmallMarioGoingDownPipeRightState(mario, marioLocation, camLocation);
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private bool IsInMiddleOfPipe(Mario m, IPipe pipe)
        {
            if (m.Location.X > pipe.Location.X && m.Location.X < pipe.Location.X + pipe.Rectangle.Width - m.Rectangle.Width)
            {
                return true;
            }
            else
            {
                return false;
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
            return Mario.Power.Small;
        }
    }
}
