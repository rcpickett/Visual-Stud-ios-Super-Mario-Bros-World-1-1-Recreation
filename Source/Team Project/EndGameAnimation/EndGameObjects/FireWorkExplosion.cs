using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class FireWorkExplosion : IProjectile
    {
        private MarioFireballExplodingSprite sprite;

        private float timer = Value.Zero;
        private float totalTime = Value.FourHundred;
        private int pointValue = Value.FourHundred;
        private static Dictionary<int, Vector2> DeviationMap;
        private Vector2 deviation;

        public Vector2 Location { get; set; }
        public Vector2 Movement { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }

        public FireWorkExplosion(Vector2 loc)
        {
            sprite = (MarioFireballExplodingSprite)SpriteFactory.CreateFireballExplodingSprite();

            DeviationMap = new Dictionary<int, Vector2>();
            DeviationMap.Add(0, new Vector2(loc.X + Value.Twenty, loc.Y - Value.Forty));
            DeviationMap.Add(1, new Vector2(loc.X-Value.Twenty, loc.Y-Value.Fifteen));
            DeviationMap.Add(2, new Vector2(loc.X+Value.Fifty, loc.Y-Value.ThirtyThree));
            DeviationMap.Add(3, new Vector2(loc.X+Value.Eighty, loc.Y));
        }


        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
        }

        public void Update(Game1 game, GameTime gameTime)
        {
            DeviationMap.TryGetValue(LevelEndAnimation.NumFireWorks % Value.Four, out deviation);
            Location = deviation;
            sprite.DelayTime = Value.TwoHundred;
            timer += gameTime.ElapsedGameTime.Milliseconds;

            if (timer >= totalTime && LevelEndAnimation.NumFireWorks > Value.Zero)
            {
                timer = Value.Zero;
                LevelEndAnimation.NumFireWorks--;
                if (LevelEndAnimation.NumFireWorks != Value.Zero)
                {
                    SoundManager.PlayFireworksSound();
                    game.currentPlayer.ScoreCard.AddPoints(pointValue);
                }
            }
            if (LevelEndAnimation.NumFireWorks == Value.Zero)
                LevelEndAnimation.FinishedFireWork();

            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }
    }
}
