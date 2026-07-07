using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class BowserDeadLeftState : IPlayerState
    {
        private IAnimatedSprite sprite;
        private Mario mario;

        public IAnimatedSprite Sprite { get { return sprite; } }

        public BowserDeadLeftState(Mario m)
        {
            sprite = SpriteFactory.CreateBowserDeadLeftSprite();
            mario = m;
            mario.ScoreCard.LoseLife();
        }

        public void Left()
        {
            MarioMovement.IsFalling = true;
            mario.Movement = new Vector2(Speed.Zero, mario.Movement.Y);
        }

        public void Right()
        {
            MarioMovement.IsFalling = true;
            mario.Movement = new Vector2(Speed.Zero, mario.Movement.Y);
        }

        public void Up()
        {
            MarioMovement.IsFalling = true;
            mario.Movement = new Vector2(Speed.Zero, mario.Movement.Y);
        }

        public void Down()
        {
            MarioMovement.IsFalling = true;
            mario.Movement = new Vector2(Speed.Zero, mario.Movement.Y);
        }

        public void B()
        {
            MarioMovement.IsFalling = true;
            mario.Movement = new Vector2(Speed.Zero, mario.Movement.Y);
        }

        public void NoCommand()
        {
            MarioMovement.IsFalling = true;
            mario.Movement = new Vector2(Speed.Zero, mario.Movement.Y);
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

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision, Vector2 marioLocation, Vector2 camLocation)
        {
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
            return Mario.Power.Dead;
        }
    }
}
