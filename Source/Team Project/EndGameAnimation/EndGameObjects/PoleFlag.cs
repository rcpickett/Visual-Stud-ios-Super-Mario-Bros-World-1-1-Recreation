using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class PoleFlag : IEndGameObject
    {
        private IAnimatedSprite sprite;
        private int PositionFromBottom;

        public Vector2 Location { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }
        public Boolean Wins { get; set; }

        public PoleFlag(Vector2 loc)
        {
            Location = loc;
            sprite = SpriteFactory.CreateStaticSprites(CreateSprite.CreateFlag);
            PositionFromBottom = Value.OneHundredTwentySix;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }

        public void EndGameCollisionResponse(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (PositionFromBottom > Value.Zero && Wins)
            {

                Location = Location + new Vector2(Value.Zero, Value.Two);

                PositionFromBottom = PositionFromBottom - Value.Two;

                mario.Location = new Vector2(mario.Rectangle.X, mario.Location.Y + Value.Two);
                if (PositionFromBottom == Value.Zero)
                {
                    LevelEndAnimation.NumberOfFireworks();
                    LevelEndAnimation.Ending = true;
                    SoundManager.PlayLevelEndingSound = true;
                    mario.Location = new Vector2(mario.Location.X + mario.Rectangle.Width, mario.Location.Y);
                }
            }
        }
    }
}
