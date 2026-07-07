using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class BigMarioComingOutOfPipeState : IPlayerState
    {
        private IAnimatedSprite sprite;
        private Mario mario;
        private float elapsedTime = 0;
        private float timer = 0;
        private float delayTime = 100;
        private Vector2 marioStartingLocation;

        public IAnimatedSprite Sprite { get { return sprite; } }

        public BigMarioComingOutOfPipeState(Mario m)
        {
            mario = m;
            sprite = SpriteFactory.CreateBigMarioIdleRightSprite();
            marioStartingLocation = mario.Location;
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
        }

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision, Vector2 marioLocation, Vector2 p)
        {
        }

        public void Update(GameTime gameTime)
        {
            mario.Movement = new Vector2(Speed.Zero, Speed.Zero);
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            timer += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= delayTime)
            {
                if (mario.Location.Y > marioStartingLocation.Y - 32)
                {
                    mario.Location = new Vector2(mario.Location.X, mario.Location.Y - 1);
                }
            }
            if (timer >= 1000)
            {
                mario.State = new BigMarioIdleRightState(mario);
            }
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