using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class CastleFlag : IEndGameObject
    {
        private IAnimatedSprite sprite;
        private int PositionFromTop;

        public Vector2 Location { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }
        public Boolean Wins { get; set; }

        public CastleFlag(Vector2 loc)
        {
            Location = loc;
            sprite = SpriteFactory.CreateStaticSprites(CreateSprite.CreateCastleFlag);
            PositionFromTop = Value.TwentyTwo;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }

        public void EndGameCollisionResponse(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (PositionFromTop > 0 && Wins && LevelEndAnimation.MusicStopped)
            {
                Location = Location + new Vector2(Value.Zero, Value.NegativeOne);
                PositionFromTop = PositionFromTop - Value.One;
            }
        }
    }
}
