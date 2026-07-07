using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class Pole : IEndGameObject
    {
        private IAnimatedSprite sprite;
        private Boolean reachedPole, pointsAdded;

        public Vector2 Location { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }
        public Boolean Wins { get; set; }

        public Pole(Vector2 loc)
        {
            Location = loc;
            sprite = SpriteFactory.CreateStaticSprites(CreateSprite.CreatePole);
            reachedPole = false;
            pointsAdded = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }

        public void EndGameCollisionResponse(IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (collision != CollisionDetector.CollisionType.none)
            {
                mario.PoleSequence();

                if (mario.Location.Y > Location.Y + Rectangle.Height - mario.Rectangle.Height)
                {
                    mario.Location = new Vector2(mario.Location.X, Location.Y + Rectangle.Height - mario.Rectangle.Height);
                }

                // give points based on where landed on pole
                if (!pointsAdded)
                {
                    int groundLevel = 208, blockHeight = Value.Sixteen;
                    if (mario.Location.Y >= groundLevel - Value.Two * blockHeight) mario.ScoreCard.AddPoints(Value.OneHundred);
                    else if (mario.Location.Y >= groundLevel - Value.Four * blockHeight) mario.ScoreCard.AddPoints(Value.FourHundred );
                    else if (mario.Location.Y >= groundLevel - Value.Five * blockHeight) mario.ScoreCard.AddPoints(Value.EightHundred );
                    else if (mario.Location.Y >= groundLevel - Value.Seven * blockHeight) mario.ScoreCard.AddPoints(Value.TwoThousand );
                    else if (mario.Location.Y <  groundLevel - Value.Seven * blockHeight) mario.ScoreCard.AddPoints(Value.FiveThousand );
                    pointsAdded = true;
                }

                if (!reachedPole)
                {
                    reachedPole = true;
                    SoundManager.PlayFlagpoleSound();
                    SoundManager.PauseCurrentMusic();
                    SoundManager.CurrentBackgroundTheme = SoundFactory.CreateSilence();
                    Wins = true;
                    mario.Location = new Vector2((Rectangle.X + (Rectangle.Width / Value.Two)) - mario.Rectangle.Width, mario.Location.Y);
                }               
            }
        }
    }
}
