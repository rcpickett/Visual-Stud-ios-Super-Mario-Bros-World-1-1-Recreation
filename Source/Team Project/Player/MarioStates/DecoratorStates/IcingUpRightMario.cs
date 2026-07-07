using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTypes;

namespace Team_Project
{
    public class IcingUpRightMario : IPlayerState
    {
        private Mario mario;
        private IAnimatedSprite sprite;
        private int state = 0;
        private float delayTime = 85;
        private float elapsedTime = 0;

        public IAnimatedSprite Sprite { get { return sprite; } }

        public IcingUpRightMario(Mario m)
        {
            mario = m;
            sprite = SpriteFactory.CreateBigMarioIdleRightSprite();
            SoundManager.PlayMarioPowerUpSound();
        }

        public void Update(GameTime gameTime)
        {
            mario.Movement = new Vector2(Speed.Zero, Speed.Zero);
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= delayTime)
            {
                elapsedTime = 0;
                state++;
                switch (state % 2)
                {
                    case 0:
                        sprite = SpriteFactory.CreateBigMarioIdleRightSprite();
                        break;
                    case 1:
                        sprite = SpriteFactory.CreateIceMarioIdleRightSprite();
                        break;
                }
            }
            if (state == 8)
            {
                mario.State = new IceMarioIdleRightState(mario);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color c)
        {
            sprite.Draw(spriteBatch, location, Color.White);
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "block"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "collision")]
        public void BlockCollision(Block block, CollisionDetector.CollisionType collision)
        {
        }

        public void PipeCollision(IPipe pipe, CollisionDetector.CollisionType collision, Vector2 newMarioLocation, Vector2 camLocation)
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

        public Mario.Power GetPower()
        {
            return Mario.Power.Ice;
        }
    }
}