using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class BlockCoin : IItem
    {
        private IAnimatedSprite sprite;
        private Vector2 accel = new Vector2(Speed.Zero, Speed.ThirtySix);
        private float elapsedTime = Value.Zero;
        private float timer = Value.ThreeHundredThirty;
        private int pointValue = Value.TwoHundred;

        public Vector2 Location { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }
        public Vector2 Movement { get; set; }
        public IItemState State { get; set; }
        public int PointValue { get { return pointValue;} }

        public BlockCoin(Vector2 loc)
        {
            Location = loc;
            sprite = SpriteFactory.CreateBlockCoinSprite();
            Movement = new Vector2(Speed.Zero, Speed.NegativeEight);
            SoundManager.PlayCoinSound();
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= timer)
            {
                Location = new Vector2(Value.NegativeOneThousand, Value.NegativeOneThousand);
            }
            else
            {
                float y = Movement.Y;
                y += accel.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Movement = new Vector2(Movement.X, y);
                Location += Movement;
                sprite.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision)
        {
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject,CollisionDetector.CollisionType collision)
        {
        }
    }
}
