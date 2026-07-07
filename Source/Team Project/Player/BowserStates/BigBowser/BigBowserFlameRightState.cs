using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class BigBowserFlameRightState : IPlayerState
    {
        private IAnimatedSprite sprite;
        private Mario mario;
        private float timer = 0;
        private float totalTime = 80;

        public IAnimatedSprite Sprite { get { return sprite; } }

        public BigBowserFlameRightState(Mario m)
        {
            mario = m;
            sprite = SpriteFactory.CreateBigBowserBreathRightSprite();
            ProjectileTracker.CreateFF(new Vector2(mario.Location.X + mario.Rectangle.Width, mario.Location.Y + 15), true, mario);
            SoundManager.PlayFFStartSound();
        }

        public void Left()
        {
        }

        public void Right()
        {
        }

        public void Up()
        {
        }

        public void Down()
        {
        }

        public void B()
        {
        }

        public void NoCommand()
        {
        }

        public void GetHit()
        {
           
        }

        public void PoleSequence()
        {
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
               // mario.Game.currentPlayer = new StarMario(mario);
            }
            else if (item is IceFlower)
            {
               // mario.State = new IcingUpLeftMario(mario);
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
            timer++;
            if (timer >= totalTime)
            {
                mario.State = new BigBowserIdleRightState(mario);
                mario.Location = new Vector2(mario.Location.X, mario.Location.Y);
            }
            mario.Location = new Vector2(mario.Location.X, mario.Location.Y);
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

