using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class SmallCastle : IEndGameObject
    {
        private IAnimatedSprite sprite;
        private int endingSongPlayTime;


        public Vector2 Location { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }
        public Boolean Wins { get; set; }

        public SmallCastle(Vector2 loc)
        {
            Location = loc;
            sprite = SpriteFactory.CreateStaticSprites(CreateSprite.CreateSmallCastle);
            endingSongPlayTime = Value.TwoHundredSeventy;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }

        public void EndGameCollisionResponse(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (LevelEndAnimation.Ending == true)
            {
                mario.EndAnimation();
            }

            if (Wins && mario.Location.X >= (Rectangle.X + (Rectangle.Width / Value.Two) - (mario.Rectangle.Width / Value.Two)))
            {
                LevelEndAnimation.Ending = false;
                endingSongPlayTime--;
                if (endingSongPlayTime == Value.Zero)
                {
                    LevelEndAnimation.GetFireWorkPosition(Location);
                    LevelEndAnimation.MusicStopped = true;
                }
                LevelEndAnimation.MarioInCastle = true;
                mario.Location = new Vector2(mario.Location.X + Value.OneThousand, Value.Zero);
            }
        }
    }
}
