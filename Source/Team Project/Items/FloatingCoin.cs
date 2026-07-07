using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class FloatingCoin : IItem
    {
        private IAnimatedSprite sprite;
        private int pointValue = Value.TwoHundred;

        public Vector2 Location { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }
        public Vector2 Movement { get; set; }
        public IItemState State { get; set; }
        public int PointValue { get { return pointValue; } }

        public FloatingCoin(Vector2 loc)
        {
            Location = loc;
            sprite = SpriteFactory.CreateFloatingCoinSprite();
            State = new OutOfBlockStaticState(this);
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }

        public void CollisionResponseWithPlayer(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            State.CollisionResponseWithPlayer(mario, collision);
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
            State.CollisionResponseWithStaticObject(staticObject, collision);
        }
    }
}
