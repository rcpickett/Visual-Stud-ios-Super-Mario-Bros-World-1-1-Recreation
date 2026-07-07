using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class IceMarioCrouchingLeftState : IPlayerState
    {
        private IAnimatedSprite sprite;
        private Mario mario;

        public IAnimatedSprite Sprite { get { return sprite; } }

        public IceMarioCrouchingLeftState(Mario m)
        {
            sprite = SpriteFactory.CreateIceMarioCrouchingLeftSprite();
            mario = m;
        }

        public void Left()
        {
        }

        public void Right()
        {
            mario.State = new IceMarioCrouchingRightState(mario);
        }

        public void Up()
        {
            mario.State = new IceMarioIdleLeftState(mario);
            mario.Location = new Vector2(mario.Location.X, mario.Location.Y - 10);
        }

        public void Down()
        {
            mario.Movement = new Vector2(0, mario.Movement.Y);
        }

        public void B()
        {
        }

        public void NoCommand()
        {
            mario.State = new IceMarioIdleLeftState(mario);
            mario.Location = new Vector2(mario.Location.X, mario.Location.Y - 10);
        }

        public void GetHit()
        {
            mario.State = new SmallMarioIdleLeftState(mario);
            mario.Location = new Vector2(mario.Location.X, mario.Location.Y - 10);
            mario.Game.currentPlayer = new PoweringDownLeftMario(mario);
        }

        public void PoleSequence()
        {
            mario.State = new IceMarioWinningArmUpRightState(mario);
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
            else if (item is OneUpMushroom)
            {
                // Give mario an extra life
            }
            else if (item is Starman)
            {
                mario.Game.currentPlayer = new StarMario(mario);
            }
            else if (item is FireFlower)
            {
                mario.State = new FiringUpLeftMario(mario);
            }
        }

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision, Vector2 marioLocation, Vector2 camLocation)
        {
            if (IsWarping(marioLocation) && IsInMiddleOfPipe(mario, pipe))
            {
                if (collision == CollisionDetector.CollisionType.top && ControllerHelper.IsDDown)
                {
                    mario.State = new IceMarioGoingDownPipeLeftState(mario, marioLocation, camLocation);
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
            return Mario.Power.Ice;
        }
    }
}

