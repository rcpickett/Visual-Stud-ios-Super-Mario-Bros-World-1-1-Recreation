using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class IceMarioGoingDownPipeRightState : IPlayerState
    {
        private IAnimatedSprite sprite;
        private Mario mario;
        private float elapsedTime = 0;
        private float timer = 0;
        private float delayTime = 85;
        private Vector2 newMarioLocation;
        private Vector2 newCameraLocation;

        public IAnimatedSprite Sprite { get { return sprite; } }

        public IceMarioGoingDownPipeRightState(Mario m, Vector2 newL, Vector2 newCL)
        {
            SoundManager.PlayMarioPipeOrPowerDownSound();
            mario = m;
            sprite = SpriteFactory.CreateIceMarioCrouchingRightSprite();
            newMarioLocation = newL;
            newCameraLocation = newCL;
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

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision, Vector2 marioLocation, Vector2 f)
        {
        }

        public void Update(GameTime gameTime)
        {
            mario.Movement = new Vector2(Speed.Zero, Speed.Zero);
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            timer += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= delayTime)
            {
                mario.Location = new Vector2(mario.Location.X, mario.Location.Y + 2);
            }
            if (timer >= 1000)
            {
                mario.Location = newMarioLocation;
                if (newCameraLocation != new Vector2(float.MaxValue))
                {
                    mario.Game.Camera = new StaticCamera(newCameraLocation, mario.Game.Camera);
                    mario.Game.BackgroundColor = Color.Black;
                }
                else
                {
                    mario.Game.Camera = new Camera1(mario.Game.Camera.viewport, mario.Game.Camera.zoom, mario.Game.Level.Limits);
                    mario.Game.BackgroundColor = Color.CornflowerBlue;
                }
                mario.State = new IceMarioIdleRightState(mario);
            }
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
