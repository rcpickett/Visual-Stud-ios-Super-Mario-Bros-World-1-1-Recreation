using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class IceFlower : IItem
    {
        private IAnimatedSprite sprite;
        private int pointValue = Value.OneThousand;

        public Vector2 Location { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }
        public Vector2 Movement { get; set; }
        public IItemState State { get; set; }
        public int PointValue { get { return pointValue; } }

        public IceFlower(Vector2 loc, Block block)
        {
            Location = loc;
            sprite = SpriteFactory.CreateIceFlowerSprite();
            State = new ComingOutOfBlockState(this, block);
            SoundManager.PlayItemAppearingSound();
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
